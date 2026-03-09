using System;

namespace class_object_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class employee
        {
            int sal, bonus;
            public void total_sal(int sali, int bonus1)
            {
                sal = sali;
                bonus = bonus1;
                int total = sal + bonus;
                MessageBox.Show("Total Salary is: " + total);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
                employee emp = new employee();
                emp.total_sal(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
