using System;

namespace ABCBank
{
    public abstract class Account
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance { get; set; }

        public DateTime InterestDate { get; set; }

        public int AccountNumber { get; set; }

        #endregion

        #region Constructors

        public Account(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        #region Methods

        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }
        
        public abstract decimal CalculateInterest();//Abstract method, that child classes can override

        //public int CompareTo(object otherObject)//To list the employees alphabetically
        //{
        //    Employee temp = (Employee)otherObject;
        //    int returnValue = this.LastName.CompareTo(temp.LastName);//Sort by LastName

        //    if (returnValue == 0)
        //        returnValue = this.FirstName.CompareTo(temp.FirstName);//If LastName is the same, Sort by FirstName

        //    return returnValue;
        //}

        #endregion
    }
}
