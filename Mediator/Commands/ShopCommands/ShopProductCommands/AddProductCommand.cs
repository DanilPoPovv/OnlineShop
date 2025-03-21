﻿using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands
{
    public class AddProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ShopId { get; set; }
    }
}
