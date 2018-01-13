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
                tree.Add(i);
            }


            Console.ReadKey();

        }
    }
}
