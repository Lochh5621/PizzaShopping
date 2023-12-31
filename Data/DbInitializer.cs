﻿using Microsoft.EntityFrameworkCore;
using PizzaShopping.Models;
using PizzaShopping.Models.Enum;

namespace PizzaShopping.Data
{
    public static class DbInitializer
    {
        //Initialize data if not exists
        public static void Initialize(PizzaContext context)
        {
            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category { CategoryName = "Meat", Description = "For meat eaters" },
                    new Category { CategoryName = "Vegan", Description = "For meat haters" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.Suppliers.Any())
            {
                List<Supplier> suppliers = new List<Supplier>
                {
                    new Supplier {CompanyName = "Pizza Hut", Address= "USA", Phone="0123456789" },
                    new Supplier {CompanyName = "Al Fresco", Address= "Germany", Phone="0123456788" },
                    new Supplier {CompanyName = "Domino's", Address= "Vietnam", Phone="0888666777" },
                };

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                List<Product> products = new List<Product>
                {
                    new Product {ProductName="Peperoni", SupplierId = 1, CategoryId = 1, QuantityPerUnit = 100, UnitPrice = 10.99, ProductImage= "https://foodhub.scene7.com/is/image/woolworthsltdprod/2004-easy-pepperoni-pizza:Mobile-1300x1150"},
                    new Product {ProductName="Vegan", SupplierId = 1, CategoryId = 1, QuantityPerUnit = 100, UnitPrice = 7.5, ProductImage= "https://biancazapatka.com/wp-content/uploads/2020/05/quinoa-pizza-mit-spargel.jpg" },
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Accounts.Any())
            {
                List<Account> accounts = new List<Account>
                {
                    new Account { FullName = "Ha Huu Loc", Password = "123456", Username = "hahuuloc", Type = AccountType.Staff},
                    new Account { FullName = "Nguyen Phuoc Thanh", Password = "123456", Username = "thanh", Type = AccountType.Staff}
                };
                context.Accounts.AddRange(accounts);
                context.SaveChanges();
            }

            Customer customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                ContactName= "Test",
                Address = "Hanoi",
                Password = "Password",
                Phone= "1234567890"
            };

            if (!context.Customers.Any())
            {
                List<Customer> customers = new List<Customer>
                {
                    customer
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            Order order = new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                Freight = 100.0,
                ShipAddress = "Ha Noi"
            };

            if (!context.Orders.Any())
            {
                List<Order> orders = new List<Order>
                {
                    order
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }


            if (!context.Accounts.Any())
            {
                List<Account> accounts = new List<Account>
                {
                    new Account { FullName = "Ha Huu Loc", Password = "123456", Username = "hahuuloc", Type = AccountType.Staff},
                    new Account { FullName = "Nguyen Phuoc Thanh", Password = "123456", Username = "thanh", Type = AccountType.Staff}
                };
                context.Accounts.AddRange(accounts);
                context.SaveChanges();
            }
        }
    }
}
