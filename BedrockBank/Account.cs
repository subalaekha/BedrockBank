using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockBank
{

    public enum AccountType
    {
        Savings,
        Checking,
        CD,
        Loans
    }

    /// <summary>
    /// This is about a 
    /// bank account
    /// </summary>
    public class Account
    {
        #region Variables
        private static int lastAccountNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Account number for the account
        /// </summary>
        [Key]
        public int AccountNumber { get; private set; }
        /// <summary>
        /// Name of the account
        /// </summary>
        [StringLength(10, ErrorMessage = "Account name must be less than 10 characters in length")]
        public string AccountName { get; set; }
        public int SSN { get; set; }
        public double Balance { get; private set; }

        public AccountType TypeOfAccount { get; set; }

        public virtual Customer Customer { get; set; }
        #endregion

        #region Constructor
        public Account()
        {
            //++lastAccountNumber;
            //AccountNumber = lastAccountNumber;
            AccountNumber = ++lastAccountNumber;
        }
        #endregion

        #region Methods

        public double Deposit(double amount)
        {
            //Balance = Balance + amount;
            Balance += amount;
            return Balance;
        }

        #endregion
    }
}