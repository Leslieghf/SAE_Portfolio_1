using System;
using LL = LinkedList;
using Util = Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        Func<LL.LinkedList<int>.Node, LL.LinkedList<int>.Node, int> nodeComparer = (Node1, Node2) =>
        {
            if (Node1.Content > Node2.Content) return 1;
            if (Node1.Content < Node2.Content) return -1;
            return 0;
        };
        LL.SortableLinkedList<int> myLinkedList = new LL.SortableLinkedList<int>(nodeComparer, new int[] {-82, -41, 25, 62, -34, 85, -64, -99, 64, -69, 17, 0, 79, -97, -97, 30, -8, 21, 86, -23});
        myLinkedList.Output(LL.OutputType.Ascending);
        myLinkedList.Sort(LL.SortingType.BubbleSort);
        myLinkedList.Output(LL.OutputType.Ascending);
    }
}