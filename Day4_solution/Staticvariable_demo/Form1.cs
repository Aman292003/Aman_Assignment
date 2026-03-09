namespace Staticvariable_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class jointaccount
        {
            static double balance = 100000;
            public void deposit(double amount)
            {
                balance += amount;
                MessageBox.Show("New Balance is: " + balance);
            }
            public void withdraw(double amount)
            {
                if (balance < amount)
                {
                    MessageBox.Show($"Insufficient amount");
                }
                else
                {
                    balance -= amount;
                }
                MessageBox.Show("New Balance is: " + balance);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            jointaccount account = new jointaccount();
            account.withdraw(Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jointaccount account = new jointaccount();
            account.withdraw(Convert.ToInt32(textBox1.Text));
        }
    }
}
