namespace getandsetdemo
{
    class customer
    {
        private int id;
         public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;

            }
        }
        private string name;
        public string Name{


            set {
                name = value;
                }
            get
            {
                return name;
            }
        }
        public  void setid(int a)
        {
            id = a;
        }
        public int getid()
        {
            return id;
        }
        public void setname(string b)
        {
            name = b;
        }
        public string getname()
        {
            return name;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c = new customer();
            c.setid(101);
            c.setname("John Doe");
            customer d = new customer();
            d.Id = 101;
            d.Name = "John Doe";
            Console.WriteLine(d.Id + d.Name);

            

            Console.WriteLine($"the id is {c.getid} & the name is {c.getname}");
        }
    }
}
