namespace indexr
{
    class abcd
    {
        private string[] val = new string[3];

        public string this[int index]
        {
            set
            {
                val[index] = value;

            }
            get
            {
                return val[index];
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            abcd obj = new abcd();
            //when  i want to use object array as property 
            // then  i will use indexers
            obj[0] = "Csharp";
            obj[1] = "Java";
            obj[2] = "C++";


            // obj[3] = "python";// out of bound exception 

            Console.WriteLine($"{obj[0]}-{obj[1]}-{obj[2]}");
        }
    }
}
