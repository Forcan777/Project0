using System;

class Accounts
{
    #region Account Properties
    public int accNo{ get; set; }           // account number property
    public string accName { get; set; }     // account name property
    public string accEmail { get; set; }    // account email property
    public string accType { get; set; }     // account type property
    public double accBalance { get; set; }  // account balance property
    public bool accIsActive { get; set; }   // account account active property
    #endregion

    #region Account Methods - Withdraw
    public double Withdraw(double w_amount)     //Method for withdraw from account
    {
        accBalance = accBalance - w_amount;
        return accBalance;
    }
    #endregion

    #region Account Methods - Deposit
    public double Deposit(double d_amount)         //Method for deposit to account
    {
        accBalance = accBalance + d_amount;
        return accBalance;
    }
    #endregion

    #region Account Methods - Check Balance
    public double CheckBalance()                //Method to return the balance value
    {
        return accBalance;
    }
    #endregion

    #region Account Methods - Get Account Information
    public void getAccountInfo()                //Method to print account information
    {
        System.Console.WriteLine("Account No: " + accNo);
        System.Console.WriteLine("      Name: " + accName);
        System.Console.WriteLine("     Email: " + accEmail);
        System.Console.WriteLine("      Type: " + accType);
        System.Console.WriteLine("   Balance: " + accBalance);
    }
    #endregion

}