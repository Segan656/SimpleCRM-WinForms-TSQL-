using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace TestTask
{
    public partial class Form2 : Form
    {
        public delegate void OnSaveButton(Employee employee);
        public OnSaveButton EnterEmployee;
        private String CurID;
        private DataSet DepartmentTable;
        private DataManager ManagerDB;
        private Employee CurEmployee;
        private Form1 form1;
        public Form2(String id, Form1 form1)
        {
            InitializeComponent();
            CurID = id;
            this.form1 = form1;
            ManagerDB = form1.ManagerDB;
        }
        
        private void FillData(String departmentId)
        {
            DepartmentTable = ManagerDB.GetDepartments();
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                if(departmentId == department["ID"].ToString())
                    DepartmentCB.Text = department["Name"].ToString();
                DepartmentCB.Items.Add(department["Name"].ToString());
            }
        }
        private void FillData(Employee employee)
        {
            DepartmentTable = ManagerDB.GetDepartments();
            NameTB.Text = employee.FirstName;
            SurNameTB.Text = employee.SurName;
            PatronymicTB.Text = employee.Patronymic;
            PositionTB.Text = employee.Position;
            DateBirthTB.Value = employee.DateOfBirth;
            DepartmentCB.Text = employee.Department;
            AgeTB.Text = employee.Age;
            SeriesTB.Text = employee.DocSeries;
            NumberTB.Text = employee.DocNumber;
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                DepartmentCB.Items.Add(department["Name"].ToString());
            }
        }

        private void SetData(Employee employee)
        { 
            employee.FirstName = NameTB.Text;
            employee.SurName = SurNameTB.Text;
            employee.Patronymic = PatronymicTB.Text;
            employee.DateOfBirth = DateBirthTB.Value;
            employee.DocSeries = SeriesTB.Text;
            employee.DocNumber = NumberTB.Text;
            employee.Position = PositionTB.Text;
            
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                if (DepartmentCB.Text == department["Name"].ToString())
                {
                    employee.Department = DepartmentCB.Text;
                    employee.DepartmentID = department["ID"].ToString();
                }
            }
        }
        private bool IsValidData(out String error)
        {
            error = "";
            List<TextBox> phrases = new List<TextBox>() { NameTB, SurNameTB, PositionTB };
            bool valid = true;
            bool validDepartment = false;
            foreach(TextBox textbox in phrases)
            {
                if (!Validation.IsPhrase(textbox.Text))
                {
                    textbox.ForeColor = Color.Red;
                    valid = false;
                    error = $"Поле '{textbox.Tag.ToString()}' не может содержать цифры, а так-же служебные символы кроме пробела и тире!";
                }
                else
                {
                    textbox.ForeColor = Color.Black;                   
                }
                    
            }
            if (!Validation.IsWord(PatronymicTB.Text))
            {
                PatronymicTB.ForeColor = Color.Red;
                valid = false;
                error = $"Поле '{PatronymicTB.Tag.ToString()}' не может содержать цифры, а так-же служебные символы!";
            }
            else
            {
                PatronymicTB.ForeColor = Color.Black;                
            }
            foreach (var department in DepartmentCB.Items)
            {
                if (DepartmentCB.Text == department.ToString())
                {
                    validDepartment = true;
                }
            }
            if (!validDepartment)
            {
                valid = false;
                DepartmentCB.ForeColor = Color.Red;
                error = $"Поле {DepartmentCB.Tag} может содержать только существующий отдел!";
            }
                
            return valid;
        }
       
        public void UpdateEmployee(Employee employee)
        {
            SetData(employee);
            int code = ManagerDB.UpdateEmployee(employee);
            if (code == 1)
                MessageBox.Show("Операция прошла успешно");
        }
        public void AddEmployee(Employee employee)
        {
            SetData(employee);
            int code = ManagerDB.AddEmployee(employee);
            if (code == 1)
            {
                MessageBox.Show("Операция прошла успешно");
                
            }
                
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (EnterEmployee == UpdateEmployee)
            {
                CurEmployee = ManagerDB.GetEmployeeData(CurID);
                FillData(CurEmployee);
            }
            else if (EnterEmployee == AddEmployee)
            {
                CurEmployee = new Employee();
                FillData(CurID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (IsValidData(out String error))
            {
                EnterEmployee(CurEmployee);
                form1.FillEmployeeData();
            }
            else
                MessageBox.Show("Неверный формат данных: "+error);
        }

        

        private void DateBirthTB_ValueChanged(object sender, EventArgs e)
        {
            AgeTB.Text = CurEmployee.GetAge(DateBirthTB.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }

}
