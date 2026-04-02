namespace var_dynamic_demo
    {
    public class Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack Quack");
        }
    }
    public class Person
    {
        public void quack()
        {
            Console.WriteLine("person imitating as quack");
        }
    }
    internal class Program
    {
        public void IntheForest(dynamic duck)
        {
            duck.quack();
        }
        //public void IntheForest(Person person)
        //{
        //    person.quack();
        //}
        static void Main(string[] args)
        {
            int x = 23;

            var k = 45;
            var name = "hello";
            var emp = new List<string>() {"Aman","ram"};

            //0k = "ram";   it will give error because var is statically typed
            dynamic d = 56;
            d = " string";

            Program obj = new Program();
            Duck duck = new Duck();
            Person person = new Person();
            obj.IntheForest(duck);
            obj.IntheForest(person);
            Console.ReadLine();


        }
    }
}
