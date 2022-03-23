using System;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        #region Employee Properties
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public double EmpSalary { get; set; }
        public string EmpStatus { get; set; }
        public string EmpRole { get; set; }
        public string EmpUserAccLevel { get; set; }

        // public string empUserName { get; set; }
        // public string empUserPassword { get; set; }

        #endregion

    }

}