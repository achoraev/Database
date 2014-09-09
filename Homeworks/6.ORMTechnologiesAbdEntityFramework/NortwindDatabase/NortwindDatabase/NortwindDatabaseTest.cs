namespace NortwindDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NortwindDatabaseTest
    {
        public static void Main()
        {
            //02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
            NortwindDatabase.InsertCustomer("PESHO", "Telerik Academy");
            NortwindDatabase.UpdateCustomer("PESHO", "GOSHO");
            NortwindDatabase.DeleteCustomer("PESHO");

            //03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            NortwindDatabase.FindCustomersWithOrdersFrom1997FromCanada();

            //04. Implement previous by using native SQL query and executing it through the DbContext.
            NortwindDatabase.FindCustomersWithOrdersFrom1997ToCanadaNativeSQL();

            //05. Write a method that finds all the sales by specified region and period (start / end dates).
            NortwindDatabase.FindSalesByRegionAndPeriod("RJ", "1995-01-01", "1999-09-12");
        }
    }
}