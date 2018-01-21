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
            if(node == null)
            {
                return 0;
            }

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

        public void RotateRight(Node<T> node) //Left Child becomes parent
        {
            Node<T> child = node.Left;
            Node<T> parent = node.Parent;

            if(child != null)
            {
                node.Left = child.Right;

                if (child.Right != null)
                {
                    node.Left.Parent = node;
                }
                if (parent != null)
                {
                    if (node.isLeftChild())
                    {
                        node.Parent.Left = child;
                    }
                    if (node.isRightChild())
                    {
                        node.Parent.Right = child;
                    }
                }

                child.Parent = parent;
                node.Parent = child;
                child.Right = node;
                //child.Left = null;
                node.Height = child.Height - 1;
                if (child.Parent == null)
                {
                    Head = child;
                }

            }
        }

        public void RotateLeft(Node<T> node) //Right Child becomes parent
        {
            Node<T> parent = node.Parent;
            Node<T> child = node.Right;

            node.Right = child.Left;
            if (child.Left != null)
            {
                node.Right.Parent = node;
            }
            if (parent != null)
            {
                if (node.isRightChild()) node.Parent.Right = child;
                if (node.isLeftChild()) node.Parent.Left = child;
            }

            child.Parent = parent;
            node.Parent = child;            
            child.Left = node;
            //node.Right = null;
            node.Height = child.Height - 1;
            if (child.Parent == null)
            {
                Head = child;
            }

        }

        public void Balance(Node<T> node)
        {
            //update height
            //set node height to larger child + 1
            //node.Height = node.LargerChildHeight() + 1;

            node.Height = node.LargerChildHeight() + 1;

            //check balance
            if (CheckBalance(node) < -1) //rotate right
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
                    if (value.CompareTo(current.Value) >= 0)//go right
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
                    else if (value.CompareTo(current.Value) < 0)//go left
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

        public Node<T> Find(T value)
        {
            Node<T> temp = Head;

            while (temp.Value.CompareTo(value) != 0)
            {
                if (value.CompareTo(temp.Value) > 0)//move right
                {
                    temp = temp.Right;
                }
                if (value.CompareTo(temp.Value) < 0) //move left
                {
                    temp = temp.Left;
                }
            }

            return temp;

        }

        public void Delete(T value)
        {
            Delete(Find(value));
        }

        public void Delete(Node<T> node)
        {
            if (node.Left == null && node.Right == null)
            {
                if (node.isRightChild())
                {
                    node.Parent.Right = null;
                }
                else
                {
                    node.Parent.Left = null;
                }

                Balance(node.Parent);
            }
            else if (node.Left == null & node.Right != null)
            {
                node.Right.Parent = node.Parent;
                node.Parent.Right = node.Right;

                Balance(node.Parent);
            }
            else if (node.Right == null && node.Left != null)
            {
                node.Left.Parent = node.Parent;
                node.Parent.Left = node.Left;
                Balance(node.Parent);
            }
            else if (node.Left != null && node.Right != null)
            {
                Node<T> temp = node.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                node.Value = temp.Value;
                Delete(temp);
            }
        }

        public void InOrderTraverse(Node<T> node)
        {
            Node<T> temp = node;
            if (node != null)
            {
                if (temp.Left != null)
                {
                    InOrderTraverse(temp.Left);
                }
                Console.Write("{0}, ", temp.Value);
                if (temp.Right != null)
                {
                    //temp = temp.Right;
                    InOrderTraverse(temp.Right);
                }
            }

        }

    }
}
