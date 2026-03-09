namespace exceptions_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public class ICICIBankException : ApplicationException
        {
            public ICICIBankException(string message) : base(message)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                int c = a / b;
                textBox3.Text = c.ToString();
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Error: Division by zero is not allowed.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: Please enter valid integers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }

            finally
            {
                // This block will always execute
                Console.WriteLine("Execution completed.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int age = Convert.ToInt32(textBox4.Text);
                if (age < 18)
                {
                    ICICIBankException ex = new ICICIBankException("Age is less than 18, so you are not eligible to open account");
                    throw ex;
                }
            }
            catch (ICICIBankException ex)
            {
                MessageBox.Show("ICICIException:" + ex.Message);
            }
        }
    }
  }

