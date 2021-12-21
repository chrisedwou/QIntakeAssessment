using NUnit.Framework;
using System.IO;
using System;
using QIntakeAssessment;
using System.Collections.Generic;

namespace QIntakeAssessmentTests
{
    public class Tests
    {
        private Bank _bank;
        [SetUp]
        public void Setup()
        {
            var accounts = new List<Account> {
                new IndividualInvestmentAccount("Chris Edwards", 500),
                new CorporateInvestmentAccount("Q-Intake", 5000),
                new CheckingAccount("Christopher Nedwards", 200.55),
                new IndividualInvestmentAccount("John Doe", 500),
                new CorporateInvestmentAccount("Amazon", 1000000),
                new CheckingAccount("Jane Doe", 500.45)
            };
            _bank = new Bank("First Bank", accounts);
        }
        [Test]
        public void InitializationConstructorTest()
        {
            Assert.That(_bank.Name == "First Bank");
            Assert.That(_bank.Accounts[0].Balance == 500);
            Assert.That(_bank.Accounts[2].Owner == "Christopher Nedwards");
        }
        [Test]
        public void TransferBetweenAccountsOfDifferentTypes()
        {
            _bank.Accounts[0].Transfer(100, _bank.Accounts[1]);
            Assert.AreEqual(400, _bank.Accounts[0].Balance);
            Assert.AreEqual(5100, _bank.Accounts[1].Balance);
        }
        [Test]
        public void TransferInvalidAmountShouldThrow()
        {
            Assert.That(()=>_bank.Accounts[0].Transfer(-100, _bank.Accounts[1]), Throws.Exception);
        }
        [Test]
        public void TransferInvalidIndividualInvestmentAccountAmountShouldThrow()
        {
            //Individual investment accounts can't withdraw more than $500. Should throw exception.
            Assert.That(() => _bank.Accounts[0].Transfer(600, _bank.Accounts[1]), Throws.Exception);
        }
        [Test]
        public void DepositValidAmountToAllThreeAccountTypes()
        {
            var PreviousAmount1 = _bank.Accounts[0].Balance;
            var PreviousAmount2 = _bank.Accounts[1].Balance;
            var PreviousAmount3 = _bank.Accounts[2].Balance;
            _bank.Accounts[0].Deposit(100);
            _bank.Accounts[1].Deposit(100);
            _bank.Accounts[2].Deposit(100);

            Assert.That(PreviousAmount1 == (_bank.Accounts[0].Balance - 100));
            Assert.That(PreviousAmount2 == (_bank.Accounts[1].Balance - 100));
            Assert.That(PreviousAmount3 == (_bank.Accounts[2].Balance - 100));
        }
        [Test]
        public void DepositInvalidAmountShouldThrow()
        {
            Assert.That(() => _bank.Accounts[1].Deposit(-100), Throws.Exception);
        }
        [Test]
        public void WithdrawValidAmountFromAllThreeAccountTypes()
        {
            var PreviousAmount1 = _bank.Accounts[0].Balance;
            var PreviousAmount2 = _bank.Accounts[1].Balance;
            var PreviousAmount3 = _bank.Accounts[2].Balance;
            _bank.Accounts[0].Withdraw(100);
            _bank.Accounts[1].Withdraw(1000);
            _bank.Accounts[2].Withdraw(100);

            Assert.That(PreviousAmount1 == (_bank.Accounts[0].Balance + 100));
            Assert.That(PreviousAmount2 == (_bank.Accounts[1].Balance + 1000));
            Assert.That(PreviousAmount3 == (_bank.Accounts[2].Balance + 100));
        }
        [Test]
        public void WithdrawInvalidAmountShouldThrow()
        {
            Assert.That(() => _bank.Accounts[1].Withdraw(-100), Throws.Exception);
        }
        [Test]
        public void WithdrawInvalidAmountFromIndividualInvestmentAccountShouldThrow()
        {
            Assert.That(() => _bank.Accounts[0].Withdraw(600), Throws.Exception);
        }
    }
}