using System;

namespace EmployeeManagement
{
   abstract class Employee
    {
        public int empNo { get; set; }
        public string empName { get; set; }
        public double empSalary { get; set; }
        public bool empIsPermenant { get; set; }

        public double GetBonus(double Pct)
        {  
            return ((empSalary / 100) * Pct);
        }

    }

}