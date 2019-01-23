using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TestTask
{
    public class DataManager
    {
        private String ConnectionString;
        
        public DataManager()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public String GetFormatEmployee(DataRow row)
        {
            return (row[2].ToString() != "" ? row[1].ToString() + " " + row[0].ToString()[0] + "." +
                row[2].ToString()[0] + ". " : row[1].ToString() + " " + row[0].ToString()[0] + ". ") + row[4].ToString();
        }
        public Employee GetEmployeeData(String id)
        {
            int Id;
            if (Int32.TryParse(id, out Id))
            {
                DataSet employeeTable = new DataSet();
                employeeTable = this.GetTable($"SELECT FirstName, SurName, Patronymic, Name, Position, DateOfBirth," +
                    $" DocSeries, DocNumber, DepartmentID  FROM Employee, Department Where Employee.ID = {Id} AND Employee.DepartmentID = Department.ID");
                
                return new Employee(id,employeeTable.Tables[0].Rows[0]);
            }
            else
                throw new Exception("Неверное Id");
        }
        
        
        public int UpdateEmployee(Employee employee)
        {
            
            String sqlQuery = $"UPDATE Employee SET FirstName = '{employee.FirstName}', SurName = '{employee.SurName}', " +
                    $"Patronymic = '{employee.Patronymic}', DateOfBirth = '{employee.DateOfBirth}', DocSeries = '{employee.DocSeries}'," +
                    $"DocNumber = '{employee.DocNumber}', Position = '{employee.Position}', DepartmentID = '{employee.DepartmentID}' WHERE ID = '{employee.ID}'";
           
            return SetData(sqlQuery);
        }
        public int AddDepartment(Department department)
        {
            String sqlQuery = $"INSERT INTO Department (ID, Name, Code, ParentDepartmentID)" +
                              $" VALUES (NEWID(), '{department.Name}', '{department.Code}', " +
                              $"'{department.ParentDepartmentID}')";
            return SetData(sqlQuery);
        }
        public int AddDepartmentWithChild(Department department, Department chilDepartment)
        {
            String sqlQuery = $"DECLARE @id uniqueidentifier = NEWID() " +
                              $"INSERT INTO Department (ID, Name, Code, ParentDepartmentID)" +
                              $" VALUES (@id, '{department.Name}', '{department.Code}','{department.ParentDepartmentID}') " +
                              $"Update Department Set ParentDepartmentID = @id Where ID = '{chilDepartment.ID}'";
            return SetData(sqlQuery);
        }
        public int AddEmployee(Employee employee)
        {
            String sqlQuery = $"INSERT INTO Employee (FirstName, SurName, " +
                    $"Patronymic, DateOfBirth, DocSeries," +
                    $"DocNumber, Position, DepartmentID) VALUES ('{employee.FirstName}', '{employee.SurName}', '{employee.Patronymic}', " +
                    $"CONVERT(datetime,'{employee.DateOfBirth}',103), '{employee.DocSeries}', '{employee.DocNumber}', '{employee.Position}', '{employee.DepartmentID}')";
            return SetData(sqlQuery);
        }
        
        public DataSet GetEmployees()
        {            
            return GetTable("SELECT FirstName, SurName, Patronymic, DepartmentID, Position, ID  FROM Employee");
        }

        
        public DataSet GetDepartments()
        {           
            return GetTable("SELECT ID, Name, ParentDepartmentID  FROM Department");
        }
        private DataSet GetTable(String sqlQuery)
        {
            DataSet table = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(sqlQuery, connection);
                command.Fill(table);
            }
            return table;
        }

        public int DeleteEmployee(String id)
        {
            String sqlQuery = $"DELETE FROM Employee WHERE ID = {id}";
            return SetData(sqlQuery);
        }
        private String GetScallar(String sqlQuery)
        {
            String modified;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                modified = command.ExecuteScalar().ToString();
            }
            return modified;
        }
        private int SetData(String sqlQuery)
        {
            int code;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                code = command.ExecuteNonQuery();
            }
            return code;
        }
    }
}
