using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLTree<T> where T : IComparable
    {
        public Node? root { get; private set; }
        public Func<T, T, int> ContentComparer;

        public AVLTree(Func<T, T, int> contentComparer)
        {
            ContentComparer = contentComparer;
        }
        public AVLTree(Func<T, T, int> contentComparer, IEnumerable<T> contents)
        {
            ContentComparer = contentComparer;
            foreach (T content in contents)
            {
                Add(content);
            }
        }

        #region Public Methods
        public void Add(T content)
        {
            Node newItem = new Node(content);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        public void Add(IEnumerable<T> contents)
        {
            foreach (T content in contents)
            {
                Add(content);
            }
        }

        public void Delete(T content)
        {
            root = Delete(root, content);
        }
        public void Delete(IEnumerable<T> contents)
        {
            foreach (T content in contents)
            {
                Delete(content);
            }
        }

        public bool Contains(T content)
        {
            return Find(content) != null;
        }

        public Node? Find(T content)
        {
            return Find(content, root);
        }

        public void DisplayTree()
        {
            void InOrderDisplayTree(Node? current)
            {
                if (current != null)
                {
                    InOrderDisplayTree(current.left);
                    Console.Write($"({current.content}) ");
                    InOrderDisplayTree(current.right);
                }
            }

            if (root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        #endregion

        #region Private Methods
        private Node? RecursiveInsert(Node? insertRoot, Node? node)
        {
            if (node == null)
            {
                return null;
            }
            if (insertRoot == null)
            {
                insertRoot = node;
                return insertRoot;
            }

            if (ContentComparer.Invoke(node.content, insertRoot.content) == -1)
            {
                insertRoot.left = RecursiveInsert(insertRoot.left, node);
                insertRoot = BalanceTree(insertRoot);
            }
            else if (ContentComparer.Invoke(node.content, insertRoot.content) == 1)
            {
                insertRoot.right = RecursiveInsert(insertRoot.right, node);
                insertRoot = BalanceTree(insertRoot);
            }
            return insertRoot;
        }

        private Node? BalanceTree(Node? balanceRoot)
        {
            if (balanceRoot == null)
            {
                return null;
            }
            int balanceFactor = BalanceFactor(balanceRoot);
            if (balanceFactor > 1)
            {
                if (BalanceFactor(balanceRoot.left) > 0)
                {
                    balanceRoot = RotateLL(balanceRoot);
                }
                else
                {
                    balanceRoot = RotateLR(balanceRoot);
                }
            }
            else if (balanceFactor < -1)
            {
                if (BalanceFactor(balanceRoot.right) > 0)
                {
                    balanceRoot = RotateRL(balanceRoot);
                }
                else
                {
                    balanceRoot = RotateRR(balanceRoot);
                }
            }
            return balanceRoot;
        }

        private Node? Delete(Node? deleteRoot, T content)
        {
            Node parent;
            if (deleteRoot == null)
            {
                return null;
            }
            else
            {
                if (ContentComparer.Invoke(content, deleteRoot.content) == -1)
                {
                    deleteRoot.left = Delete(deleteRoot.left, content);
                    if (BalanceFactor(deleteRoot) == -2)
                    {
                        if (BalanceFactor(deleteRoot.right) <= 0)
                        {
                            deleteRoot = RotateRR(deleteRoot);
                        }
                        else
                        {
                            deleteRoot = RotateRL(deleteRoot);
                        }
                    }
                }
                else if (ContentComparer.Invoke(content, deleteRoot.content) == 1)
                {
                    deleteRoot.right = Delete(deleteRoot.right, content);
                    if (BalanceFactor(deleteRoot) == 2)
                    {
                        if (BalanceFactor(deleteRoot.left) >= 0)
                        {
                            deleteRoot = RotateLL(deleteRoot);
                        }
                        else
                        {
                            deleteRoot = RotateLR(deleteRoot);
                        }
                    }
                }
                else
                {
                    if (deleteRoot.right != null)
                    {
                        parent = deleteRoot.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        deleteRoot.content = parent.content;
                        deleteRoot.right = Delete(deleteRoot.right, parent.content);
                        if (BalanceFactor(deleteRoot) == 2)
                        {
                            if (BalanceFactor(deleteRoot.left) >= 0)
                            {
                                deleteRoot = RotateLL(deleteRoot);
                            }
                            else
                            {
                                deleteRoot = RotateLR(deleteRoot);
                            }
                        }
                    }
                    else
                    {
                        return deleteRoot.left;
                    }
                }
            }
            return deleteRoot;
        }

        private Node? Find(T content, Node? searchRoot)
        {
            if (searchRoot == null)
            {
                return null;
            }
            if (ContentComparer.Invoke(content, searchRoot.content) == -1)
            {
                if (ContentComparer.Invoke(content, searchRoot.content) == 0)
                {
                    return searchRoot;
                }
                else
                {
                    if (searchRoot.left == null)
                    {
                        return null;
                    }
                    return Find(content, searchRoot.left);
                }
            }
            else
            {
                if (ContentComparer.Invoke(content, searchRoot.content) == 0)
                {
                    return searchRoot;
                }
                else
                {
                    if (searchRoot.right == null)
                    {
                        return null;
                    }
                    return Find(content, searchRoot.right);
                }
            }

        }

        private int GetHeight(Node? current)
        {
            int Max(int l, int r)
            {
                return l > r ? l : r;
            }

            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.left);
                int r = GetHeight(current.right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int BalanceFactor(Node? current)
        {
            if (current == null)
            {
                throw new ArgumentNullException();
            }
            int left = GetHeight(current.left);
            int right = GetHeight(current.right);
            int balanceFactor = left - right;
            return balanceFactor;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
        #endregion

        public sealed class Node
        {
            public T content;
            public Node? left;
            public Node? right;

            public Node(T content)
            {
                this.content = content;
            }
        }
    }
}
