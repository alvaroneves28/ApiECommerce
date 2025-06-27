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

            // Categorias
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Meals", UrlImage = "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=400&h=300" },
                new Category { Id = 2, Name = "Combo Meals", UrlImage = "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?auto=format&fit=crop&w=400&h=300" },
                new Category { Id = 3, Name = "Naturals", UrlImage = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=400&h=300" },
                new Category { Id = 4, Name = "Drinks", UrlImage = "https://images.unsplash.com/photo-1510626176961-4b532c216c48?auto=format&fit=crop&w=400&h=300" },
                new Category { Id = 5, Name = "Juices", UrlImage = "https://images.unsplash.com/photo-1572371242054-d1e6fac0f039?auto=format&fit=crop&w=400&h=300" },
                new Category { Id = 6, Name = "Desserts", UrlImage = "https://images.unsplash.com/photo-1595006316746-3d470a6bbf4b?auto=format&fit=crop&w=400&h=300" }
            );

            // Produtos
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Hamburger Standard", Detail = "Classic hamburger", UrlImage = "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=400&h=300", Price = 5.99m, Available = true, Stock = 50, Popular = true, MostSold = true, CategoryId = 1 },
                new Product { Id = 2, Name = "Cheeseburger Standard", Detail = "Hamburger with cheese", UrlImage = "https://images.unsplash.com/photo-1606755962776-0d82a6bdc9d1?auto=format&fit=crop&w=400&h=300", Price = 6.49m, Available = true, Stock = 45, Popular = true, MostSold = false, CategoryId = 1 },
                new Product { Id = 3, Name = "Cheese salad Standard", Detail = "Salad with cheese", UrlImage = "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300", Price = 5.29m, Available = true, Stock = 30, Popular = false, MostSold = false, CategoryId = 1 },

                new Product { Id = 4, Name = "Hamburger, fries, soda", Detail = "Combo meal with hamburger", UrlImage = "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?auto=format&fit=crop&w=400&h=300", Price = 9.99m, Available = true, Stock = 40, Popular = true, MostSold = true, CategoryId = 2 },
                new Product { Id = 5, Name = "Cheeseburger, fries, soda", Detail = "Combo meal with cheeseburger", UrlImage = "https://images.unsplash.com/photo-1606755962776-0d82a6bdc9d1?auto=format&fit=crop&w=400&h=300", Price = 10.49m, Available = true, Stock = 35, Popular = true, MostSold = false, CategoryId = 2 },
                new Product { Id = 6, Name = "Cheese salad, fries, soda", Detail = "Combo meal with salad", UrlImage = "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300", Price = 8.99m, Available = true, Stock = 25, Popular = false, MostSold = false, CategoryId = 2 },

                new Product { Id = 7, Name = "Natural meal with leafs", Detail = "Vegetarian meal", UrlImage = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=400&h=300", Price = 7.99m, Available = true, Stock = 20, Popular = true, MostSold = false, CategoryId = 3 },
                new Product { Id = 8, Name = "Natural meal with cheese", Detail = "Vegetarian meal with cheese", UrlImage = "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300", Price = 8.49m, Available = true, Stock = 15, Popular = false, MostSold = false, CategoryId = 3 },
                new Product { Id = 9, Name = "Vegan", Detail = "Fully vegan option", UrlImage = "https://images.unsplash.com/photo-1584270354949-1e4460a73f30?auto=format&fit=crop&w=400&h=300", Price = 8.99m, Available = true, Stock = 10, Popular = false, MostSold = false, CategoryId = 3 },

                new Product { Id = 10, Name = "Coca-cola", Detail = "Cold Coca-Cola can", UrlImage = "https://images.unsplash.com/photo-1510626176961-4b532c216c48?auto=format&fit=crop&w=400&h=300", Price = 1.50m, Available = true, Stock = 100, Popular = true, MostSold = true, CategoryId = 4 },
                new Product { Id = 11, Name = "Guaraná", Detail = "Refreshing Brazilian soda", UrlImage = "https://images.unsplash.com/photo-1604081162767-2ac79c030e66?auto=format&fit=crop&w=400&h=300", Price = 1.40m, Available = true, Stock = 80, Popular = false, MostSold = false, CategoryId = 4 },
                new Product { Id = 12, Name = "Pepsi", Detail = "Cold Pepsi can", UrlImage = "https://images.unsplash.com/photo-1600284677450-0609be27a4be?auto=format&fit=crop&w=400&h=300", Price = 1.50m, Available = true, Stock = 90, Popular = false, MostSold = false, CategoryId = 4 },

                new Product { Id = 13, Name = "Orange juice", Detail = "Fresh orange juice", UrlImage = "https://images.unsplash.com/photo-1572371242054-d1e6fac0f039?auto=format&fit=crop&w=400&h=300", Price = 2.00m, Available = true, Stock = 50, Popular = true, MostSold = false, CategoryId = 5 },
                new Product { Id = 14, Name = "Strawberry juice", Detail = "Fresh strawberry juice", UrlImage = "https://images.unsplash.com/photo-1587316745621-3757c7076f7e?auto=format&fit=crop&w=400&h=300", Price = 2.20m, Available = true, Stock = 45, Popular = false, MostSold = false, CategoryId = 5 },
                new Product { Id = 15, Name = "Grape Juice", Detail = "Fresh grape juice", UrlImage = "https://images.unsplash.com/photo-1571680797520-32d9c90911c6?auto=format&fit=crop&w=400&h=300", Price = 2.10m, Available = true, Stock = 40, Popular = false, MostSold = false, CategoryId = 5 },
                new Product { Id = 16, Name = "Water", Detail = "Mineral water", UrlImage = "https://images.unsplash.com/photo-1588001403519-989f1f11f1c7?auto=format&fit=crop&w=400&h=300", Price = 1.00m, Available = true, Stock = 100, Popular = false, MostSold = false, CategoryId = 5 },

                new Product { Id = 17, Name = "Chocolate cookies", Detail = "Chocolate chip cookies", UrlImage = "https://images.unsplash.com/photo-1595006316746-3d470a6bbf4b?auto=format&fit=crop&w=400&h=300", Price = 2.50m, Available = true, Stock = 30, Popular = true, MostSold = false, CategoryId = 6 },
                new Product { Id = 18, Name = "Vanilla cookies", Detail = "Vanilla flavored cookies", UrlImage = "https://images.unsplash.com/photo-1613145991415-bd12f7e6de26?auto=format&fit=crop&w=400&h=300", Price = 2.40m, Available = true, Stock = 28, Popular = false, MostSold = false, CategoryId = 6 },
                new Product { Id = 19, Name = "Swiss cake", Detail = "Chocolate swiss roll cake", UrlImage = "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=400&h=300", Price = 3.00m, Available = true, Stock = 25, Popular = true, MostSold = true, CategoryId = 6 }
            );
        }




    }
}
