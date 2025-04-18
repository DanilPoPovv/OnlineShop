﻿namespace OnlineShop.Models.POCO
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public User? Manager { get; set; }

        public ICollection<User>? Employees { get; set; } = new List<User>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
