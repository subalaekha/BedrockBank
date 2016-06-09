using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********Welcome to Bedrock bank*********");
            string option;
            Customer customer;
            do
            {
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit into an account");
                Console.WriteLine("3. Print accounts");
                Console.WriteLine("0. Exit");

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        try
                        {
                            customer = VerifyCustomer();
                            Console.Write("What is the name of the account? ");
                            var accountName = Console.ReadLine();

                            Console.WriteLine("what type of account do you need");
                            Console.WriteLine("1.Checking");
                            Console.WriteLine("1.Savings");
                            var typeOfAccount = Console.ReadLine();
                            AccountType accountType = AccountType.Savings;
                            if(typeOfAccount == "1")
                            {
                                accountType = AccountType.Checking;
                            }

                            var account1 = Bank.CreateAccount(accountName, 12342,
                                AccountType.Checking, customer);
                            Console.WriteLine("Account Name: {0}, Number: {1}, Type of account: {2}, Balance: {3:c}",
                                account1.AccountName, account1.AccountNumber, account1.TypeOfAccount, account1.Balance);
                        }
                        catch (DbEntityValidationException dx)
                        {
                            Console.WriteLine("Failed creating an account - {0}", dx.Message);
                        }
                        catch(ArgumentNullException ax)
                        {
                            Console.WriteLine("Failed - {0}", ax.ParamName );
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;

                    case "2":
                        customer = VerifyCustomer();
                        break;

                    case "3":
                        customer = VerifyCustomer();
                        //PrintAccounts();
                        break;

                    case "0":
                        Console.WriteLine("Good bye!");
                        return;

                    default:
                        break;
                }
            } while (option != "0");


        }

        private static Customer VerifyCustomer()
        {
            Console.Write("What is your email address? ");
            var emailAddress = Console.ReadLine();

            var customer = Bank.FindCustomer(emailAddress);
            if (customer == null)
            {
                Console.Write("What is your name? ");
                var name = Console.ReadLine();

                customer = Bank.CreateCustomer(name, emailAddress);
            }

            return customer;
        }

        //static void PrintAccounts()
        //{
        //    foreach (var account in Bank.accounts)
        //    {
        //        Console.WriteLine("Id: {0}, Name: {1}",
        //            account.AccountNumber, account.AccountName);
        //    }
        //}
    }
}