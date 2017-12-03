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
            if (node.Left == null && node.Right == null)
            {
                return 0;
            }
            else if (node.Left != null && node.Right == null)
            {
                return 0 - node.Left.Height;
            }
            else if (node.Right != null && node.Left == null)
            {
                return node.Right.Height;
            }
            return node.Right.Height - node.Left.Height;
        }

        public void RotateRight(Node<T> node)
        {
            node.Left = node;
            node = node.Left.Right;
        }

        public void RotateLeft(Node<T> node)
        {
            node.Right = node;
            node = node.Right.Left;
        }

        public void Balance(Node<T> node)
        {
            //update height
            //set node height to larger child + 1
            //node.Height = node.LargerChildHeight() + 1;

            node.Height = node.LargerChildHeight() + 1;

            //check balance
            if (CheckBalance(node) < 1) //rotate right
            {
                if (CheckBalance(node.Left) > 0) //check for double rotate
                {
                    //rotate node.Left to the left
                    RotateLeft(node.Left);
                }

                //rotate node right
                RotateRight(node);
            }
            else if (CheckBalance(node) > 1) // rotate left
            {
                if (CheckBalance(node.Right) < 0) //check for double rotate
                {
                    //rotate node.Right to the right
                    RotateRight(node.Right);
                }

                //rotate node left
                RotateLeft(node);
            }

            if (node.Parent != null)
            {
                Balance(node.Parent);
            }
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
                Node<T> node = new Node<T>(value, 1);
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
                            Balance(node);
                        }
                        else
                        {
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
                            Balance(node);
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
