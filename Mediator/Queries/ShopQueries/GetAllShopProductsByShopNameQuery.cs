﻿using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopProductsByShopNameQuery : IRequest<List<Product>>
    {
        public string ShopName;
    }
}
