using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Using {ProgramConstants.DataBaseProvider} database provider.");
            // QueryingCategories();
            // FilterIncludes();
            // QueryingProducts();
            // QueryingWithLike();
            // try adding a new product
            if(AddProducts(categoryId: 6, productName: "La pizza de don Cangrejo", price: 500M,))
            {
                WriteLine("Add Product succesful");
            }
            ListProducts();
        }
        static void QueryingCategories()
        {
            using (Northwind db = new())
            {
                WriteLine("Categories and how many products they have");
                // ALL Queries with EF Core, should be returned by a IQueryable type
                IQueryable<Category>? categories = db.Categories?.Include(c => c.Products);
                if (categories is null)
                {
                    WriteLine("No categories found.");
                    return;
                }
                foreach (var c in categories)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void FilterIncludes()
        {
            using (Northwind db = new())
            {
                Write("Enter a minimum for units in Stock: ");
                string unitsInStock = ReadLine() ?? "10";
                int stock = int.Parse(unitsInStock);
                IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));
                if (categories is null)
                {
                    WriteLine("No categories found.");
                    return;
                }
                foreach (var c in categories)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimun {stock} units in stock.");
                    foreach (var p in c.Products)
                    {
                        WriteLine($"{p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            using(Northwind db = new())
            {
                WriteLine("Products that cost more than a price, highest at top");
                string? input;
                decimal price;
                do
                {
                    Write("Enter a product price");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));
                IQueryable<Product>? products = db.Products? 
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost);
                if( products is null )
                {
                    WriteLine("No products found.");
                    return;
                }
                // Sooooo... you maybe wondering, how the fuck is that a query? ... well...
                // you can actually see the query that is been sent to the DB motor with ToQueryString() ... try to put them in the other functions
                WriteLine($"ToQueryString : {products.ToQueryString()}");
                foreach (var p in products)
                {
                    WriteLine($"{p.ProductId} : {p.ProductName} costs {p.Cost:$#,##0.00} and has {p.Stock} in stock");
                }
            }
        }

        static void QueryingWithLike()
        {
            using (Northwind db = new())
            {
                Write("Enter part of a product name : ");
                string? input = ReadLine();
                IQueryable<Product>? products = db.Products
                .Where (p => EF.Functions.Like(p.ProductName, $"%{input}%"));
                if(products is null)
                {
                    WriteLine("No products found");
                    return;
                }
                foreach (var p in products)
                {
                    WriteLine($"{p.ProductName} has {p.Stock} units in stock. Discontinued? {p.Discontinued}");
                }
            }
        }

        // And now ... for my next trick ... CRUD! :B
        // Create
        static bool AddProducts(int categoryId, string productName, decimal? price)
        {
            using (Northwind db = new())
            {
                Product p = new(){
                    CategoryId = categoryId,
                    ProductName = productName,
                    Cost = price
                };
                db.Products.Add(p);
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        // Read
        static void ListProducts()
        {
            using (Northwind db = new())
            {
                WriteLine("{0, -3} {1, -35} {2, 8} {3, 5} {4}", "Id", "Product Name", "Cost", "Stock", "Disc.");
                foreach (var p in db.Products .OrderByDescending(product => product.Cost))
                {
                    WriteLine($"{p.ProductId: 000} {p.ProductName, -35} {p.Cost, 8: $#,##0.00} {p.Stock, 5} {p.Discontinued}");
                }
            }
        }
        
        // Update
        static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
        {
            using (Northwind db = new())
            {
                Product updateProduct = db.Products.First( p => p.ProductName.StartsWith(productNameStartsWith));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        // AAAAAANd delete ... Kab000m
        static int DeleteProducts(string productNameStartsWith)
        {
            using (Northwind db = new())
            {
                IQueryable<Product>? products = db.Products?.Where( p=> p.ProductName.StartsWith(productNameStartsWith));
                if (products is null)
                {
                    WriteLine("No products found to delete");
                    return 0;
                }
                else
                {
                    db.Products.RemoveRange(products);
                }
                int affected = db.SaveChanges();
                return affected;
            }
        }
    }
}