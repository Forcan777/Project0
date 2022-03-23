using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Menus
    {
        public int MenuLandingDefault(ref ExHandle ExCheck)
        {
            int u_choice;                // user input value
            bool CheckSelectType = true; // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                            WELCOME TO THE EMPLOYEE MANAGEMENT SYSTEM!                            =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                   PLEASE SELECT THE FOLLOWING:                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. Login                                                      =");
                System.Console.WriteLine("=                                    2. Exit                                                       =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(2, 1);

                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 1 && u_choice <= 2)
                    CheckSelectType = false;

            } while (CheckSelectType);
            return u_choice;      
        }

        public Accounts MenuLogin(int securityCount)
        {
                Accounts User = new Accounts();

                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                              LOGIN                                               =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                            PLEASE ENTER YOUR USERNAME AND PASSWORD:                              =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("  Due to security measure, you have 5 tries to login. ");
                System.Console.WriteLine("");
                System.Console.WriteLine("  Try #" + securityCount);
                System.Console.Write("  Username : ");
                User.Username = System.Console.ReadLine();
                System.Console.Write("  Password : ");
                // User.Password = System.Console.ReadLine();
                // Password Hiding code block (from MSDN Example) - modified to show * in place of password as it's being entered
                string password = "";
                ConsoleKeyInfo info = Console.ReadKey(true);
                while (info.Key != ConsoleKey.Enter)
                {
                    if (info.Key != ConsoleKey.Backspace)
                    {
                        // Output * in place of the password entered
                        System.Console.Write("*");
                        password += info.KeyChar;
                        info = Console.ReadKey(true);
                    }
                    else if (info.Key == ConsoleKey.Backspace)
                    {   
                        
                        if (!string.IsNullOrEmpty(password))
                        {
                            // Remove previous character entered
                            password = password.Substring(0, password.Length - 1);
                            
                            // Cursor Movement
                            int pos = Console.CursorLeft;
                            // Move Cursor location to the previous location on the right
                            Console.SetCursorPosition(pos-1, Console.CursorTop);
                            // replace the cursor with a space
                            System.Console.Write(" ");
                            // Move Cursor again to the previous location on the right
                            Console.SetCursorPosition(pos-1, Console.CursorTop);
                        }
                        info = Console.ReadKey(true);
                    }
                }
                
                User.Password = password;

                return User;
        }
        public int MenuLandingAdministrator (ref ExHandle ExCheck)
        {
            int u_choice;                // user input value
            bool CheckSelectType = true; // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                   ACCESS LEVEL: ADMINISTRATOR                                    =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                   PLEASE SELECT THE FOLLOWING:                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. Create Employee Record                                     =");
                System.Console.WriteLine("=                                    2. Access Employee Record                                     =");
                System.Console.WriteLine("=                                    3. Delete Employee Record                                     =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. LOG OUT                                                    =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(3, 0);

                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 0 && u_choice <= 3)
                    CheckSelectType = false;

            } while (CheckSelectType);
            return u_choice;      
        }
        public int MenuLandingManager(ref ExHandle ExCheck)
        {
            int u_choice;                // user input value
            bool CheckSelectType = true; // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                     ACCESS LEVEL: MANAGER                                        =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                   PLEASE SELECT THE FOLLOWING:                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. View My Profile                                            =");
                System.Console.WriteLine("=                                    2. View Team Member                                           =");
                System.Console.WriteLine("=                                    3. Add Team Memeber                                           =");
                System.Console.WriteLine("=                                    4. Remove Team Memeber                                        =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. LOG OUT                                                    =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(4, 0);

                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 0 && u_choice <= 4)
                    CheckSelectType = false;

            } while (CheckSelectType);
            return u_choice;      
        }
        public int MenuLandingHR(ref ExHandle ExCheck)
        {
            int u_choice;                // user input value
            bool CheckSelectType = true; // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                   ACCESS LEVEL: HUMAN RESOURCE                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                   PLEASE SELECT THE FOLLOWING:                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. View My Profile                                            =");
                System.Console.WriteLine("=                                    2. View Employee Records                                      =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. LOG OUT                                                    =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(2, 0);

                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 0 && u_choice <= 2)
                    CheckSelectType = false;

            } while (CheckSelectType);
            return u_choice;      
        }
        public int MenuLandingDeveloper(ref ExHandle ExCheck)
        {
            int u_choice;                // user input value
            bool CheckSelectType = true; // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                     ACCESS LEVEL: DEVELOPER                                      =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                   PLEASE SELECT THE FOLLOWING:                                   =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. View My Profile                                            =");
                System.Console.WriteLine("=                                    2. View Team Records                                          =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. LOG OUT                                                    =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(2, 0);

                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 0 && u_choice <= 2)
                    CheckSelectType = false;

            } while (CheckSelectType);
            return u_choice;      
        }

        public int MenuCreateType(ref ExHandle ExCheck)
        {
            int u_choice;               // user input value
            bool CheckAccType = true;   // loop check
            do
            {
                
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                      - EMPLOYEE CREATION -                                       =");
                System.Console.WriteLine("=                                 PLEASE SELECT THE EMPLOYEE TYPE:                                 =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. Administrator                                              =");
                System.Console.WriteLine("=                                    2. Manager                                                    =");
                System.Console.WriteLine("=                                    3. Human Resource                                             =");
                System.Console.WriteLine("=                                    4. Developer                                                  =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. BACK                                                       =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                u_choice = ExCheck.InputExceptionCheck(4, 0);
                
                // If the input is valid, set the Loop Check to false to exit the loop.
                if (u_choice >= 0 && u_choice <= 4)
                    CheckAccType = false;

            } while (CheckAccType == true);

            return u_choice;   
        }


        public int MenuAccessLanding(ref ExHandle ExCheck)
        {
            int uChoice;               // user input value
            bool checkAccType = true;   // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                      - EMPLOYEE LISTING -                                        =");
                System.Console.WriteLine("=                         PLEASE SELECT THE METHOD FOR EMPLOYEE LOOKUP:                            =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. Employee ID                                                =");
                System.Console.WriteLine("=                                    2. Employee Department                                        =");
                System.Console.WriteLine("=                                    3. ALL                                                        =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. BACK                                                       =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                uChoice = ExCheck.InputExceptionCheck(3, 0);
                
                // If the input is valid, set the Loop Check to false to exit the loop.
                if (uChoice >= 0 && uChoice <= 3)
                    checkAccType = false;

            } while (checkAccType == true);

            return uChoice;               

        }
        public int MenuAccessType(ref ExHandle ExCheck)
        {
            int uChoice;               // user input value
            bool checkAccType = true;   // loop check
            do
            {
                System.Console.Clear();
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
                System.Console.WriteLine("====================================================================================================");
                System.Console.WriteLine("=                                      - EMPLOYEE LISTING -                                        =");
                System.Console.WriteLine("=                              PLEASE SELECT THE EMPLOYEE DEPARTMENT:                              =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    1. Administrator                                              =");
                System.Console.WriteLine("=                                    2. Manager                                                    =");
                System.Console.WriteLine("=                                    3. Human Resource                                             =");
                System.Console.WriteLine("=                                    4. Developer                                                  =");
                System.Console.WriteLine("=                                                                                                  =");
                System.Console.WriteLine("=                                    0. BACK                                                       =");
                System.Console.WriteLine("====================================================================================================");
                
                // calling local funtion to check for valid input.
                uChoice = ExCheck.InputExceptionCheck(5, 0);
                
                // If the input is valid, set the Loop Check to false to exit the loop.
                if (uChoice >= 0 && uChoice <= 5)
                    checkAccType = false;

            } while (checkAccType == true);

            return uChoice;               
        }

        public void MenuInputHeaderCreate()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                      - EMPLOYEE CREATION -                                       =");
            System.Console.WriteLine("                                                          ");
        }

        public void MenuInputHeaderAccess()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                      - EMPLOYEE LISTING -                                        =");
            System.Console.WriteLine("                                                          ");
        }
        public void MenuInputHeaderUpdate()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                      - EMPLOYEE UPDATING -                                       =");
            System.Console.WriteLine(" ");
        }
        public void MenuInputHeaderDelete()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                      - EMPLOYEE REMOVAL -                                        =");
            System.Console.WriteLine(" ");
        }
        public void MenuOutputAccess(ref List<Employee> empSearch)
        {
            int empCount = 0;
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                      - EMPLOYEE LISTING -                                        =");
            System.Console.WriteLine(" ");
            foreach(var temp in empSearch)
            {
                empCount++;
            }
            System.Console.WriteLine("  EMPLOYEE RECORDS FOUND : " + empCount);
            System.Console.WriteLine("----------------------------------------------------------------------------------------------------");
            // Set table column formatting
            string empTableColumns = String.Format("{0, -5} {1, -20} {2, -25} {3, -15} {4, -15} {5, -15}", "ID", "Name", "Email", "Salary", "Status", "Role");
            // Output column names
            System.Console.WriteLine($"{empTableColumns}");
            System.Console.WriteLine("----------------------------------------------------------------------------------------------------");
            // Output employee record from List array
            foreach (var emp in empSearch )
            {
                string empIdText = String.Format("{0}", emp.EmpNo);
                string empSalaryText = String.Format("{0}", emp.EmpSalary);
                string empDisplay = String.Format("{0, -5} {1, -20} {2, -25} {3, -15} {4, -15} {5, -15}", 
                    empIdText, emp.EmpName, emp.EmpEmail, empSalaryText, emp.EmpStatus, emp.EmpRole);
                System.Console.WriteLine($"{empDisplay}");      
            }
            // Pause in program to allow time to read output
            System.Console.WriteLine(" ");
            System.Console.WriteLine("  Please Press Any Key to Continue.");
            System.Console.ReadLine();
        }

        public bool MenuUpdates(ref ExHandle ExCheck)
        {
            int uChoice;
            bool checkLoop = true;   // loop check
            do
            {
                System.Console.WriteLine("  Do you want to update an Employee's information?");                    
                System.Console.WriteLine("");
                System.Console.WriteLine("       1. Yes ");
                System.Console.WriteLine("       2. No ");
                System.Console.WriteLine("");
                System.Console.Write("  User Choice  : ");         
                uChoice = ExCheck.InputExceptionCheck(2, 1);

                if (uChoice >= 1 && uChoice <= 2)
                    checkLoop = false;
            }
            while (checkLoop);

            if (uChoice == 1)
                return true;        // return true when user wants to update employee record
            else   
                return false;       // return false when user do not want to update employee record

        }

        public bool MenuUpdatesTeamAdd(ref ExHandle ExCheck)
        {
            int uChoice;
            bool checkLoop = true;   // loop check
            do
            {
                System.Console.WriteLine("  Do you want to add a developer to the team?");                    
                System.Console.WriteLine("");
                System.Console.WriteLine("       1. Yes ");
                System.Console.WriteLine("       2. No ");
                System.Console.WriteLine("");
                System.Console.Write("  User Choice  : ");         
                uChoice = ExCheck.InputExceptionCheck(2, 1);

                if (uChoice >= 1 && uChoice <= 2)
                    checkLoop = false;
            }
            while (checkLoop);

            if (uChoice == 1)
                return true;        // return true when user wants to update employee record
            else   
                return false;       // return false when user do not want to update employee record

        }
        public bool MenuUpdatesTeamRemoval(ref ExHandle ExCheck)
        {
            int uChoice;
            bool checkLoop = true;   // loop check
            do
            {
                System.Console.WriteLine("  Do you want to remove a developer from the team?");                    
                System.Console.WriteLine("");
                System.Console.WriteLine("       1. Yes ");
                System.Console.WriteLine("       2. No ");
                System.Console.WriteLine("");
                System.Console.Write("  User Choice  : ");         
                uChoice = ExCheck.InputExceptionCheck(2, 1);

                if (uChoice >= 1 && uChoice <= 2)
                    checkLoop = false;
            }
            while (checkLoop);

            if (uChoice == 1)
                return true;        // return true when user wants to update employee record
            else   
                return false;       // return false when user do not want to update employee record

        }

        public void MenuExitNotLoggedIn()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                             YOU WERE UNABLE TO LOG IN AFTER 5 TRIES                              =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                           THE EMPLOYEE MANAGEMETN SYSTEM WILL NOW EXIT                           =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                                             GOODBYE!                                             =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("====================================================================================================");

        }
        public void MenuExitLoggedIn()
        {
            System.Console.Clear();
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("==================================   EMPLOYEE MANAGEMENT SYSTEM   ==================================");
            System.Console.WriteLine("====================================================================================================");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                        THANK YOU FOR USING THE EMPLOYEE MANAGEMENT SYSTEM                        =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                                             GOODBYE!                                             =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("=                                                                                                  =");
            System.Console.WriteLine("====================================================================================================");

        }

    }

}