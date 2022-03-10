using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Manager Info
            Manager newManager = new Manager();
            System.Console.WriteLine("Please enter manager information: ");
            System.Console.WriteLine("Employee number: ");
            newManager.empNo = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("           Name: ");
            newManager.empName = System.Console.ReadLine();
            System.Console.WriteLine("         Salary: ");
            newManager.empSalary = Convert.ToDouble(System.Console.ReadLine());
            newManager.empIsPermenant = true;
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Enter a bonus percentage value: ");
            double pctValue = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine("The percentage amount of the salary is: " + newManager.GetBonus(pctValue));
            #endregion

            #region Developer Info
            Developer newDev = new Developer();
            System.Console.WriteLine("Please enter developer information: ");
            System.Console.WriteLine("Employee number: ");
            newDev.empNo = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("           Name: ");
            newDev.empName = System.Console.ReadLine();
            System.Console.WriteLine("         Salary: ");
            newDev.empSalary = Convert.ToDouble(System.Console.ReadLine());
            newDev.empIsPermenant = true;
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Enter a bonus percentage value: ");
            pctValue = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine("The percentage amount of the salary is: " + newDev.GetBonus(pctValue));
            #endregion

            #region HR Info
            HR newHR = new HR();
            System.Console.WriteLine("Please enter HR information: ");
            System.Console.WriteLine("Employee number: ");
            newHR.empNo = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("           Name: ");
            newHR.empName = System.Console.ReadLine();
            System.Console.WriteLine("         Salary: ");
            newHR.empSalary = Convert.ToDouble(System.Console.ReadLine());
            newHR.empIsPermenant = true;
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Enter a bonus percentage value: ");
            pctValue = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine("The percentage amount of the salary is: " + newHR.GetBonus(pctValue));
            #endregion

        }
    }
}
