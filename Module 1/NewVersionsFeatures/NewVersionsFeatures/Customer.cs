using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;

namespace NewVersionsFeatures
{
    public class Customer
    {
        public Customer(int purchases, string name, int id)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerId = id;
        }

        // Auto property 
        public int TotalPurchases { get; set; } = 0;
        public string Name { get; set; }
        public int CustomerId { get; set; }

        private string Address;

        //optional parameters + string interpolation + nameof
        public static void GetPurchaseInfo(int id, string name = "groceries")
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));
            Console.WriteLine($"Customer #{id} bought {name}.");
        }

        //null conditional operator
        public void GetCustomerAddress()
        {
            Console.WriteLine(Address ?? "No address");
        }

        //expression-bodied members (only if it consists of single expression)
        public string GetTransactionHistory() => "History";
        
        public static int CountOverallPurchases(object obj)
        {
            int sum = 0;
            //local functions + pattern matching
            void SumIfCustomer()
            {
                if (obj is Customer customer)
                    sum += customer.TotalPurchases;
            }

            return sum;
        }
    }
}