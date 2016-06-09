using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    

namespace BedrockBank
{
    public class Customer
    {
        [key]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public virtual ICollection<Account>  Accounts { get; set; }
    }
}
