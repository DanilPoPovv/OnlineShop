﻿using MediatR;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Search.SearchQueries
{
    public class GetShopProductsQuery : IRequest<PaginatedList<Product>>
    {
        public int ShopId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? ProductSearch { get; set; }

    }
}
