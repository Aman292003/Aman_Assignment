namespace LinkedList
{
    public class Node
    {
        public int element;
        public Node next;
        public Node(int e, Node n)
        {
            element = e;
            next = n;
        }

    }
    internal class Program
    {
        private Node head;
        private Node tail;
        private int size;

        public Program()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public int length()
        {
            return size;
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        public void addFirst(int e)
        {
            Node newest = new Node(e, null);
            if (size == 0)
            {
                head = newest;
                tail = newest;
            }
            else
            {
                newest.next = head;
                head = newest;
            }
            size++;
        }
        public void addLast(int e)
        {
            Node newest = new Node(e, null);
            if (size == 0)
            {
                head = newest;
                
            }
            else
            {
                tail.next = newest;
                
            }
            tail = newest;
            size++;
        }
        public void addpos(int e,int pos)
        {
            if (pos < 0 || pos > size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            if (pos == 0)
            {
                addFirst(e);
                return;
            }
            if (pos == size)
            {
                addLast(e);
                return;
            }

            Node newest = new Node(e, null);
            Node p = head;
            for (int i = 1; i < pos; i++)
            {
                p = p.next;
            }
            newest.next = p.next;
            p.next = newest;
            size++;
          }
        public void Display()
        {
            Node p = head;
            while (p != null)
            {
                Console.Write(p.element + "----> ");
                p = p.next;

            }
             

        }
        public void removeFirst()
        {
            if (size == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }
            head = head.next;
            size--;
            if (size == 0)
            {
                tail = null;
            }
        }
        public void removeLast()
        {
            if (size == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (size == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node p = head;
                while (p.next != tail)
                {
                    p = p.next;
                }
                int ele = p.next.element;
                Console.WriteLine("Removed element: " + ele);
                p.next = null;
                tail = p;
            }
            size--;
        }
        public void removepos(int pos)
        {
            if (pos < 0 || pos >= size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }
            if (pos == 0)
            {
                removeFirst();
                return;
            }
            if (pos == size - 1)
            {
                removeLast();
                return;
            }
            Node p = head;
            for (int i = 1; i < pos; i++)
            {
                p = p.next;
            }
            int ele = p.next.element;
            Console.WriteLine("Removed element: " + ele);
            p.next = p.next.next;
            size--;
        }
        public void search(int key)
        {
            Node p = head;
            int pos = 0;
            while (p != null)
            {
                if (p.element == key)
                {
                    Console.WriteLine("Element found at position: " + pos);
                    return;
                }
                p = p.next;
                pos++;
            }
            Console.WriteLine("Element not found in the list.");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.addFirst(10);
            p.addFirst(20);
            p.addLast(30);
            p.Display();

            p.length();
            p.isEmpty();
            Console.WriteLine();
            p.addpos(60,1);
            p.Display();
            Console.WriteLine();

            p.removeLast();
            p.Display();
             
        }
    }
}
