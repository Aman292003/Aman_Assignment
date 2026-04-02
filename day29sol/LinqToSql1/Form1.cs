using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSql1
{
    public partial class Form1 : Form
    {
        private DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        private void LoadEmployees()
        {
           // dataGridView1.DataSource = db.Employees.ToList();
           dataGridView1.DataSource = db.sp_GetEmployees().ToList();
        }
        private void clearfields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!int.TryParse(dataGridView1.CurrentRow?.Cells[0].Value?.ToString(), out var id))
                return;

            var result = db.sp_GetEmployeeById(id);  // Calls sp_GetEmployeeById SP!
            var emp = result.FirstOrDefault();
            if (emp != null)
            {
                textBox1.Text = emp.Id.ToString();// getting errors 
                textBox2.Text = emp.Name;
                textBox3.Text = emp.Department;
                textBox4.Text = emp.Salary.ToString();
            }
            else
            {
                clearfields();  // helper method
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Name is required");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Dept is required");
                return;
            }
            //if (string.IsNullOrEmpty(textBox4.Text))
            //{
            //    MessageBox.Show("Salary is required");
            //    return;
            //}
            var emp = new Employee
            {
                Name = textBox2.Text,
                Department = textBox3.Text,
                Salary = decimal.TryParse(textBox4.Text, out var s) ? s : 0


            };
            db.Employees.InsertOnSubmit(emp);
            db.SubmitChanges();
            LoadEmployees();
            clearfields();


        }
    

        private void button5_Click(object sender, EventArgs e)
        {
            clearfields();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                if (!int.TryParse(textBox1.Text, out var id))
                {
                    MessageBox.Show("select and employee to update");
                    return;
                }

                var emp = db.Employees.SingleOrDefault(x => x.Id == id);
                if (emp == null)
                {
                    MessageBox.Show("Employee not found");
                    return;
                }
                emp.Name = textBox2.Text;
                emp.Department = textBox3.Text;
                emp.Salary = decimal.TryParse(textBox4.Text, out var s) ? s : emp.Salary;

                db.SubmitChanges();//generates update 
                LoadEmployees();
                clearfields();

            }

        private void button4_Click(object sender, EventArgs e)
        
        {
            if (!int.TryParse(textBox1.Text, out var id))
            {
                MessageBox.Show("select an employee to delete");
                return;
            }
            var emp = db.Employees.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                MessageBox.Show("Employee not found");
                return;
            }

            if (MessageBox.Show("delete this employee?", "confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                db.Employees.DeleteOnSubmit(emp);
                db.SubmitChanges();
                LoadEmployees();
                clearfields();
            }
        }
    }
}
