﻿using System;

namespace ABCBank
{
    public abstract class Account : IComparable
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

        public decimal Deposit(double amount)
        {
            return Balance += (decimal)amount;
        }

        public decimal Withdraw(double amount)
        {
            return Balance -= (decimal)amount;
        }
        
        public abstract decimal CalculateInterest();//Abstract method, that child classes can override

        public int CompareTo(object otherObject)//To list the employees alphabetically
        {
            Account temp = (Account)otherObject;
            int returnValue = this.LastName.CompareTo(temp.LastName);//Sort by LastName

            if (returnValue == 0)
                returnValue = this.FirstName.CompareTo(temp.FirstName);//If LastName is the same, Sort by FirstName

            return returnValue;
        }

        #endregion
    }
}
