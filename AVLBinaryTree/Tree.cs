using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLBinaryTree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head;

        public Tree()
        {
            Head = null;
        }

        public int CheckBalance(Node<T> node)
        {
            if(node.isLeftChild() == false && node.isRightChild() == false)
            {
                return 0;
            }
            else
            {
                return node.Right.Height - node.Left.Height;
            }

        }

        public void Balance()
        {

        }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value, 1);
                
            }
            else
            {
                Node<T> current = Head;
                Node<T> node = new Node<T>(value);
                bool done = false;
                do
                {
                    if (value.CompareTo(current.Value) >= 0)
                    {
                        if (current.Right == null)
                        {
                            done = true;
                            current.Right = node;
                            node.Parent = current;
                            if(CheckBalance(node) > 1 || CheckBalance(node) < -1)
                            {
                                Balance();
                            }
                        }
                        else
                        {
                            current.Height++;
                            current = current.Right;
                        }
                    }
                    else if (value.CompareTo(current.Value) < 0)
                    {
                        if (current.Left == null)
                        {
                            done = true;
                            current.Left = node;
                            node.Parent = current;
                            if (CheckBalance(node) > 1 || CheckBalance(node) < -1)
                            {
                                Balance();
                            }
                        }
                        else
                        {
                            current = current.Left;
                        }

                    }

                } while (!done);

            }
        }


    }
}
