using PromartStore.API.Data;
using PromartStore.API.Models;

namespace PromartStore.API.Data;

/// <summary>
/// Puebla la base de datos en memoria con usuarios y productos de prueba.
/// </summary>
public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // ── Usuarios ──────────────────────────────────────────────────────────
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User
                {
                    Id = 1,
                    Username = "user@promart.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Test1234!")
                },
                new User
                {
                    Id = 2,
                    Username = "admin@promart.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin1234!")
                }
            );
        }

        // ── Productos ─────────────────────────────────────────────────────────
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                // Electronics
                new()
                {
                    Id = 1,
                    Title = "Fjallraven - Foldsack No. 1 Backpack",
                    Price = 109.95,
                    Description = "Your perfect pack for everyday use and walks in the forest.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/backpack1/400/400",
                    Rating = new ProductRating { Id = 1, ProductId = 1, Rate = 3.9, Count = 120 }
                },
                new()
                {
                    Id = 2,
                    Title = "Apple AirPods Pro (2nd Gen)",
                    Price = 249.99,
                    Description = "Active noise cancellation for immersive sound. Adaptive Transparency.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/airpods2/400/400",
                    Rating = new ProductRating { Id = 2, ProductId = 2, Rate = 4.8, Count = 892 }
                },
                new()
                {
                    Id = 3,
                    Title = "Samsung Galaxy S23 Ultra",
                    Price = 1199.99,
                    Description = "200MP camera · S Pen · 5000mAh battery for all-day power.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/samsung3/400/400",
                    Rating = new ProductRating { Id = 3, ProductId = 3, Rate = 4.7, Count = 438 }
                },
                new()
                {
                    Id = 4,
                    Title = "Logitech MX Master 3 Wireless Mouse",
                    Price = 79.99,
                    Description = "Advanced wireless mouse for power users. Works on any surface.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/mouse4/400/400",
                    Rating = new ProductRating { Id = 4, ProductId = 4, Rate = 4.6, Count = 671 }
                },
                new()
                {
                    Id = 5,
                    Title = "Sony WH-1000XM5 Headphones",
                    Price = 348.00,
                    Description = "Industry-leading noise canceling with up to 30-hour battery life.",
                    Category = "electronics",
                    Image = "https://picsum.photos/seed/headphones5/400/400",
                    Rating = new ProductRating { Id = 5, ProductId = 5, Rate = 4.9, Count = 315 }
                },
                // Jewelery
                new()
                {
                    Id = 6,
                    Title = "John Hardy Women's Legends Naga Gold Ring",
                    Price = 695.00,
                    Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/ring6/400/400",
                    Rating = new ProductRating { Id = 6, ProductId = 6, Rate = 4.6, Count = 400 }
                },
                new()
                {
                    Id = 7,
                    Title = "Solid Gold Petite Micropave Diamond Ring",
                    Price = 168.00,
                    Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/diamond7/400/400",
                    Rating = new ProductRating { Id = 7, ProductId = 7, Rate = 3.9, Count = 70 }
                },
                new()
                {
                    Id = 8,
                    Title = "White Gold Plated Princess Cut CZ Earrings",
                    Price = 9.99,
                    Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/earrings8/400/400",
                    Rating = new ProductRating { Id = 8, ProductId = 8, Rate = 3.0, Count = 400 }
                },
                new()
                {
                    Id = 9,
                    Title = "Rose Gold Plated Bracelet Set",
                    Price = 29.99,
                    Description = "Set of 5 beautiful rose gold tone bracelets with cubic zirconia stones.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/bracelet9/400/400",
                    Rating = new ProductRating { Id = 9, ProductId = 9, Rate = 4.2, Count = 233 }
                },
                new()
                {
                    Id = 10,
                    Title = "Sterling Silver Infinity Necklace",
                    Price = 44.90,
                    Description = "925 sterling silver infinity symbol pendant necklace with adjustable chain.",
                    Category = "jewelery",
                    Image = "https://picsum.photos/seed/necklace10/400/400",
                    Rating = new ProductRating { Id = 10, ProductId = 10, Rate = 4.5, Count = 189 }
                },
                // Men's Clothing
                new()
                {
                    Id = 11,
                    Title = "Mens Casual Premium Slim Fit T-Shirts",
                    Price = 22.30,
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/tshirt11/400/400",
                    Rating = new ProductRating { Id = 11, ProductId = 11, Rate = 4.1, Count = 259 }
                },
                new()
                {
                    Id = 12,
                    Title = "Mens Cotton Jacket",
                    Price = 55.99,
                    Description = "Great outerwear jackets for men. Outer shell made from genuine cowhide leather.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/jacket12/400/400",
                    Rating = new ProductRating { Id = 12, ProductId = 12, Rate = 4.7, Count = 500 }
                },
                new()
                {
                    Id = 13,
                    Title = "Mens Casual Slim Fit Chino Pants",
                    Price = 15.99,
                    Description = "The color could be slightly different between on the screen and in practice.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/pants13/400/400",
                    Rating = new ProductRating { Id = 13, ProductId = 13, Rate = 2.1, Count = 430 }
                },
                new()
                {
                    Id = 14,
                    Title = "Lock and Love Men's Removable Hooded Faux Leather Biker Jacket",
                    Price = 29.95,
                    Description = "100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/biker14/400/400",
                    Rating = new ProductRating { Id = 14, ProductId = 14, Rate = 2.9, Count = 340 }
                },
                new()
                {
                    Id = 15,
                    Title = "Rain Jacket 100% Polyester",
                    Price = 39.99,
                    Description = "Ideal for all outdoor activities and beach sporting events.",
                    Category = "men's clothing",
                    Image = "https://picsum.photos/seed/rain15/400/400",
                    Rating = new ProductRating { Id = 15, ProductId = 15, Rate = 3.8, Count = 679 }
                },
                // Women's Clothing
                new()
                {
                    Id = 16,
                    Title = "Opna Women's Short Sleeve Moisture Tunic",
                    Price = 7.95,
                    Description = "100% Polyester, Machine wash, 100% cationic polyester interlock.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/tunic16/400/400",
                    Rating = new ProductRating { Id = 16, ProductId = 16, Rate = 4.5, Count = 146 }
                },
                new()
                {
                    Id = 17,
                    Title = "MBJ Women's Solid Short Sleeve Boat Neck V",
                    Price = 9.85,
                    Description = "95% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/boatneck17/400/400",
                    Rating = new ProductRating { Id = 17, ProductId = 17, Rate = 4.7, Count = 130 }
                },
                new()
                {
                    Id = 18,
                    Title = "Womens Cocktail Dress - Elegant A-Line",
                    Price = 67.99,
                    Description = "Classic knee-length cocktail dress with lace detailing and fit-and-flare silhouette.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/dress18/400/400",
                    Rating = new ProductRating { Id = 18, ProductId = 18, Rate = 3.6, Count = 235 }
                },
                new()
                {
                    Id = 19,
                    Title = "Women's Slim Leg Trousers High-Waisted",
                    Price = 34.90,
                    Description = "High-waist design that emphasizes curves with a slim-fit tapered leg.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/trousers19/400/400",
                    Rating = new ProductRating { Id = 19, ProductId = 19, Rate = 4.1, Count = 301 }
                },
                new()
                {
                    Id = 20,
                    Title = "Women's Longline Puffer Jacket",
                    Price = 89.99,
                    Description = "Water-resistant quilted outer shell with cosy fleece lining. Available in 6 colours.",
                    Category = "women's clothing",
                    Image = "https://picsum.photos/seed/puffer20/400/400",
                    Rating = new ProductRating { Id = 20, ProductId = 20, Rate = 4.3, Count = 417 }
                },
            };

            context.Products.AddRange(products);
        }

        context.SaveChanges();
    }
}
