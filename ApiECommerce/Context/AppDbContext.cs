using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasPrecision(18, 2);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasPrecision(18, 2);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Meals", UrlImage = "https://source.unsplash.com/400x300/?meal,food" },
                new Category { Id = 2, Name = "Combo Meals", UrlImage = "https://source.unsplash.com/400x300/?combo-meal,fastfood" },
                new Category { Id = 3, Name = "Naturals", UrlImage = "https://source.unsplash.com/400x300/?natural,vegetarian" },
                new Category { Id = 4, Name = "Drinks", UrlImage = "https://source.unsplash.com/400x300/?drink,soda" },
                new Category { Id = 5, Name = "Juices", UrlImage = "https://source.unsplash.com/400x300/?juice,fruit" },
                new Category { Id = 6, Name = "Desserts", UrlImage = "https://source.unsplash.com/400x300/?dessert,cake" }
);


            modelBuilder.Entity<Product>().HasData(
              
                new Product { Id = 1, Name = "Hamburger Standard", Detail = "Classic hamburger", UrlImage = "https://source.unsplash.com/400x300/?burger", Price = 5.99m, Available = true, Stock = 50, Popular = true, MostSold = true, CategoryId = 1 },
                new Product { Id = 2, Name = "Cheseburger Standard", Detail = "Hamburger with cheese", UrlImage = "https://source.unsplash.com/400x300/?cheeseburger", Price = 6.49m, Available = true, Stock = 45, Popular = true, MostSold = false, CategoryId = 1 },
                new Product { Id = 3, Name = "Chese salad Standard", Detail = "Salad with cheese", UrlImage = "https://source.unsplash.com/400x300/?salad", Price = 5.29m, Available = true, Stock = 30, Popular = false, MostSold = false, CategoryId = 1 },

                new Product { Id = 4, Name = "Hamburger, fries, soda", Detail = "Combo meal with hamburger", UrlImage = "https://source.unsplash.com/400x300/?burger,fries,cola", Price = 9.99m, Available = true, Stock = 40, Popular = true, MostSold = true, CategoryId = 2 },
                new Product { Id = 5, Name = "Cheseburger, fries, soda", Detail = "Combo meal with cheeseburger", UrlImage = "https://source.unsplash.com/400x300/?cheeseburger,fries,drink", Price = 10.49m, Available = true, Stock = 35, Popular = true, MostSold = false, CategoryId = 2 },
                new Product { Id = 6, Name = "Chese salad, fries, soda", Detail = "Combo meal with salad", UrlImage = "https://source.unsplash.com/400x300/?salad,fries,drink", Price = 8.99m, Available = true, Stock = 25, Popular = false, MostSold = false, CategoryId = 2 },

                new Product { Id = 7, Name = "Natural meal with leafs", Detail = "Vegetarian meal", UrlImage = "https://source.unsplash.com/400x300/?vegetarian", Price = 7.99m, Available = true, Stock = 20, Popular = true, MostSold = false, CategoryId = 3 },
                new Product { Id = 8, Name = "Natural meal with chese", Detail = "Vegetarian meal with cheese", UrlImage = "https://source.unsplash.com/400x300/?vegetarian,cheese", Price = 8.49m, Available = true, Stock = 15, Popular = false, MostSold = false, CategoryId = 3 },
                new Product { Id = 9, Name = "Vegan", Detail = "Fully vegan option", UrlImage = "https://source.unsplash.com/400x300/?vegan", Price = 8.99m, Available = true, Stock = 10, Popular = false, MostSold = false, CategoryId = 3 },

                new Product { Id = 10, Name = "Coca-cola", Detail = "Cold Coca-Cola can", UrlImage = "https://source.unsplash.com/400x300/?coca-cola", Price = 1.50m, Available = true, Stock = 100, Popular = true, MostSold = true, CategoryId = 4 },
                new Product { Id = 11, Name = "Guaraná", Detail = "Refreshing Brazilian soda", UrlImage = "https://source.unsplash.com/400x300/?soda,guarana", Price = 1.40m, Available = true, Stock = 80, Popular = false, MostSold = false, CategoryId = 4 },
                new Product { Id = 12, Name = "Pepsi", Detail = "Cold Pepsi can", UrlImage = "https://source.unsplash.com/400x300/?pepsi", Price = 1.50m, Available = true, Stock = 90, Popular = false, MostSold = false, CategoryId = 4 },

                new Product { Id = 13, Name = "Orange juice", Detail = "Fresh orange juice", UrlImage = "https://source.unsplash.com/400x300/?orange-juice", Price = 2.00m, Available = true, Stock = 50, Popular = true, MostSold = false, CategoryId = 5 },
                new Product { Id = 14, Name = "Strawberry juice", Detail = "Fresh strawberry juice", UrlImage = "https://source.unsplash.com/400x300/?strawberry-juice", Price = 2.20m, Available = true, Stock = 45, Popular = false, MostSold = false, CategoryId = 5 },
                new Product { Id = 15, Name = "Grape Juice", Detail = "Fresh grape juice", UrlImage = "https://source.unsplash.com/400x300/?grape-juice", Price = 2.10m, Available = true, Stock = 40, Popular = false, MostSold = false, CategoryId = 5 },
                new Product { Id = 16, Name = "Water", Detail = "Mineral water", UrlImage = "https://source.unsplash.com/400x300/?water,bottle", Price = 1.00m, Available = true, Stock = 100, Popular = false, MostSold = false, CategoryId = 5 },

                new Product { Id = 17, Name = "Chocolate cookies", Detail = "Chocolate chip cookies", UrlImage = "https://source.unsplash.com/400x300/?chocolate-cookies", Price = 2.50m, Available = true, Stock = 30, Popular = true, MostSold = false, CategoryId = 6 },
                new Product { Id = 18, Name = "Vanilla cookies", Detail = "Vanilla flavored cookies", UrlImage = "https://source.unsplash.com/400x300/?vanilla-cookies", Price = 2.40m, Available = true, Stock = 28, Popular = false, MostSold = false, CategoryId = 6 },
                new Product { Id = 19, Name = "Swiss cake", Detail = "Chocolate swiss roll cake", UrlImage = "https://source.unsplash.com/400x300/?cake,chocolate", Price = 3.00m, Available = true, Stock = 25, Popular = true, MostSold = true, CategoryId = 6 }

            );
        }



    }
}
