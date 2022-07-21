using System.Collections;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public Node? Head { get; private set; }
        public Node? Tail { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public LinkedList(IEnumerable<T> enumerable)
        {
            for (int i = 0; i < enumerable.Count(); i++)
            {
                AddLast(new Node(enumerable.ElementAt(i)));
            }
            Count = enumerable.Count();
        }

        public void AddFirst(Node newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }
            AddBefore(Head, newNode);
        }
        public void AddFirst(T newContent)
        {
            Node newNode = new Node(newContent);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }
            AddBefore(Head, newNode);
        }
        public void AddFirst(IEnumerable<Node> newNodes)
        {
            foreach (Node newNode in newNodes.Reverse())
            {
                AddFirst(newNode);
            }
        }
        public void AddFirst(IEnumerable<T> newContents)
        {
            foreach (T newContent in newContents.Reverse())
            {
                AddFirst(newContent);
            }
        }

        public void AddLast(Node newNode)
        {
            if (Tail == null)
            {
                AddFirst(newNode);
            }
            AddAfter(Tail, newNode);
        }
        public void AddLast(T newContent)
        {
            Node newNode = new Node(newContent);
            if (Tail == null)
            {
                AddFirst(newNode);
            }
            AddAfter(Tail, newNode);
        }
        public void AddLast(IEnumerable<Node> newNodes)
        {
            foreach (Node newNode in newNodes)
            {
                AddLast(newNode);
            }
        }
        public void AddLast(IEnumerable<T> newContents)
        {
            foreach (T newContent in newContents)
            {
                AddLast(newContent);
            }
        }

        public void AddBefore(Node before, Node newNode)
        {
            if (newNode == Head && newNode == Tail)
            {
                return;
            }
            Remove(newNode);
            newNode.Previous = before.Previous;
            newNode.Next = before;
            if (before.Previous == null)
            {
                Head = newNode;
            }
            else
            {
                before.Previous.Next = newNode;
            }
            before.Previous = newNode;
            Count++;
        }
        public void AddBefore(Node before, T newContent)
        {
            Node newNode = new Node(newContent);
            if (newNode == Head && newNode == Tail)
            {
                return;
            }
            Remove(newNode);
            newNode.Previous = before.Previous;
            newNode.Next = before;
            if (before.Previous == null)
            {
                Head = newNode;
            }
            else
            {
                before.Previous.Next = newNode;
            }
            before.Previous = newNode;
            Count++;
        }
        public void AddBefore(Node before, IEnumerable<Node> newNodes)
        {
            foreach (Node newNode in newNodes)
            {
                AddBefore(before, newNode);
            }
        }
        public void AddBefore(Node before, IEnumerable<T> newContents)
        {
            foreach (T newContent in newContents)
            {
                AddBefore(before, newContent);
            }
        }

        public void AddAfter(Node after, Node newNode)
        {
            if (newNode == Head && newNode == Tail)
            {
                return;
            }
            Remove(newNode);
            newNode.Previous = after;
            newNode.Next = after.Next;
            if (after.Next == null)
            {
                Tail = newNode;
            }
            else
            {
                after.Next.Previous = newNode;
            }
            after.Next = newNode;
            Count++;
        }
        public void AddAfter(Node after, T newContent)
        {
            Node newNode = new Node(newContent);
            if (newNode == Head && newNode == Tail)
            {
                return;
            }
            Remove(newNode);
            newNode.Previous = after;
            newNode.Next = after.Next;
            if (after.Next == null)
            {
                Tail = newNode;
            }
            else
            {
                after.Next.Previous = newNode;
            }
            after.Next = newNode;
            Count++;
        }
        public void AddAfter(Node after, IEnumerable<Node> newNodes)
        {
            foreach (Node newNode in newNodes.Reverse())
            {
                AddAfter(after, newNode);
            }
        }
        public void AddAfter(Node after, IEnumerable<T> newContents)
        {
            foreach (T newContent in newContents.Reverse())
            {
                AddAfter(after, newContent);
            }
        }

        public void AddAtPosition(int position, Node newNode)
        {
            if (position == 1)
            {
                AddFirst(newNode);
                return;
            }

            Node? node = Head;
            int currentPosition = 1;
            while (node != null && currentPosition != position)
            {
                node = node.Next;
                currentPosition += 1;
            }
            if (node != null)
            {
                AddBefore(node, newNode);
            }
            else
            {
                AddLast(newNode);
            }
        }
        public void AddAtPosition(int position, T newContent)
        {
            Node newNode = new Node(newContent);
            if (position == 1)
            {
                AddFirst(newNode);
                return;
            }

            Node? node = Head;
            int currentPosition = 1;
            while (node != null && currentPosition != position)
            {
                node = node.Next;
                currentPosition += 1;
            }
            if (node != null)
            {
                AddBefore(node, newNode);
            }
            else
            {
                AddLast(newNode);
            }
        }
        public void AddAtPosition(int position, IEnumerable<Node> newNodes)
        {
            foreach (Node newNode in newNodes)
            {
                AddAtPosition(position, newNode);
                position++;
            }
        }
        public void AddAtPosition(int position, IEnumerable<T> newContents)
        {
            foreach (T newContent in newContents)
            {
                AddAtPosition(position, newContent);
                position++;
            }
        }

        public Node GetAtPosition(int position)
        {
            if (position <= 0)
            {
                throw new ArgumentOutOfRangeException("Position must not be less than 1!");
            }
            if (position > Count)
            {
                throw new ArgumentOutOfRangeException("Position must not be more than the node count");
            }
            return GetAllNodes()[position - 1];
        }
        public Node[] GetAtPositions(int positionStart, int positionEnd)
        {
            if (positionStart > Count || positionEnd > Count)
            {
                throw new ArgumentOutOfRangeException("Positions must not be more than the node count!");
            }
            if (positionStart <= 0 || positionEnd <= 0)
            {
                throw new ArgumentOutOfRangeException("Positions must not be less than 1!");
            }
            if (positionStart > positionEnd)
            {
                throw new ArgumentOutOfRangeException("Start position must not be more than the end position!");
            }

            Node[] nodes = new Node[positionEnd - positionStart + 1];
            for (int i = positionStart; i <= positionEnd; i++)
            {
                nodes[i - positionStart] = GetAtPosition(i);
            }
            return nodes;
        }

        public void RemoveAtPosition(int position)
        {
            if (position <= 0)
            {
                throw new ArgumentOutOfRangeException("Position must not be less than 1!");
            }
            if (position > Count)
            {
                throw new ArgumentOutOfRangeException("Position must not be more than the node count");
            }
            Remove(GetAtPosition(position));
        }
        public void RemoveAtPositions(int positionStart, int positionEnd)
        {
            if (positionStart > Count || positionEnd > Count)
            {
                throw new ArgumentOutOfRangeException("Positions must not be more than the node count!");
            }
            if (positionStart <= 0 || positionEnd <= 0)
            {
                throw new ArgumentOutOfRangeException("Positions must not be less than 1!");
            }
            if (positionStart > positionEnd)
            {
                throw new ArgumentOutOfRangeException("Start position must not be more than the end position!");
            }

            for (int i = positionEnd; i >= positionStart; i--)
            {
                RemoveAtPosition(i);
            }
        }

        public void Remove(Node node)
        {
            if (!Contains(node))
            {
                return;
            }
            if (node == Head)
            {
                Head = Head.Next;
            }
            if (node == Tail)
            {
                Tail = Tail.Previous;
            }
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            node.Previous = null;
            node.Next = null;
            Count--;
        }
        public void Remove(T content)
        {
            Node? node = GetNode(content);
            if (node == null)
            {
                return;
            }
            Remove(node);
        }
        public void Remove(IEnumerable<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                Remove(node);
            }
        }
        public void Remove(IEnumerable<T> contents)
        {
            foreach (T content in contents)
            {
                Remove(content);
            }
        }
        public void RemoveAll(T content)
        {
            Node[] nodes = GetNodes(content);
            if (nodes.Count() == 0)
            {
                return;
            }
            Remove(nodes);
        }
        public void RemoveAll(IEnumerable<T> contents)
        {
            foreach (T content in contents)
            {
                RemoveAll(content);
            }
        }

        public bool Contains(Node checkNode)
        {
            foreach (Node node in GetAllNodes())
            {
                if (node.Equals(checkNode))
                {
                    return true;
                }
            }
            return false;
        }
        public bool Contains(T checkContent)
        {
            foreach (Node node in GetAllNodes())
            {
                if (node.Content.Equals(checkContent))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public static void ClearBonds(Node node)
        {
            node.Previous = null;
            node.Next = null;
        }
        public static void ClearBonds(IEnumerable<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                ClearBonds(node);
            }
        }

        public Node? GetNode(T content)
        {
            Node[] nodes = GetAllNodes();
            foreach (Node node in nodes)
            {
                if (node.Content.Equals(content))
                {
                    return node;
                }
            }
            return null;
        }
        public Node[] GetNodes(T content)
        {
            Node[] nodes = GetAllNodes();
            List<Node> nodesList = new List<Node>();
            foreach (Node node in nodes)
            {
                if (node.Content.Equals(content))
                {
                    nodesList.Add(node);
                }
            }
            return nodesList.ToArray();
        }
        public Node[] GetAllNodes(bool reversed = false)
        {
            if (Head == null || Count == 0)
            {
                return new Node[0];
            }

            Node currentNode = Head;
            Node[] nodes = new Node[Count];
            for (int i = 0; i < Count; i++)
            {
                nodes[i] = currentNode;
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
            }
            return reversed ? nodes.Reverse().ToArray() : nodes;
        }

        public void SetAllNodes(IEnumerable<Node> nodes)
        {
            Clear();
            AddFirst(nodes);
        }

        public sealed class Node
        {
            public T Content;
            public Node? Previous;
            public Node? Next;

            public Node(T value)
            {
                Content = value;
                Previous = null;
                Next = null;
            }
        }
    }
}
