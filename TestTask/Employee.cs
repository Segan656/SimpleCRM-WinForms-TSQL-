using System;

using System.Data;

namespace TestTask
{
    public class Employee
    {
        
        public String ID { get;  set; }
        public String FirstName { get;  set; }
        public String SurName { get;  set; }
        public String Patronymic { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public String DocSeries { get;  set; }
        public String DocNumber { get;  set; }
        public String Position { get;  set; }
        public String Department { get;   set; }
        public String DepartmentID { get; set; }
        public String Age { get;  set; }

        public Employee() { }

        public Employee(String id,DataRow row)
        {            
            ID = id;
            FirstName = row["FirstName"].ToString();
            SurName = row["SurName"].ToString();
            Patronymic = row["Patronymic"].ToString();
            DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
            DocNumber = row["DocNumber"].ToString();
            DocSeries = row["DocSeries"].ToString();
            Position = row["Position"].ToString();
            Department = row["Name"].ToString();
            DepartmentID = row["DepartmentID"].ToString();
            Age = GetAge(DateOfBirth);
        }
        public String GetAge(DateTime dateOfBirth)
        {
            
            int year = (DateTime.Today.Year - dateOfBirth.Year);
            if (DateTime.Today.Month < dateOfBirth.Month ||
                (DateTime.Today.Month == dateOfBirth.Month && DateTime.Today.Day < dateOfBirth.Day)) year--;
            string age = year.ToString();
            return age;
        }
    }
}
