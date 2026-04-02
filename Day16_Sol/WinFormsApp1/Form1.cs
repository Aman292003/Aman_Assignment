namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Before Delay";
            await Task.Delay(10000);
            label2.Text = "After Delay";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world");
        }
    }
}
