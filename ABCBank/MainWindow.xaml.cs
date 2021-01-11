using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABCBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region GitHub Link

        //https://github.com/S00197638/OOPFinalExam

        #endregion

        #region Lists

        List<Account> accounts = new List<Account>();//List of all accounts
        List<Account> filteredAccounts = new List<Account>();//List used to filter accounts

        #endregion

        #region Setup

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Create Initial Accounts
            CreateInitialAccounts();

            //Set CheckBoxes
            ckbxCurrentAcc.IsChecked = true;
            ckbxSavingsAcc.IsChecked = true;

            //Check what checkboxes are checked
            CkBxIsChecked();
        }

        private void CreateInitialAccounts()
        {
            //Create New Employees
            CurrentAccount cAcc1 = new CurrentAccount("Leopold", "Fitz", 443267);
            CurrentAccount cAcc2 = new CurrentAccount("Gemma", "Simmons", 675894);
            SavingsAccount sAcc1 = new SavingsAccount("Grant", "Ward", 895083);
            SavingsAccount sAcc2 = new SavingsAccount("Daisy", "Johnson", 234157);

            //Add Employees To List
            accounts.Add(cAcc1);
            accounts.Add(cAcc2);
            accounts.Add(sAcc1);
            accounts.Add(sAcc2);
        }

        #endregion

        #region Filtering

        private void CkBxIsChecked()//Filtering Check
        {
            if (ckbxCurrentAcc.IsChecked == true && ckbxSavingsAcc.IsChecked == true)//List all Employees in alphabetical order
            {
                accounts.Sort();
                lbxAccountsList.ItemsSource = accounts;
            }
            else if (ckbxCurrentAcc.IsChecked == true && ckbxSavingsAcc.IsChecked == false)//List all FullTime Employees in alphabetical order
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is CurrentAccount)
                        filteredAccounts.Add(account);
                }

                filteredAccounts.Sort();
                lbxAccountsList.ItemsSource = filteredAccounts;
            }
            else if (ckbxSavingsAcc.IsChecked == true && ckbxCurrentAcc.IsChecked == false)//List all PartTime Employees in alphabetical order
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is SavingsAccount)
                        filteredAccounts.Add(account);
                }

                filteredAccounts.Sort();
                lbxAccountsList.ItemsSource = filteredAccounts;
            }
            else if (ckbxCurrentAcc.IsChecked == false && ckbxSavingsAcc.IsChecked == false)//Show no Employees
            {
                lbxAccountsList.ItemsSource = null;
            }
        }

        private void ckbxCurrentAcc_Checked(object sender, RoutedEventArgs e)//Checking for change in state of the checkbox
        {
            CkBxIsChecked();
        }

        private void ckbxCurrentAcc_Unchecked(object sender, RoutedEventArgs e)//Checking for change in state of the checkbox
        {
            CkBxIsChecked();
        }

        private void ckbxSavingsAcc_Checked(object sender, RoutedEventArgs e)//Checking for change in state of the checkbox
        {
            CkBxIsChecked();
        }

        private void ckbxSavingsAcc_Unchecked(object sender, RoutedEventArgs e)//Checking for change in state of the checkbox
        {
            CkBxIsChecked();
        }

        #endregion

        #region Selection Display

        private void lbxAccountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)//Change of selection in listbox
        {
            Account selectedAccount = lbxAccountsList.SelectedItem as Account;//Saving the Data of selected Account in another account object

            if (selectedAccount != null)//Making sure an account is selected
            {
                //Setting the fields on the right of the display to the selected account's data
                tblkFirstName.Text = selectedAccount.FirstName;
                tblkLastName.Text = selectedAccount.LastName;
                //Reseting Backgrounds to White, in case they are not
                tblkFirstName.Background = Brushes.White;
                tblkLastName.Background = Brushes.White;
                if (selectedAccount is CurrentAccount)
                {
                    CurrentAccount temp = (CurrentAccount)selectedAccount;
                    tblkBalance.Text = temp.Balance.ToString();
                    tblkAccountType.Text = "Current Account";
                    tblkInterestDate.Text = temp.InterestDate.ToString();
                }
                else
                {
                    SavingsAccount temp = (SavingsAccount)selectedAccount;
                    tblkBalance.Text = temp.Balance.ToString();
                    tblkAccountType.Text = "Savings Account";
                    tblkInterestDate.Text = temp.InterestDate.ToString();
                }
            }
        }

        #endregion

        #region Interactions

        private void tbxTransactionAmount_GotFocus(object sender, RoutedEventArgs e)//Clearing Field
        {
            tbxTransactionAmount.Clear();
            tbxTransactionAmount.Background = Brushes.White;
        }

        #endregion

        #region Reset Menu

        private void ResetMenuToDefault()//Reset Menu Display back to Default Text
        {
            tblkFirstName.Text = "First Name...";
            tblkLastName.Text = "Last Name...";
            tblkBalance.Text = "Balance...";
            tblkAccountType.Text = "Account Type...";
            tblkInterestDate.Text = "Interest Date...";
            tbxTransactionAmount.Text = "Transaction Amount...";
            //Reseting Backgrounds to White, in case they are not
            tblkFirstName.Background = Brushes.White;
            tblkLastName.Background = Brushes.White;
            //Deselecting
            lbxAccountsList.SelectedItem = null;
        }

        #endregion

    }
}
