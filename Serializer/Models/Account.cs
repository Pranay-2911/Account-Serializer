using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Serializer.Models
{
   
    internal class Account
    {
        
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        const double MIN_BALANCE = 500;
        
        public Account(int accountId, string accountName, string bankName, double balance)
        { 
            AccountId = accountId;
            AccountName = accountName;
            BankName = bankName;
            if (balance < MIN_BALANCE)
            {
                Balance = MIN_BALANCE;
            }
            Balance = balance;
        }

        public void deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount >= MIN_BALANCE)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public double DisplayBalance()
        {
            return Balance;
        }


        public string PrintDetails()
        {
            return $"Account Id : {AccountId} \n" +
                $"Account holder Name : {AccountName} \n" +
                $"Bank Name : {BankName} \n" +
                $"Balance : {Balance}\n";
        }
        
    }
}
