using System;
using System.Collections.Generic;


namespace EmployeeManagementSystem
{
    class Program
    {
        #region Main Program
        static void Main(string[] args)
        {
            // Variable list
            bool programRunning = true; // Variable used to check if the user is still using the program.
            bool loggedIn = false;      // Variable used to check if user has logged into the program
            bool logOut;                // Variable used to check if user has logged out of the program
            bool failedLogIn = false;   // Variable used to check if user has failed to logged into the program
            int userChoice;             // Variable used to store user selection choices to be pass to the methods for any operational functions.
            int actChoice;              // Variable used to store user choices from sub menus.
            int loggedActId;            // Variable used to store user account's employee ID
            
            // Class Objects
            ServerAction ServeActions = new ServerAction(); // Class object used to access all necessary operational functions (CRUD operations) of the program
            ExHandle InputCheck = new ExHandle();           // Class Object used for Exception Handling method
            Menus ObjMenus = new Menus();                   // Class object used to access all necessary menus (landing page and selections)
            MenuAction MenuAction = new MenuAction();       // Class object used to perform actions behind meneu selections.
            Accounts LoginUser = new Accounts();            // Class object used to deal with login operation
            
            // Program Menu Loop
            do 
            {  
                // Main Program Landing Page
                userChoice = ObjMenus.MenuLandingDefault(ref InputCheck);

                // Check to see if user wants to log in
                if (userChoice == 1)
                {
                    // Login Menu check
                    for (int x = 1; x <= 5; x++)
                    {
                        if (loggedIn == false)
                        {
                            // MenuLogin will return username and password that user has entered
                            LoginUser = ObjMenus.MenuLogin(x);

                            // Check the login using user-entered account with Database
                            loggedIn = MenuAction.CheckLogin(ref LoginUser, ref ServeActions);
                        }   
                    }
                    
                    // User Logged In
                    if(loggedIn)
                    {
                        logOut = false;     // Set logOut to false as user just logged in
                        while (logOut == false)
                        {
                            // User Department Landing Page Check
                            loggedActId = ServeActions.ReadId(ref LoginUser);
                            List<Employee> ObjTemp = new List<Employee>();  // Class object used to deal with employee database records
                            ServeActions.Read(loggedActId, ref ObjTemp);
                            int loggedRoleCase = 0;
                            if (ObjTemp[0].EmpUserAccLevel == "A")
                                loggedRoleCase = 1;
                            else if (ObjTemp[0].EmpUserAccLevel == "M")
                                loggedRoleCase = 2;
                            else if (ObjTemp[0].EmpUserAccLevel == "H")
                                loggedRoleCase = 3;
                            else if (ObjTemp[0].EmpUserAccLevel == "D")
                                loggedRoleCase = 4;

                            switch (loggedRoleCase)
                            {
                                case 1:
                                    // Calling Menu Landing Page - Administrator
                                    int adminChoice = ObjMenus.MenuLandingAdministrator(ref InputCheck);
                                    // Change Menu and perform Menu Actions based on user selection
                                    switch (adminChoice)
                                    {
                                        // Case 1 - Creating new employee entry
                                        case 1:
                                            actChoice = ObjMenus.MenuCreateType(ref InputCheck);
                                            if (actChoice != 0)
                                                MenuAction.EmpCreation(ref ObjMenus, ref ServeActions, actChoice, ref InputCheck);            
                                            break;
                                        // Case 2 - Accessing old employee entries based on ID, Department, or All
                                        case 2:
                                            actChoice = ObjMenus.MenuAccessLanding(ref InputCheck);
                                            bool actUpdates = false;
                                            if (actChoice != 0)
                                            {
                                                // Accessing employee record(s)
                                                MenuAction.EmpAccess(ref ObjMenus, ref ServeActions, actChoice, ref InputCheck);
                                                // Check if user wants to update an employee's record
                                                actUpdates = MenuAction.EmpUpdates(ref ObjMenus, ref InputCheck);
                                                if (actUpdates)
                                                {
                                                    // Do this when user wants to update employee record
                                                    MenuAction.EmpUpdating(ref ObjMenus, ref ServeActions, ref InputCheck);
                                                }
                                            }
                                            break;
                                        // Case 3 - Deleting old employee entries based on ID
                                        case 3:
                                            MenuAction.EmpDeletion(ref ObjMenus, ref ServeActions, ref InputCheck);
                                            break;
                                        // Case 0 - Log off
                                        case 0:
                                            logOut = true;
                                            loggedIn = false;
                                            break;
                                        // NOTE: There is no default case due to exception handling of user input
                                        // FUTURE FUNCTIONALITIES FOR ADMIN TYPE EMPLOYEE:
                                        // - LOGIN UPDATE
                                        // - Request/Recommandation - to MANAGER, and ADMIN
                                        // - Feedback - to DEV and HR
                                        // - Complain/Resolution - Anonymous - to EVERYONE
                                    }
                                    break;
                                case 2:
                                    // Calling Menu Landing Page - Manager
                                    int manaChoice = ObjMenus.MenuLandingManager(ref InputCheck);
                                    // Change Menu and perform Menu Actions based on user selection
                                    switch (manaChoice)
                                    {
                                        // Case 1 - View Self
                                        case 1:
                                            MenuAction.EmpAccessSelf(ref ObjMenus, ref ServeActions, loggedActId);
                                            break;
                                        // Case 2 - View Team Members
                                        case 2:
                                            MenuAction.EmpAccessTeam(ref ObjMenus, ref ServeActions, loggedActId);
                                            break;
                                        // Case 3 - Add Team Member
                                        case 3:
                                            MenuAction.EmpUpdatingTeam(ref ObjMenus, ref ServeActions, loggedActId, manaChoice, ref InputCheck);
                                            break;
                                        // Case 4 - Remove Team Member
                                        case 4:
                                            MenuAction.EmpUpdatingTeam(ref ObjMenus, ref ServeActions, loggedActId, manaChoice, ref InputCheck);
                                            break;
                                        // Case 0 - Log off
                                        case 0:
                                            logOut = true;
                                            loggedIn = false;
                                            break;
                                        // NOTE: There is no default case due to exception handling of user input
                                        // FUTURE FUNCTIONALITIES FOR MANAGER TYPE EMPLOYEE:
                                        // - LOGIN UPDATE
                                        // - Request - to MANAGER, and ADMIN
                                        // - Feedback - to DEV and HR
                                        // - Complain - Anonymous - to EVERYONE

                                    }                                                        
                                    break;
                                case 3:
                                        // Calling Menu Landing Page - HR
                                    int hrChoice = ObjMenus.MenuLandingHR(ref InputCheck);
                                    // Change Menu and perform Menu Actions based on user selection
                                    switch (hrChoice)
                                    {
                                        // Case 1 - View Self
                                        case 1:
                                            MenuAction.EmpAccessSelf(ref ObjMenus, ref ServeActions, loggedActId);
                                            break;
                                        // Case 2 - View Employee Records
                                        case 2:
                                            // NOTE: This only shows 
                                            actChoice = ObjMenus.MenuAccessLanding(ref InputCheck);
                                            if (actChoice != 0)
                                            {
                                                // Accessing employee record(s)
                                                MenuAction.EmpAccess(ref ObjMenus, ref ServeActions, actChoice, ref InputCheck);
                                            }                                                                                            
                                            break;
                                        // FUTURE FUNCTIONALITIES DEALING WITH OTHER EMPLOYEE:
                                        // - Request/Recommandation - dealing with DEV and MANAGER request
                                        // - Feedback - dealing with MANAGER and ADMIN
                                        // - Complain/Resolution - dealing with DEV, MANAGER, and HR
                                        // Case 0 - Log off
                                        case 0:
                                            logOut = true;
                                            loggedIn = false;
                                            break;
                                        // NOTE: There is no default case due to exception handling of user input
                                        // FUTURE FUNCTIONALITIES FOR HR TYPE EMPLOYEE:
                                        // - LOGIN UPDATE
                                        // - Request - to MANAGER, and ADMIN
                                        // - Feedback - to DEV and HR
                                        // - Complain - Anonymous - to EVERYONE
                                    }
                                    break;
                                case 4:
                                    // Calling Menu Landing Page - Developer
                                    int devChoice = ObjMenus.MenuLandingDeveloper(ref InputCheck);
                                    // Change Menu and perform Menu Actions based on user selection
                                    switch (devChoice)
                                    {
                                        // Case 1 - View Self
                                        case 1:
                                            MenuAction.EmpAccessSelf(ref ObjMenus, ref ServeActions, loggedActId);
                                            break;
                                        // Case 2 - View Team Records
                                        case 2:
                                            MenuAction.EmpAccessTeam(ref ObjMenus, ref ServeActions, loggedActId);
                                            // FUTURE FUNCTIONALITIES DEALING WITH OTHER EMPLOYEE (TEAM EMBEDDED):
                                            // - Request - to MANAGER
                                            // - Complains - Anonymous - to TEAM Only
                                            break;
                                        // Case 0 - Log off
                                        case 0:
                                            logOut = true;
                                            loggedIn = false;
                                            break;
                                        // NOTE: There is no default case due to exception handling of user input
                                        // FUTURE FUNCTIONALITIES FOR DEV TYPE EMPLOYEE:
                                        // - LOGIN UPDATE
                                        // - Request - to MANAGER and HR
                                        // - Complains - Anonymous - to Everyone
                                    }                        
                                    break;
                            }
                        } // end while loop - logOut 
                    }
                    else
                    {
                        failedLogIn = true;
                        programRunning = false;
                    }
                    
                }
                else
                {
                    programRunning = false;
                } 

            } while (programRunning == true);
            
            // Check which type of Menu Exit page to show
            if (failedLogIn == true)
                ObjMenus.MenuExitNotLoggedIn();     // User not logged in
            else
                ObjMenus.MenuExitLoggedIn();        // User choose exit option
            
            System.Console.ReadKey();
        }
        #endregion


    } // class Program
    
} // Namespace EmployeeManagementSystem