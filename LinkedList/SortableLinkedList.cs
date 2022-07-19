namespace LinkedList
{
    public class SortableLinkedList<T> : LinkedList<T> where T : IComparable
    {
        public Func<Node, Node, int> NodeComparer;

        public SortableLinkedList(Func<Node, Node, int> nodeComparer) : base()
        {
            NodeComparer = nodeComparer;
        }
        public SortableLinkedList(Func<Node, Node, int> nodeComparer, IEnumerable<T> enumerable) : base(enumerable)
        {
            NodeComparer = nodeComparer;
        }

        public void Output(OutputType outputOrder)
        {
            string message = "";
            switch (outputOrder)
            {
                case OutputType.Ascending:
                {
                    foreach (Node node in GetAllNodes())
                    {
                        message += $"{node.Content} ";
                    }
                    break; 
                }
                case OutputType.Descending:
                {
                    foreach (Node node in GetAllNodes(true))
                    {
                        message += $"{node.Content} ";
                    }
                    break; 
                }
                case OutputType.CrossAscending:
                {
                    Node[] nodes = GetAllNodes();
                    int i = 0;
                    int j = nodes.Length - 1;
                    while (i < j)
                    {
                        message += $"{nodes[i].Content} ";
                        message += $"{nodes[j].Content} ";
                        i++;
                        j--;
                    }
                    if (i == j)
                    {
                        message += $"{nodes[i].Content} ";
                    }
                    break; 
                }
                case OutputType.CrossDescending:
                {
                    Node[] nodes = GetAllNodes(true);
                    int i = 0;
                    int j = nodes.Length - 1;
                    while (i < j)
                    {
                        message += $"{nodes[i].Content} ";
                        message += $"{nodes[j].Content} ";
                        i++;
                        j--;
                    }
                    if (i == j)
                    {
                        message += $"{nodes[i].Content} ";
                    }
                    break;
                }
                default:
                    throw new ArgumentException("Invalid output order!");
            }
            Console.WriteLine(message);
        }

        public void Sort(SortingType sortingType)
        {
            switch (sortingType)
            {
                case SortingType.BubbleSort:
                    BubbleSort();
                    break;
                case SortingType.InsertionSort:
                    InsertionSort();
                    break;
                case SortingType.CombSort:
                    CombSort();
                    break;
                default:
                    throw new ArgumentException("Invalid sorting type!");
            }
        }

        private void BubbleSort()
        {
            if (Head == null)
            {
                return;
            }

            Node[] nodes = GetAllNodes();
            ClearBonds(nodes);

            int n = Count - 1;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n; i++)
                {
                    if (NodeComparer.Invoke(nodes[i], nodes[i + 1]) == 1)
                    {
                        Node temp = nodes[i];
                        nodes[i] = nodes[i + 1];
                        nodes[i + 1] = temp;

                        swapped = true;
                    }
                }
                n--;
            } while (swapped && n>= 1);

            SetAllNodes(nodes);
        }

        private void InsertionSort()
        {
            if (Head == null)
            {
                return;
            }

            Node[] nodes = GetAllNodes();
            ClearBonds(nodes);

            for (int i = 1; i < nodes.Count(); i++)
            {
                Node nodeToSort = nodes[i];
                int j = i;
                while (j > 0 && NodeComparer.Invoke(nodeToSort, nodes[j-1]) == -1)
                {
                    nodes[j] = nodes[j - 1];
                    j--;
                }
                nodes[j] = nodeToSort;
            }

            SetAllNodes(nodes);
        }

        private void CombSort()
        {
            int GetNextGap(int gap)
            {
                gap = (gap * 10) / 13;
                if (gap < 1)
                {
                    return 1;
                }
                return gap;
            }

            Node[] nodes = GetAllNodes();
            ClearBonds(nodes);

            int n = nodes.Length;
            int gap = n;
            bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);
                swapped = false;

                for (int i = 0; i < n - gap; i++)
                {
                    if (NodeComparer.Invoke(nodes[i], nodes[i + gap]) == 1)
                    {
                        Node temp = nodes[i];
                        nodes[i] = nodes[i + gap];
                        nodes[i + gap] = temp;
                        swapped = true;
                    }
                }
            }

            SetAllNodes(nodes);
        }
    }

    public enum SortingType
    {
        BubbleSort,
        InsertionSort,
        CombSort
    }

    public enum OutputType
    {
        Ascending,
        Descending,
        CrossAscending,
        CrossDescending
    }
}
