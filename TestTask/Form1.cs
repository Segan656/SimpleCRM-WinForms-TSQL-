using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Text;


namespace TestTask
{
   
    public partial class Form1 : Form
    {
        DataSet DepartmentTable;
        DataSet EmployeeTable;
        public DataManager ManagerDB;
        TreeNode SenderDepartment;
        ListViewItem SenderEmployee;
        
        private Dictionary<String, TreeNode> nodeMap;
        private Dictionary<String, List<TreeNode>> nodeList;
        public Form1()
        {
            InitializeComponent();
            ManagerDB = new DataManager();
            DepartmentButton.Visible = false;
            EmployeeButton.Visible = false;
            FillDepartmentData();
        }

        public void FillDepartmentData()
        {
            treeView1.Nodes.Clear();
            nodeMap = new Dictionary<string, TreeNode>();
            nodeList = new Dictionary<string, List<TreeNode>>();
            DepartmentTable = ManagerDB.GetDepartments();
            foreach (DataRow row in DepartmentTable.Tables[0].Rows)
            {
                String parentId = row["ParentDepartmentID"].ToString();
                TreeNode newNode = new TreeNode(row["Name"].ToString());
                newNode.Tag = row["ID"].ToString();
                if (String.IsNullOrEmpty(row["ParentDepartmentID"].ToString()))
                {

                    nodeMap.Add(newNode.Tag.ToString(), newNode);
                }
                else
                {
                    bool isExist = false;
                    foreach (String key in nodeList.Keys)
                    {
                        if (key == row["ParentDepartmentID"].ToString())
                        {
                            nodeList[key].Add(newNode);
                            isExist = true;
                        }
                    }
                    if (!isExist)
                        nodeList.Add(row["ParentDepartmentID"].ToString(), new List<TreeNode>() { newNode });
                }
            }
            foreach (TreeNode rootNode in nodeMap.Values)
            {
                AddInNodeMap(rootNode, nodeMap, nodeList);
                treeView1.Nodes.Add(rootNode);
            }
        }
        public void FillEmployeeData()
        {
            EmployeeTable = ManagerDB.GetEmployees();
            DepartmentButton.Visible = false;
            listView2.Clear();
            TreeNode selected = treeView1.SelectedNode;
            foreach (DataRow department in DepartmentTable.Tables[0].Rows)
            {
                if (selected.Text == department["Name"].ToString())
                {
                    foreach (DataRow employee in EmployeeTable.Tables[0].Rows)
                    {
                        if (department["ID"].ToString() == employee["DepartmentID"].ToString() && employee["FirstName"].ToString() != "")
                        {
                            ListViewItem item = new ListViewItem(ManagerDB.GetFormatEmployee(employee));
                            item.Tag = employee["ID"].ToString();
                            listView2.Items.Add(item);
                        }
                    }
                }

            }
            EmployeeButton.Visible = true;
            SenderDepartment = selected;
        }
        private void AddInNodeMap(TreeNode parentNode, Dictionary<string, TreeNode> nodeMap, Dictionary<String, List<TreeNode>> nodeList)
        {
            if(nodeList.TryGetValue(parentNode.Tag.ToString(), out List<TreeNode> childNodes))
                foreach (TreeNode childNode in childNodes)
                {
                    parentNode.Nodes.Add(childNode);
                    AddInNodeMap(childNode, nodeMap, nodeList);
                }
        }
        

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selected in listView2.SelectedItems)
            {
                SenderEmployee = selected;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(SenderEmployee.Tag.ToString(), this);
            form2.EnterEmployee = form2.UpdateEmployee;
            form2.ShowDialog();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ManagerDB.DeleteEmployee(SenderEmployee.Tag.ToString()) != 0)
            {
                MessageBox.Show("Сотрудник успешно удален");
                FillEmployeeData();
            }
            else
                MessageBox.Show("Произошла ошибка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2(SenderDepartment.Tag.ToString(), this);
            
            form2.EnterEmployee = form2.AddEmployee;
            form2.ShowDialog();
        }

        private void DepartmentButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(SenderDepartment.Tag.ToString(), this);
            form3.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillEmployeeData();
            DepartmentButton.Visible = true;
        }

        
        
    }
    
}
