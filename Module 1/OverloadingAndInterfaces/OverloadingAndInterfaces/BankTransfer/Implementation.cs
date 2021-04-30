using System;
using System.Collections.Generic;
using System.Text;

namespace OverloadingAndInterfaces.BankTransfer
{
    // Oversimplified BankAccounts just to implement interfaces
    public class SaverAccount : IBankAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("Withdrawal attempt failed.");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public override string ToString()
        {
            return String.Format("Bank Saver: Balance = {0,6:C}", balance);
        }
    }
    public class CurrentAccount : ITransferBankAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            Console.WriteLine("Withdrawal attempt failed.");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public bool TransferTo(IBankAccount destination, decimal amount)
        {
            bool result;
            if ((result = Withdraw(amount)) == true)
                destination.PayIn(amount);
            return result;
        }
        public override string ToString()
        {
            return String.Format("Bank Current Account: Balance = {0,6:C}", balance);
        }
    }
}
