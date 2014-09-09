namespace InheritingEmployee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Linq;

    using NortwindDatabase;

    public class InheritingEmployee
    {
        static void Main()
        {
            // 08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                Employee employee = northwindDbContex.Employees.First(); ;

                foreach (var territory in employee.Territories)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }

            // 09. Create a method that places a new order in the Northwind database. The order should contain several order items. 
            // Use transaction to ensure the data consistency.
            northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                using (var dbContextTransaction = northwindDbContex.Database.BeginTransaction())
                {
                    try
                    {
                        northwindDbContex.Orders.Add(
                                    new Order
                                    {
                                        CustomerID = "ROMEY",
                                        EmployeeID = 4
                                    });
                        northwindDbContex.SaveChanges();

                        Order order = northwindDbContex
                                        .Orders
                                        .Where(o => o.CustomerID == "ROMEY" && o.EmployeeID == 4)
                                        .FirstOrDefault();

                        Console.WriteLine(order.CustomerID);
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}