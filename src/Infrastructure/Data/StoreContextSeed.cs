﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext db)
        {
            if (db.Categories.Any() || db.Brands.Any() || db.Products.Any()) return;

            Category c1 = new Category() { Name = "Sneakers" };
            Category c2 = new Category() { Name = "Sliipers" };
            Category c3 = new Category() { Name = "Boots" };
            Category c4 = new Category() { Name = "Bag" };

            Brand b1 = new Brand() { Name = "U.S. Polo Assn." };
            Brand b2 = new Brand() { Name = "Skechers" };
            Brand b3 = new Brand() { Name = "Adidas" };
            Brand b4 = new Brand() { Name = "Puma" };
            Brand b5 = new Brand() { Name = "Nike" };

            Product p1 = new Product() { Name = "U.S. Polo Assn. White Women Sneaker", Price = 10.66m, PictureUri = "01.jpg", Category = c1, Brand = b1 };
            Product p2 = new Product() { Name = "U.S. Polo Assn. White Men Shoes", Price = 18.12m, PictureUri = "02.jpg", Category = c1, Brand = b1 };
            Product p3 = new Product() { Name = "U.S. Polo Assn. White Women Boots", Price = 24.87m, PictureUri = "03.jpg", Category = c3, Brand = b1 };
            Product p4 = new Product() { Name = "U.S. Polo Assn. Navy Blue Women Beach Slippers", Price = 7.11m, PictureUri = "04.jpg", Category = c2, Brand = b1 };
            Product p5 = new Product() { Name = "Skechers D'lux Walker Black Women Boots", Price = 71.00m, PictureUri = "05.jpg", Category = c3, Brand = b2 };
            Product p6 = new Product() { Name = "Skechers Brown DELSON - ANTIGO", Price = 71.00m, PictureUri = "06.jpg", Category = c1, Brand = b2 };
            Product p7 = new Product() { Name = "Skechers Bkgy Go Walk 5 Black Men Sneaker", Price = 49.68m, PictureUri = "07.jpg", Category = c2, Brand = b2 };
            Product p8 = new Product() { Name = "Adidas Daily Black Unisex Backpack", Price = 21.96m, PictureUri = "08.jpg", Category = c4, Brand = b3 };
            Product p9 = new Product() { Name = "Adidas Response Run Black Women Running Shoes", Price = 48.87m, PictureUri = "09.jpg", Category = c1, Brand = b3 };
            Product p10 = new Product() { Name = "Nike NK Heritage Backpack", Price = 28.43m, PictureUri = "10.jpg", Category = c4, Brand = b5 };
            Product p11 = new Product() { Name = "Puma Red Black Backpack", Price = 13.50m, PictureUri = "11.jpg", Category = c4, Brand = b4 };
            Product p12 = new Product() { Name = "U.S Polo Assn. Black Women Backpack", Price = 39.80m, PictureUri = "12.jpg", Category = c4, Brand = b1 };


            db.AddRange(c1, c2, c3, c4, b1, b2, b3, b4, b5, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            await db.SaveChangesAsync();
        }
    }
}
