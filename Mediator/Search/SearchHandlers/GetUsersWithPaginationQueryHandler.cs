using OnlineShop.Models.ViewModel;
using MediatR;
using OnlineShop.Mediator.Search.SearchQueries;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Search.SearchHandlers
{
    public class GetUsersWithPaginationHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<User>>
    {
        public readonly IUserRepository _userRepository;

        public GetUsersWithPaginationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PaginatedList<User>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersWithPagination(request.PageNumber, request.PageSize, request.UserSearch);
            return users;
        }
    }
}
