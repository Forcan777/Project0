using System;

namespace EmployeeManagementSystem
{
    class InputAction
    {
        public Employee CreateInput(int roleNum, ref ExHandle ExCheck)
        {
            Employee NewEmp = new Employee();

            #region Employee Information

            System.Console.Write("  Please Enter the Employee Name    : ");
            NewEmp.EmpName = System.Console.ReadLine();
            System.Console.Write("  Please Enter the Employee Email   : ");
            NewEmp.EmpEmail = System.Console.ReadLine();
            bool inputCheck = true;
            double empSalary;
            do
            {

                System.Console.Write("  Please Enter the Employee Salary  : ");
                try
                {
                    empSalary = Convert.ToDouble(System.Console.ReadLine());
                    inputCheck = false;
                    NewEmp.EmpSalary = empSalary;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Invalid Input, please try again.");
                    System.Console.WriteLine("Press Any Key to Continue.");
                    System.Console.ReadLine();
                    System.Console.Clear();
                }

            } while (inputCheck);

            inputCheck = true;
            int tempChoice; 
            do
            {
                if (roleNum == 4)
                {
                    System.Console.WriteLine("  Please Select Employee Status. ");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("    1. Contractor ");
                    System.Console.WriteLine("    2. Permanent Hire");
                    System.Console.WriteLine("");
                    System.Console.Write("  Employee Status  : ");

                    tempChoice = ExCheck.InputExceptionCheck(2, 1);
                }
                else
                    tempChoice = 2;

                switch (tempChoice)
                {
                    case 1:
                        NewEmp.EmpStatus = "Contractor";
                        inputCheck = false;
                        break;
                    case 2:
                        NewEmp.EmpStatus = "Permanent";
                        inputCheck = false;
                        break;
                }
                System.Console.WriteLine("Press Any Key to Continue.");
                System.Console.ReadLine();
                if (inputCheck == true)
                    System.Console.Clear();

            } while (inputCheck);
            

            switch (roleNum)
            {
                case 1:
                    NewEmp.EmpRole = "Administrator";
                    NewEmp.EmpUserAccLevel = "A";
                    break;
                case 2:
                    NewEmp.EmpRole = "Manager";
                    NewEmp.EmpUserAccLevel = "M";
                    break;
                case 3:
                    NewEmp.EmpRole = "Human Resource";
                    NewEmp.EmpUserAccLevel = "H";
                    break;
                case 4:
                    NewEmp.EmpRole = "Developer";
                    NewEmp.EmpUserAccLevel = "D";
                    break;
            }
            #endregion
            return NewEmp;
        }

        public int GetEmpId(ref ExHandle ExCheck)
        {
            int inputEmpID, exitSelection;
            bool empIdCheck = false;
            bool exitSelectionCheck = false;
            do
            {            
                System.Console.Write("  Please Enter the Employee ID    : ");
                inputEmpID = ExCheck.InputExceptionCheck();
                if (inputEmpID == 0)
                {
                    System.Console.WriteLine("  Invalid Employee ID.");
                    exitSelectionCheck = false;
                    do
                    {
                        System.Console.WriteLine("  * Press 1 to Try Again.");
                        System.Console.WriteLine("  * Press 0 to Exit.");
                        exitSelection = ExCheck.InputExceptionCheck(2, 0);
                        if (exitSelection == 0)
                        {
                            empIdCheck = true;
                            exitSelectionCheck = true;
                        }
                        else if (exitSelection == 1)
                            exitSelectionCheck = true;
                        
                    } while (exitSelectionCheck == false);    
                }
                else
                    empIdCheck = true;
            } while (empIdCheck == false);

            return inputEmpID;
        }

        public Employee UpdateInput(int empId, ref ExHandle ExCheck)
        {
            Employee UpEmp = new Employee();

            UpEmp.EmpNo = empId;

            System.Console.Write("  Please Enter the Employee Name    : ");
            UpEmp.EmpName = System.Console.ReadLine();
            System.Console.Write("  Please Enter the Employee Email   : ");
            UpEmp.EmpEmail = System.Console.ReadLine();
            bool inputCheck = true;
            double empSalary;
            do
            {
                System.Console.Write("  Please Enter the Employee Salary  : ");
                try
                {
                    empSalary = Convert.ToDouble(System.Console.ReadLine());
                    inputCheck = false;
                    UpEmp.EmpSalary = empSalary;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Invalid Input, please try again.");
                    System.Console.WriteLine("Press Any Key to Continue.");
                    System.Console.ReadLine();
                    System.Console.Clear();
                }

            } while (inputCheck);

            System.Console.WriteLine("  Pleas Select Employee Department  : ");
            System.Console.WriteLine("     1. Administrator            ");
            System.Console.WriteLine("     2. Manager                  ");
            System.Console.WriteLine("     3. Human Resource           ");
            System.Console.WriteLine("     4. Developer                ");
            int uChoice = ExCheck.InputExceptionCheck(4, 1);
            switch (uChoice)
            {
                case 1:
                    UpEmp.EmpRole = "Administrator";
                    UpEmp.EmpUserAccLevel = "A";
                    break;
                case 2:
                    UpEmp.EmpRole = "Manager";
                    UpEmp.EmpUserAccLevel = "M";
                    break;
                case 3:
                    UpEmp.EmpRole = "Human Resource";
                    UpEmp.EmpUserAccLevel = "H";
                    break;
                case 4:
                    UpEmp.EmpRole = "Developer";
                    UpEmp.EmpUserAccLevel = "D";
                    break;
            }

            inputCheck = true;
            int tempChoice; 
            do
            {
                if (uChoice == 4)
                {
                    System.Console.WriteLine("  Please Select Employee Status. ");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("    1. Contractor ");
                    System.Console.WriteLine("    2. Permanent Hire");
                    System.Console.WriteLine("");
                    System.Console.Write("  Employee Status  : ");

                    tempChoice = ExCheck.InputExceptionCheck(2, 1);
                }
                else
                    tempChoice = 2;

                switch (tempChoice)
                {
                    case 1:
                        UpEmp.EmpStatus = "Contractor";
                        inputCheck = false;
                        break;
                    case 2:
                        UpEmp.EmpStatus = "Permanent";
                        inputCheck = false;
                        break;
                }
                System.Console.WriteLine("Press Any Key to Continue.");
                System.Console.ReadLine();
                if (inputCheck == true)
                    System.Console.Clear();

            } while (inputCheck);
            
            return UpEmp;
        }
    }
}