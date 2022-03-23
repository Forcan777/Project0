using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class MenuAction
    {

        public bool CheckLogin(ref Accounts LoginUser, ref ServerAction ServeActions)
        {
            bool isLogin = false;  

            int userExist = ServeActions.ReadExist(ref LoginUser);

            if (userExist != 0)
                isLogin = true;

            return isLogin;
        }

        public void EmpCreation(ref Menus ObjMenus, ref ServerAction ServeActions, int choice, ref ExHandle ExCheck)
        {
            Employee NewEmp = new Employee();
            InputAction UserInput = new InputAction();


            switch (choice)
            {
                case 1:
                    #region Admin
                    ObjMenus.MenuInputHeaderCreate();
                    NewEmp = UserInput.CreateInput(1, ref ExCheck);
                    ServeActions.Create(ref NewEmp);
                    NewEmp.EmpNo = ServeActions.ReadId(ref NewEmp);
                    ServeActions.CreateLogin(ref NewEmp);
                    ServeActions.CreateTeam(ref NewEmp);
                    #endregion
                    break;
                case 2:
                    #region Manager
                    ObjMenus.MenuInputHeaderCreate();
                    NewEmp = UserInput.CreateInput(2, ref ExCheck);
                    ServeActions.Create(ref NewEmp);
                    NewEmp.EmpNo = ServeActions.ReadId(ref NewEmp);
                    ServeActions.CreateLogin(ref NewEmp);
                    ServeActions.CreateTeam(ref NewEmp);
                    #endregion
                    break;
                case 3:
                    #region Human Resources
                    ObjMenus.MenuInputHeaderCreate();
                    NewEmp = UserInput.CreateInput(3, ref ExCheck);
                    ServeActions.Create(ref NewEmp);
                    NewEmp.EmpNo = ServeActions.ReadId(ref NewEmp);
                    ServeActions.CreateLogin(ref NewEmp);
                    ServeActions.CreateTeam(ref NewEmp);
                    #endregion
                    break;
                case 4:
                    #region Developer
                    ObjMenus.MenuInputHeaderCreate();
                    NewEmp = UserInput.CreateInput(4, ref ExCheck);
                    ServeActions.Create(ref NewEmp);
                    NewEmp.EmpNo = ServeActions.ReadId(ref NewEmp);
                    ServeActions.CreateLogin(ref NewEmp);
                    ServeActions.CreateTeam(ref NewEmp);
                    #endregion
                    break;
            }
            System.Console.WriteLine("Press Any Key to Continue.");
            System.Console.ReadLine();
        }

        public void EmpAccess(ref Menus ObjMenus, ref ServerAction ServeAction, int choice, ref ExHandle ExCheck)
        {
            InputAction UserInput = new InputAction();
            List<Employee>EmpSearch;

            switch (choice)
            {
                case 1:
                    #region Employee ID
                    int empId;
            
                    EmpSearch = new List<Employee>();                       // Instanciate a object List of Employee. 

                    ObjMenus.MenuInputHeaderAccess();                       // Menu header
                    empId = UserInput.GetEmpId(ref ExCheck);                // Get employee id from user

                    // Database Access
                    ServeAction.Read(empId, ref EmpSearch);                 // Read and store the record to the employee array

                    // Database Search Output
                    ObjMenus.MenuOutputAccess(ref EmpSearch);
                    // System.Console.WriteLine("Testing, press anykey");
                    // System.Console.ReadLine();
                    #endregion
                    break;
                case 2:
                    #region Employee Department
                    int roleNum = ObjMenus.MenuAccessType(ref ExCheck);     // Get user input to select department to look up

                    EmpSearch = new List<Employee>();                   // Instanciate the employee array with the number of the records available
                    ServeAction.ReadGroup(roleNum, ref EmpSearch);   // Read and store the record to the employee array

                    // Database Search Output
                    ObjMenus.MenuOutputAccess(ref EmpSearch);
                    #endregion
                    break;
                case 3:
                    #region All
                    
                    EmpSearch = new List<Employee>();                   // Instanciate the employee array with the number of the records available
                    ServeAction.ReadAll(ref EmpSearch);   // Read and store the record to the employee array

                    // Database Search Output
                    ObjMenus.MenuOutputAccess(ref EmpSearch);
                    #endregion
                    break;
            }

        }

        public void EmpAccessSelf(ref Menus ObjMenus, ref ServerAction ServeAction, int empID)
        {
            List<Employee>EmpSearch;

            EmpSearch = new List<Employee>();                       // Instanciate a object List of Employee. 

            // Database Access
            ServeAction.Read(empID, ref EmpSearch);                 // Read and store the record to the employee array

            // Database Search Output
            ObjMenus.MenuOutputAccess(ref EmpSearch);
            // System.Console.WriteLine("Testing, press anykey");
            // System.Console.ReadLine();
            
            
        }
        public void EmpAccessTeam(ref Menus ObjMenus, ref ServerAction ServeAction, int empID)
        {
            InputAction UserInput = new InputAction();
            List<Employee>EmpSearch;
            int empTeam = 0;

            empTeam = ServeAction.ReadTeamID(empID);            // Get teamID based off of user's employee ID

            EmpSearch = new List<Employee>();                   // List array of employee object

            // Database Access
            ServeAction.ReadTeam(empTeam, ref EmpSearch);       // Read and store the record to the employee array

            // Database Search Output
            ObjMenus.MenuOutputAccess(ref EmpSearch);
            // System.Console.WriteLine("Testing, press anykey");
            // System.Console.ReadLine();
        }

        public bool EmpUpdates (ref Menus ObjMenus, ref ExHandle ExCheck)
        {
            bool willUpdates = false;
            
            willUpdates = ObjMenus.MenuUpdates(ref ExCheck);

            return willUpdates;
        }
        public void EmpUpdating (ref Menus ObjMenus, ref ServerAction ServeAction, ref ExHandle ExCheck)
        {
            InputAction UserInput = new InputAction();

            int empId = 0;
            empId = UserInput.GetEmpId(ref ExCheck);

            if (empId != 0)
            {
                Employee UpdatedEmp = new Employee();
                ObjMenus.MenuInputHeaderUpdate();
                UpdatedEmp = UserInput.UpdateInput(empId, ref ExCheck);
            
                ServeAction.Update(empId, ref UpdatedEmp);
            }
        }
        public void EmpUpdatingTeam (ref Menus ObjMenus, ref ServerAction ServeAction, int empID, int uChoice, ref ExHandle ExCheck)
        {
            InputAction UserInput = new InputAction();
            List<Employee>EmpSearch;
            int empTeam = 0;

            empTeam = ServeAction.ReadTeamID(empID);            // Get teamID based off of user's employee ID

            EmpSearch = new List<Employee>();                   // List array of employee object

            // Database Access
            if (uChoice == 3)
                ServeAction.ReadAvailableDev(ref EmpSearch);       // Read and store the record to the employee array
            else
                ServeAction.ReadTeam(empTeam, ref EmpSearch);

            // Database Search Output
            ObjMenus.MenuOutputAccess(ref EmpSearch);
            // System.Console.WriteLine("Testing, press anykey");
            // System.Console.ReadLine();
            bool teamMemberUpdate = false;
            if (uChoice == 3)
                teamMemberUpdate = ObjMenus.MenuUpdatesTeamAdd(ref ExCheck);
            else
                teamMemberUpdate = ObjMenus.MenuUpdatesTeamRemoval(ref ExCheck);

            if (teamMemberUpdate)
            {
                int tempTeamEmpID = UserInput.GetEmpId(ref ExCheck);

                if (uChoice == 3)
                    ServeAction.UpdateTeamMember(empTeam, tempTeamEmpID);
                else
                    ServeAction.UpdateTeamMember(0, tempTeamEmpID);
            }
        }
        // NOT YET IMPLEMENTED
        public void EmpUpdatingLogin (ref Menus ObjMenus, ref ServerAction ServeAction, ref ExHandle ExCheck)
        {
            InputAction UserInput = new InputAction();
            int empId = UserInput.GetEmpId(ref ExCheck);
            Employee UpdatedEmp = new Employee();

            ObjMenus.MenuInputHeaderUpdate();
            UpdatedEmp = UserInput.UpdateInput(empId, ref ExCheck);
            
            ServeAction.Update(empId, ref UpdatedEmp);
        }
        // NOT YET IMPLEMENTED
        public void EmpDeletion(ref Menus ObjMenus, ref ServerAction ServeActions, ref ExHandle ExCheck)
        {
            InputAction UserInput = new InputAction();
            int empId, confirmChoice;
            bool removalConfirm = false;
            bool confirmCheck = true;
            ObjMenus.MenuInputHeaderDelete();
            empId = UserInput.GetEmpId(ref ExCheck);
            do
            {
                System.Console.WriteLine("  ARE YOU SURE YOU WANT TO DELETE THE EMPLOYEE RECORD? ");
                System.Console.WriteLine("     * ONCE CONFIRMED THE REMOVAL CANNOT BE UNDONE.");
                System.Console.WriteLine("  1. Yes ");
                System.Console.WriteLine("  2. No ");
                confirmChoice = ExCheck.InputExceptionCheck(2, 1);

                if (confirmChoice >= 1 && confirmChoice <= 2)
                    confirmCheck = false;
            } while (confirmCheck);

            if (confirmChoice == 1)
                removalConfirm = true;

            if (removalConfirm)
            {   
                ServeActions.DeleteTeam(empId);
                ServeActions.DeleteLogin(empId);
                ServeActions.Delete(empId);

                System.Console.WriteLine("  EMPLOYEE RECORD DELETED ");
                System.Console.WriteLine("  Please Press Any Key to Cotinue.");
                System.Console.ReadLine();
            }
        }


    }
}