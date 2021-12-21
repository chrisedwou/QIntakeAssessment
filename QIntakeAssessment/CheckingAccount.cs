using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIntakeAssessment
{
    public class CheckingAccount : Account
    {
        public string Owner { get; set; }
        public double Balance { get; set; }
        public CheckingAccount (string owner, double balance)
        {
            Owner = owner;
            Balance = balance;
        }
    }

}
