using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIntakeAssessment
{
    public class CorporateInvestmentAccount : InvestmentAccount
    {
        public string Owner { get; set; }
        public double Balance { get; set; }
        public CorporateInvestmentAccount(string owner, int balance)
        {
            Owner = owner;
            Balance = balance;
        }
    }
}
