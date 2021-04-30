using System;

namespace NewVersionsFeatures
{
    internal class Program
    {
        private static void Main(string[] args)
        { 
            //out variable + pattern matching
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");

            //tuple
            int foundationOrder = 5;
            string state = "Connecticut";
            var pair = (foundationOrder, state); //better for mupltiple return from method

            Customer customer = new Customer(10, "John", 1);
            Customer.GetPurchaseInfo(1);
            //Customer.GetPurchaseInfo(0); exception with nameof
            //named arguments
            Customer.GetPurchaseInfo(name: "clothes", id: 1);
            
            customer.GetCustomerAddress();
            
            Console.WriteLine(Customer.CountOverallPurchases(customer));

            // Dynamic variables 
            dynamic value = 123234;
            Console.WriteLine("The actual type of value: {0}", value.GetType().ToString());

            //exception filter
            try
            {
                throw new Exception("ErrorType1");
            }
            catch (Exception ex) when (ex.Message == "ErrorType1")
            {
                Console.WriteLine("Error Message : " + ex);
            }
            catch (Exception ex) when (ex.Message == "ErrorType2")
            {
                Console.WriteLine("Error Message : " + ex);
            }
        }
    }
}