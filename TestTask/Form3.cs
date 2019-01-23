using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form3 : Form
    {
        private String CurID;
        private DataSet DepartmentTable;
        private DataManager ManagerDB;
        private Department CurDepartment;
        private Department ChildDepartment;
        private Form1 form1;
        public Form3(String id, Form1 form1)
        {
            InitializeComponent();
            CurID = id;
            CurDepartment = new Department();
            ChildDepartment = new Department();
            ManagerDB = form1.ManagerDB;
            this.form1 = form1;
        }
        private void FillData(String departmentId)
        {
            DepartmentTable = ManagerDB.GetDepartments();
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                
                ParentCB.Items.Add(department["Name"].ToString());
                if (departmentId == department["ID"].ToString())
                    ParentCB.SelectedItem = department["Name"].ToString();
            }
        }

        private void SetData(Department curDepartment,Department childDepartment)
        {
            curDepartment.Name = NameTB.Text;
            curDepartment.Code = CodeTB.Text;
            foreach (DataRow row in DepartmentTable.Tables[0].Rows)
            {
                if (ParentCB.Text == row["Name"].ToString())
                    curDepartment.ParentDepartmentID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(ChildCB.Text) && ChildCB.Text == row["Name"].ToString())
                {
                    childDepartment.ID = row["ID"].ToString();
                }

            }
        }

        private void AddDepartment(Department department, Department childDepartment)
        {
            int code;
            SetData(department, childDepartment);
            if (String.IsNullOrEmpty(ChildDepartment.ID))
                code = ManagerDB.AddDepartment(department);
            else
                code = ManagerDB.AddDepartmentWithChild(department, childDepartment);
            if (code != 0)
            {
                MessageBox.Show("Операция прошла успешно");
                form1.FillDepartmentData();
            }
        }

        private bool IsValidData(out String error)
        {
            error = "";
            bool validParent = false;
            bool validChild = false;
            bool isValid = true;
            if (!Validation.IsCode(CodeTB.Text))
            {
                CodeTB.ForeColor = Color.Red;
                isValid = false;
                error = $"Поле '{CodeTB.Tag}' может содержать только латинские буквы и цифры!";
            }
            else
            {
                CodeTB.ForeColor = Color.Black;
            }

            if (!Validation.IsPhrase(NameTB.Text))
            {
                NameTB.ForeColor = Color.Red;
                isValid = false;
                error = $"Поле '{NameTB.Tag.ToString()}' не может содержать цифры, а так-же служебные символы кроме пробела и тире!";
            }
            else
            {
                NameTB.ForeColor = Color.Black;
            }
            foreach (var department in ParentCB.Items)
            {
                if (ParentCB.Text == department.ToString())
                {
                    validParent = true;
                }
            }
            if (!validParent)
            {
                isValid = false;
                ParentCB.ForeColor = Color.Red;
                error = $"Поле {ParentCB.Tag} может содержать только существующий отдел!";
            }

            if (String.IsNullOrEmpty(ChildCB.Text))
                validChild = true;
            else
                foreach (var department in ChildCB.Items)
                {
                    if (ChildCB.Text == department.ToString())
                    {
                        validChild = true;
                    }
                }
            if (!validChild)
            {
                isValid = false;
                ChildCB.ForeColor = Color.Red;
                error = $"Поле {ChildCB.Tag} может содержать только существующий отдел!";
            }
            return isValid;
        }
        private void Form3_Load_1(object sender, EventArgs e)
        {
            CurDepartment = new Department();
            FillData(CurID);
        }

        private void ParentCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            String parentId = "";
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                if (ParentCB.SelectedItem.ToString() == department["Name"].ToString())
                    parentId = department["ID"].ToString();
            }
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                if (department["ParentDepartmentID"].ToString() == parentId)
                {
                    ChildCB.Items.Add(department["Name"].ToString());
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData(out String error))
                AddDepartment(CurDepartment, ChildDepartment);
            else
                MessageBox.Show("Неверный формат данных: " + error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
