using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace WinFormsApp1
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
            dataGridView1.DataSource = db.Employees.ToList();
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
            if (dataGridView1.CurrentRow == null) return;

            var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;

            if (emp == null) return;

            textBox1.Text = emp.Id.ToString();
            textBox2.Text = emp.Name;
            textBox3.Text = emp.Department;
            textBox4.Text = emp.Salary.ToString();

        }


    }
}
