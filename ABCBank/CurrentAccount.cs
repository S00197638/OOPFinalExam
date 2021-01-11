using System;

//CurrentAccount is inheriting from Account
namespace ABCBank
{
    public class CurrentAccount : Account
    {
        #region Properties

        public double InterestRate { get; }

        #endregion

        #region Constructors

        public CurrentAccount(string firstName, string lastName, int accountNumber) : base(firstName, lastName)
        {
            InterestRate = 0.03;
            AccountNumber = accountNumber;
        }

        public CurrentAccount(string firstName, string lastName) : base(firstName, lastName) { }

        public CurrentAccount() : base("Unknown", "Unknown") { }

        #endregion

        #region Methods

        public override string ToString()//Setting new ToString Method
        {
            return string.Format("{0} - {1}, {2}", AccountNumber,LastName.ToUpper(), FirstName);
        }

        public override decimal CalculateInterest()//Overriding and making use of abstract method
        {
            InterestDate = DateTime.Today;
            
            return Balance * (decimal)InterestRate;
        }

        #endregion
    }
}
