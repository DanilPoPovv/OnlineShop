using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUsersCommand,User?>   
    {
        IUserRepository _userRepository;
        IShopRepository _shopRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository,IShopRepository shopRepository)
        {
            _userRepository = userRepository;
            _shopRepository = shopRepository;
        }
        public async Task<User?> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdIncludeShop(command.UserId);
            if (user == null)
            {
                return null;
            }

            bool isUpdated = false;

            if (!string.IsNullOrWhiteSpace(command.Name) && command.Name != user.Name)
            {
                user.Name = command.Name;
                isUpdated = true;
            }

            if (!string.IsNullOrWhiteSpace(command.Password) && command.Password != user.Password)
            {
                user.Password = command.Password; // Хешируем перед сохранением
                isUpdated = true;
            }

            if (command.Role.HasValue && command.Role != user.Role)
            {
                user.Role = command.Role.Value;
                isUpdated = true;
            }
            if (!string.IsNullOrWhiteSpace(command.ShopName))
            {
                var shop = await _shopRepository.GetShopByName(command.ShopName);
                if (shop != null && shop.Id != user.ShopId) // Проверяем, что магазин действительно найден и отличается
                {
                    user.ShopId = shop.Id;
                    user.Shop = shop; // Обновляем сам объект Shop, если EF отслеживает его
                    isUpdated = true;
                }
            }
            else if (command.ShopName == null) // Если передан null, то отвязываем магазин
            {
                user.ShopId = null;
                user.Shop = null;
                isUpdated = true;
            }

            // Если изменений нет, просто возвращаем пользователя без обновления БД
            if (!isUpdated)
                return user;

            await _userRepository.UpdateAsync(user);
            return user;
        }
        
    }
}
