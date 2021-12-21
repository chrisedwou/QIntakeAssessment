using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIntakeAssessment
{
    public class IndividualInvestmentAccount : InvestmentAccount
    {
        public string Owner { get; set; }
        public double Balance { get; set; }
        public IndividualInvestmentAccount(string owner, double balance)
        {
            Owner = owner;
            Balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Amount cannot be negative");
            }
            if (amount <= 500)
            {
                Balance -= amount;
            }
            else throw new Exception("Withdrawl ammount greater than the $500 dollar limit for Individual Investment Accounts");
        }
    }
}
