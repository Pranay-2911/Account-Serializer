using Serializer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serializer.Controller
{
    internal class AccountManager
    {
        Account[] account;

        public bool ToCheckFile()
        {
            var filePath = ConfigurationManager.AppSettings["MyPath"].ToString();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                account = JsonSerializer.Deserialize<Account[]>(jsonData);
                return true;
            }
            return false;
        }

        public void AddAccount(int count)
        {
            account = new Account[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter account id");
                int accId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter account holder name");
                string accName = Console.ReadLine();
                Console.WriteLine("Enter bank name");
                string bankName = Console.ReadLine();
                Console.WriteLine("Enter the balnce");
                double balance = double.Parse(Console.ReadLine());
                account[i] = new Account(accId, accName, bankName, balance);
                Console.WriteLine(); 
            }
        }

        public void ToShowAccount()
        {
            Console.WriteLine();

            for (int i = 0; i < account.Length; i++)
            {
                Console.WriteLine($"{i + 1}  {account[i].AccountName}");
            }
        }

        public Account GetAccount(int index)
        {
            return  account[index];
        }

        public bool ToSerializer(int exit)
        {
            var filePath = ConfigurationManager.AppSettings["MyPath"].ToString();
            if (exit == 0)
            {

                string jsonData = JsonSerializer.Serialize(account);
                File.WriteAllText(filePath, jsonData);

                return false;
            }


            return true;
        }


        public bool ToFindAccount(int accountId, ref int accountIndex)
        {

            for(int i = 0; i<account.Length; i++)
            {
                if(account[i].AccountId == accountId)
                {
                    accountIndex = i;
                    return true;
                }
            }
            return false;
        }

        public string GetAccountHolderName(int accountIndex)
        {
            return account[accountIndex].AccountName;
        }
    }
}
