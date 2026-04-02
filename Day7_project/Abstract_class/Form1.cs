namespace Abstract_class
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        interface Ishape
        {
            void area(int x , int y);
        }
        interface Ishape2
        {
            void area(int x);
        }

        class newshape : Ishape, Ishape2
        {
            public void area(int x, int y)
            {
                MessageBox.Show("The area of new shape is : " + (x * y).ToString());
            }
            public void area(int x)
            {
                MessageBox.Show("The area of new shape is : " + (x * x).ToString());
            }
        }
        public abstract class polygon2
        {
            public abstract void area(int x);

        }
        public abstract class polygon
        {
            public  void test()
            {
                MessageBox.Show("*******************");
            }
            public abstract void area(int x , int y);
        }
        class traingle : polygon
        {
            public override void area(int x, int y)
            {
                MessageBox.Show("The area of traingle is : " + (0.5 *x * y).ToString());
            }
        }
        class rectangle : polygon
        {
            public override void area( int x , int y)
            {
                MessageBox.Show("The area of rectangle is : " + (x * y).ToString());
            }
        }


        class sqaure : polygon2
        {
            public override void area(int x)
            {
                MessageBox.Show("The area of square is : " + (x * x).ToString());
            }
        }
        
        private void button1_Click(object sender, EventArgs e)

        {
            polygon p= new traingle();
            rectangle r = new rectangle();
            traingle t = new traingle();
            //p.test();
            //p.area(30, 20);
            //r.area(10, 20);
            //t.area(10, 20);
            //p = new rectangle();
            //p.area(30, 20);
            //polygon2 s = new sqaure();
            //s.area(15);
            newshape n = new newshape();
            n.area(10, 20);
            n.area(15);

        }
    }
}
