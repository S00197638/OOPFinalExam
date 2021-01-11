using System;

//SavingsAccount is inheriting from Account
namespace ABCBank
{
    public class SavingsAccount : Account
    {
        #region Properties

        public double InterestRate { get; }

        #endregion

        #region Constructors

        public SavingsAccount(string firstName, string lastName, int accountNumber) : base(firstName, lastName)
        {
            InterestRate = 0.06;
            AccountNumber = accountNumber;
        }

        public SavingsAccount(string firstName, string lastName) : base(firstName, lastName) { }

        public SavingsAccount() : base("Unknown", "Unknown") { }

        #endregion

        #region Methods

        public override string ToString()//Setting new ToString Method
        {
            return string.Format("{0} - {1}, {2}", AccountNumber, LastName.ToUpper(), FirstName);
        }

        public override decimal CalculateInterest()//Overriding and making use of abstract method
        {
            InterestDate = DateTime.Today;

            return Balance * (decimal)InterestRate;
        }

        #endregion
    }
}
