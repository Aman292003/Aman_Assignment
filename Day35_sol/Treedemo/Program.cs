namespace Treedemo
{
    class Treenode
    {
        public int element;
        public Treenode left;
        public Treenode right;

        public Treenode(int e = 0)
        {
            element = e;
            left = null;
            right = null;
        }

    }
    class bst
    { 

        public Treenode root;
        public Treenode insert(Treenode node, int element)
        {
            if (node == null)
            {
                return new Treenode(element);
            }
            if (element <= node.element)
            {
                node.left = insert(node.left, element);
            }
            else if (element > node.element)
            {
                node.right = insert(node.right, element);
            }
            return node;
        }
        public void Insert(int element)
        {
            root = insert(root, element);
        }
        public Treenode search(Treenode node, int element)
        {
            if (node == null || node.element == element)
            {
                return node;
            }
            if (element <= node.element)
            {
                return search(node.left, element);
            }
            else
            {
                return search(node.right, element);
            }
        }
        public void Search(int element)
        {
            Treenode result = search(root, element);
            if (result != null)
            {
                Console.WriteLine("Element " + element + " found in the tree.");
            }
            else
            {
                Console.WriteLine("Element " + element + " not found in the tree.");
            }
        }
        public void inorder(Treenode node)
        {
            if (node != null)
            {
                inorder(node.left);
                Console.Write(node.element + " ");
                inorder(node.right);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bst tree = new bst();
            tree.Insert(50);
            tree.Insert(26);
            tree.Insert(72);
            tree.Insert(48);
            tree.Insert(39);

            Console.WriteLine("Inorder traversal of the binary search tree:");
            tree.inorder(tree.root);
            Console.WriteLine();
            tree.Search(39);
        }
    }
}
