using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIntakeAssessment
{
    public interface Account
    {
        public string Owner { get; set; }
        public double Balance { get; set; }

        public virtual void Withdraw(double amount) {
            CheckIfNegative(amount);
            Balance -= amount;
        }
        public void Transfer(double amount, Account destination)
        {
            CheckIfNegative(amount);
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public void Deposit(double amount)
        {
            CheckIfNegative(amount);
            Balance += amount;
        }
        private void CheckIfNegative(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Amount cannot be negative");
            }
        }
    }
}
