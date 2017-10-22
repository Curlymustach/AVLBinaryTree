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

        public int checkBalance(Node<T> node)
        {
            if (!node.isLeftChild() && !node.isRightChild())
            {
                return 0;
            }
            else if (node.isLeftChild() && !node.isRightChild())
            {
                return 0 - node.Left.Height;
            }
            else if(node.isRightChild() && !node.isLeftChild())
            {
                return node.Right.Height;
            }
            return node.Right.Height - node.Left.Height;
        }

        public void balance(Node<T> node)
        {
            if (checkBalance(node) < 1) //rotate right
            {
                node = node.Left.Right;
            }
            else if (checkBalance(node) > 1) // rotate left
            {
                node = node.Right.Left;
            }
            else if (checkBalance(node) > 1 && checkBalance(node.Right) <s 1)
            {

            }
            else if (checkBalance(node) < 1 && checkBalance(node.Left) > 1)
            {

            }
        }

        public void add(T value)
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
                            if(checkBalance(node) > 1 || checkBalance(node) < -1)
                            {
                                balance(node);
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
                            if (checkBalance(node) > 1 || checkBalance(node) < -1)
                            {
                                balance(node);
                            }
                        }
                        else
                        {
                            current.Height++;
                            current = current.Left;
                        }

                    }

                } while (!done);

            }
        }


    }
}
