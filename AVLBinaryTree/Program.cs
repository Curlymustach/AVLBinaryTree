using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            for (int i = 1; i <= 10; i++)
            {
                tree.Add(int.Parse(Console.ReadLine()));
            }

            //tree.Add(5);
            //tree.Add(3);
            //tree.Add(7);
            //tree.Add(4);
            //tree.Add(2);
            //tree.Add(1);

            tree.InOrderTraverse(tree.Head);

            tree.Delete(5);
            Console.WriteLine("");
            tree.InOrderTraverse(tree.Head);

            Console.ReadKey();

        }
    }
}
