namespace NortwindDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NortwindDatabase
    {
        public static void FindSalesByRegionAndPeriod(string region, string startDate = null, string endDate = null)
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                DateTime startDateDt = Convert.ToDateTime(startDate);
                DateTime endDateDt = Convert.ToDateTime(endDate);

                var salesByRegionAndPeriod = northwindDbContex
                                            .Orders
                                            .Where(o => o.ShipRegion == region &&
                                                    o.OrderDate >= startDateDt && o.OrderDate <= endDateDt)
                                            .GroupBy(o => o.ShipName);

                foreach (var item in salesByRegionAndPeriod)
                {
                    Console.WriteLine(item.Key);
                }

            }
        }

        public static void InsertCustomer(string customerId, string companyName, string contactName = null,
            string contactTitle = null, string address = null, string city = null, string region = null,
            string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                Customer newCustomer = new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                northwindDbContex.Customers.Add(newCustomer);
                northwindDbContex.SaveChanges();
                Console.WriteLine("1 row affected.");
            }

        }

        public static void UpdateCustomer(string customerId, string companyName, string contactName = null,
            string contactTitle = null, string address = null, string city = null, string region = null,
            string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                Customer customer = northwindDbContex.Customers.First(c => c.CustomerID == customerId);

                customer.CompanyName = companyName ?? customer.CompanyName;
                customer.ContactName = contactName ?? customer.ContactName;
                customer.ContactTitle = contactTitle ?? customer.ContactTitle;
                customer.Address = address ?? customer.Address;
                customer.City = city ?? customer.City;
                customer.Region = region ?? customer.Region;
                customer.PostalCode = postalCode ?? customer.PostalCode;
                customer.Country = country ?? customer.Country;
                customer.Phone = phone ?? customer.Phone;
                customer.Fax = fax ?? customer.Fax;

                northwindDbContex.SaveChanges();
                Console.WriteLine("1 row affected.");
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                Customer customer = northwindDbContex.Customers.First(c => c.CustomerID == customerId);

                northwindDbContex.Customers.Remove(customer);
                northwindDbContex.SaveChanges();

                Console.WriteLine("1 row removed.");
            }
        }

        public static void FindCustomersWithOrdersFrom1997FromCanada()
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            using (northwindDbContex)
            {
                var customers = northwindDbContex.Orders
                                                    .Where(o => o.OrderDate.Value.Year == 1997 &&
                                                        o.ShipCountry == "Canada")
                                                    .GroupBy(o => o.Customer.CompanyName)
                                                    .ToList();

                northwindDbContex.SaveChanges();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Key);
                }
            }
        }

        public static void FindCustomersWithOrdersFrom1997ToCanadaNativeSQL()
        {
            NORTHWNDEntities northwindDbContex = new NORTHWNDEntities();

            string querySql = "SELECT c.CompanyName FROM Orders o " +
                              "JOIN Customers c ON c.CustomerID  = o.CustomerID " +
                              "WHERE YEAR(o.OrderDate) = 1997 And o.ShipCountry = 'Canada' " +
                              "GROUP BY c.CompanyName";

            var customers = northwindDbContex.Database.SqlQuery<string>(querySql);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

    }
} 