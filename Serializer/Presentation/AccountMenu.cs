using Serializer.Controller;
using Serializer.Exceptions;
using Serializer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Presentation
{
    internal class AccountMenu
    {

        static AccountManager manager = new AccountManager();
        public static void GetAccountMenu()
        {
            
            Console.WriteLine("Welcome ! Enter Account Details to create a new Account");
            Console.WriteLine();

            if (manager.ToCheckFile())
            {

                Console.WriteLine("Account loaded successfully.");
                Console.WriteLine();
            }
            else
            {

                Console.WriteLine("How Many account u want to enter");
                int count = int.Parse(Console.ReadLine());
                
                Console.WriteLine("ACCno\n" +
                "AccName\n" +
                "BankName\n" +
                "Opeaning Balance\n");
                Console.WriteLine();
                manager.AddAccount(count);
            }

            bool check1 = true;


            while (check1)
            {
                Console.WriteLine("Enter the AccountID  to access the account");

                manager.ToShowAccount(); 
                Console.WriteLine();
                Console.WriteLine("Enter the ID for above account to get access");
                Console.WriteLine();
                int accountID = int.Parse(Console.ReadLine());
                int accountIndex = 0;
                try
                {
                    if (manager.ToFindAccount(accountID, ref accountIndex))
                    {
                        TocheckAccount(ref accountIndex, ref check1);
                    }
                    else
                    {
                        throw new InvalidAccountIdException("NO account found");
                    }
                }
                catch (InvalidAccountIdException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
        }

        static void TocheckAccount(ref int accountIndex, ref bool check1)
        {

            Operation(accountIndex);


            Console.WriteLine("Press 1 to change account \n" +
                "Press 0 to exit");
            int exit = int.Parse(Console.ReadLine());



            check1 = manager.ToSerializer(exit);

            if (!check1)
            {
                Console.WriteLine("Sussessfully saved");
            }
        }
        static void Operation(int accountIndex)
        {
            bool check2 = true;
            while (check2)
            {

                Console.WriteLine("Menu");
                Console.WriteLine("1. Deposit Account\n" +
                        "2. Withdraw ammount\n" +
                        "3. show balance\n" +
                        "4. Get Account Details\n" +
                        "5 Exit");
                Console.WriteLine();

                int choice = int.Parse(Console.ReadLine());
                SwitchCases(choice, accountIndex, ref check2);


            }
        }

        static void SwitchCases(int choice, int accountIndex, ref bool check2)
        {
            switch (choice)
            {
                case 1:
                    DepositAccount(accountIndex);
                    break;
                case 2:
                    Withdraw(accountIndex);
                    break;
                case 3:
                   DisplayBalance(accountIndex);
                    break;
                case 4:
                   Print(accountIndex);
                    break;
                case 5:

                    check2 = false;
                    Console.WriteLine("Exiting");
                    Console.WriteLine();

                    break;

            }
        }

        static void DepositAccount(int accountIndex)
        {
            Console.WriteLine("Enter amount to deposit");
            double amount = double.Parse(Console.ReadLine());
            manager.GetAccount(accountIndex).deposit(amount);
            Console.WriteLine();
        }

        static void Withdraw(int accountIndex)
        {
            Console.WriteLine("Enter amount to WithDraw");
            double withDrawAmount = double.Parse(Console.ReadLine());
            try
            {


                if (manager.GetAccount(accountIndex).Withdraw(withDrawAmount))
                {
                    Console.WriteLine("Amount witdraw sussesfully");

                }
                else
                {
                    throw new InsufficientBalanceException("Insufficient Balance to withdraw");
                }
            }
            catch (InsufficientBalanceException isuf)
            {
                Console.WriteLine(isuf.Message);
            }
            Console.WriteLine();

        }

        static void DisplayBalance(int accountIndex)
        {
            Console.WriteLine("Your balance is " + manager.GetAccount(accountIndex).DisplayBalance());
            Console.WriteLine();
        }

        static void Print(int accountIndex)
        {
            Console.WriteLine("Account detail");
            Console.WriteLine(manager.GetAccount(accountIndex).PrintDetails());
            Console.WriteLine();
        }
    }
}
