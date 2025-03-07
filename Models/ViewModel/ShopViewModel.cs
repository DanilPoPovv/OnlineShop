﻿using OnlineShop.Models.POCO;

namespace OnlineShop.Models.ViewModel
{
    public class ShopViewModel
    {
        public Shop Shop { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
