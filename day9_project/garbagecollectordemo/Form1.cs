namespace garbagecollectordemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class a
        {
            public a()
            {
                MessageBox.Show("creating Object");
            }
            ~a()
            {
                MessageBox.Show("Destroying Object");
            }

        }
        class b : a
        {
            public b()
            {
                MessageBox.Show("creating Object2");
            }
            ~b()
            {
                MessageBox.Show("Destroying Object2");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b ob =new b();
            

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            b ob = new b();
        }
    }
}

