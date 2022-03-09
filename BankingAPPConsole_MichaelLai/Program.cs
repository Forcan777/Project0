using System;

namespace BankingAPPConsole_MichaelLai
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            bool bankingAppActive = true;       // boolean variable used to check if banking app is active or if user will exit
            int userSelection;
            Accounts userAccount = new Accounts();

            //Main program section
            do
            {
                #region Banking App Menu
                Console.Clear();    //clear screen
                System.Console.WriteLine("========== BANKING APP V0.1 ==========");
                System.Console.WriteLine("Please select from the following:");
                System.Console.WriteLine("  1. Open New Account");
                System.Console.WriteLine("  2. Check Balance");
                System.Console.WriteLine("  3. Withdraw");
                System.Console.WriteLine("  4. Deposit");
                System.Console.WriteLine("  5. Account Detail");
                System.Console.WriteLine("  6. Exit");
                userSelection = Convert.ToInt32(System.Console.ReadLine());
                #endregion

                //User Choices
                switch (userSelection)
                {
                    #region 1. Account Creation
                    case 1: //Creating User Bank Account by inputing information
                            userAccount.accNo = 001;
                            userAccount.accIsActive = true;
                            System.Console.WriteLine("Please enter your name:");
                            userAccount.accName = Console.ReadLine();
                            System.Console.WriteLine("Please enter your account type:");
                            userAccount.accType = Console.ReadLine();
                            System.Console.WriteLine("Please enter your email address:");
                            userAccount.accEmail = Console.ReadLine();
                            System.Console.WriteLine("Please enter your starting balance:");
                            userAccount.accBalance = Convert.ToDouble(Console.ReadLine());
                            break;
                    #endregion
                    
                    #region 2. Check Account Balance
                    case 2: //Checking Account balance and display on screen
                            System.Console.WriteLine("The account balance is: $" + userAccount.CheckBalance());
                            break;
                    #endregion
                    
                    #region 3. Account Withdraw
                    case 3:
                            System.Console.WriteLine("Please enter the amount you wish to withdraw: ");
                            double amtWithdraw = Convert.ToDouble(Console.ReadLine());
                            userAccount.Withdraw(amtWithdraw);
                            System.Console.WriteLine("Withdraw completed.");
                            break;
                    #endregion

                    #region 4. Account Deposit
                    case 4:
                            System.Console.WriteLine("Please enter the amount you wish to deposit: ");
                            double amtDeposit = Convert.ToDouble(Console.ReadLine());
                            userAccount.Deposit(amtDeposit);
                            System.Console.WriteLine("Deposit Completed.");
                            break;
                    #endregion

                    #region 5. Account Detail
                    case 5:
                            userAccount.getAccountInfo();
                            break;
                    #endregion

                    #region 6. Exit
                    case 6:
                            System.Console.WriteLine("Thank you for using our BANKING APP !!!");
                            bankingAppActive = false;
                            break;
                    #endregion

                    #region Invalid Choice Selection
                    default:
                            System.Console.WriteLine("Invalid choice.");
                            break;
                    #endregion
                }

                //A pause in program so it will display all necessary text from each cases above.
                System.Console.WriteLine("Please Press Enter to Continue!");  
                Console.ReadLine();

            }while (bankingAppActive);

        }
    }
}
