using EFCoreTutorial.Models;
using System;
using System.Linq;

namespace EFCoreTutorial {
    class Program {

        static void Main(string[] args) {


            using (var db = new AppDbContext()) {

                     // similar to GetAllUsers
                var customers = db.Customers
                                 .Where(c => c.Active == true)
                                 .OrderBy(c => c.Name)
                                 .ToList();
                foreach (var customer in customers) {
                  //  Console.WriteLine(customer.Name);
                }

                      // similar to GetByPrimarKey
                var customer1 = db.Customers.Find(1); // Primary Key number 1
                //Console.WriteLine("PK 1 = " + customer1.Name);

                     // similar to insert customer
                var insCustomer = new Customer() {
                    Id = 0,
                    Name = "Skyline",
                    Active = true,
                    DateCreated = DateTime.Now
                };

                var hasName = db.Customers.Any(c => c.Name == "Skyline");
                if (!hasName) {
                    db.Customers.Add(insCustomer);
                }

                     // Similar to update user
                var skl = db.Customers.Find(11);
                skl.Name = "GoldStar";

                     // similar to Delete
                var kroger = db.Customers.FirstOrDefault(c => c.Name == "kroger");
                if (kroger != null) {
                    db.Customers.Remove(kroger);
                }


                        // add orders

                var order1 = new Order() {
                    Date = DateTime.Now,
                    Description = "Order 1.  5 boxes of supplies.",
                    Total = 2780,
                    CustomerId = 2,
                };
               // db.Orders.Add(order1);

                var order2 = new Order() {
                    Date = DateTime.Now,
                    Description = "New order for 10 boxes.",
                    Total = 1578,
                    CustomerId = 3
                };
                //db.Orders.Add(order2);

                var order3 = new Order() {
                    Date = DateTime.Now,
                    Description = "Monthly supply, 20 boxes.",
                    Total = 8500,
                    CustomerId = 6,
                };
               // db.Orders.Add(order3);

                var order4 = new Order() {
                    Date = DateTime.Now,
                    Description = "Reorder, 18 boxes.",
                    Total = 7940,
                    CustomerId = 8,
                };
               // db.Orders.Add(order4);

                var order5 = new Order() {
                    Date = DateTime.Now,
                    Description = "Samples, 2 boxes.",
                    Total = 1000,
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "CinFin").Id
                };
                // db.Orders.Add(order5);
                 //db.Orders.AddRange(new[] { order1, order2, order3 });


                            // List all orders by Customer ID
                var allOrders = db.Orders
                                 .OrderBy(c => c.CustomerId)
                                 .ToList();

                //allOrders.ForEach(o => Console.WriteLine(o));

                foreach (var order in allOrders) {

                   // Console.WriteLine(order);
                }

                        // Find orders for Primary Key 2

                var orderPK = db.Orders.Find(3);                                
               // Console.WriteLine(orderPK);

                        // All orders over 5000
                var ordOver5000 = db.Orders
                                    .Where(or => or.Total > 5000)
                                    .OrderByDescending(o => o.Total)
                                    .ToList();

                //ordOver5000.ForEach(o=> Console.WriteLine(o));


                         // Sum of all orders for 1 customer

                var customerName = "CinFIn";
                var ordersTotal = db.Orders
                                .Where(n => n.Customer.Name == customerName)
                                .Sum(o => o.Total);
                                
                Console.WriteLine($"Order total for {customerName} is: {ordersTotal:C}");


                db.SaveChanges();
            }
        }
    }
}

