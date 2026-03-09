namespace Inheritence_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class father
        {
            public void show()
            {
                MessageBox.Show("This is parent class");
            }
        }
        class son : father
        {
            public void display()
            {
                MessageBox.Show("This is child class");
            }
        }
        class grandson : son
        {
            public void print()
            {
                MessageBox.Show("This is grand child class");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            grandson g = new grandson();
            g.show();
            g.display();
            g.print();

            son s = new son();
            s.show();
            s.display();

        }
    }
}
