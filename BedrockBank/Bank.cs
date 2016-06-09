using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{
    //Factory class
    public static class Bank
    {
        #region Variables
        public static BankModel db = new BankModel();
        #endregion

        public static Customer FindCustomer(string emailAddress)
        {
            if(string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("Email Address is empty");
            }
            return db.Customers.Where(
                c => c.CustomerEmail == emailAddress)
                .FirstOrDefault();
        }

        public static Customer CreateCustomer(string name, string emailAddress)
        {
            var customer = new Customer
            {
                CustomerName = name,
                CustomerEmail = emailAddress
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="accountName">Name for your account</param>
        /// <param name="ssn">Your social security number</param>
        /// <param name="typeOfAccount">The type of account</param>
        /// <returns>A new account</returns>
        public static Account CreateAccount(string accountName,
            int ssn,
            AccountType typeOfAccount, Customer customer)
        {
            var account = new Account
            {
                AccountName = accountName,
                SSN = ssn,
                TypeOfAccount = typeOfAccount,
                Customer = customer
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }


    }
}