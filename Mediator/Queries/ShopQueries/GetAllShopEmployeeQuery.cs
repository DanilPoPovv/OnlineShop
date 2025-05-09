﻿using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopEmployeeQuery : IRequest<List<User>>
    {
        public int shopId { get; set; }
    }
}
