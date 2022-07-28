using Utilities;
using LL = LinkedList;
using AVL = AVLTree;
using VT = VectorUtils.Test;

public class Program
{
    public static void Main(string[] args)
    {
        bool repeat;
        do
        {
            ConsoleWrapper.WriteEnum<Project>();
            Project project = ConsoleWrapper.ReadEnum<Project>();
            Console.WriteLine("\n\n\n");

            switch (project)
            {
                case Project.AVLTree:
                    TestAVLTree();
                    break;
                case Project.LinkedList:
                    TestLinkedList();
                    break;
                case Project.MonsterFight:
                    TestMonsterFight();
                    break;
                case Project.Vector:
                    TestVectorUtils();
                    break;
                default:
                    throw new ArgumentException("Invalid project!");
            }
            repeat = ConsoleWrapper.ReadBool("Do you want to try another project?"); 
        } while (repeat);
        Environment.Exit(0);
    }

    public static void TestAVLTree()
    {
        Func<int, int, int> contentComparer = (content1, content2) =>
        {
            if (content1 > content2) return 1;
            if (content1 < content2) return -1;
            return 0;
        };
        AVL.AVLTree<int> myAVLTree = new AVL.AVLTree<int>(contentComparer);
        myAVLTree.Add(TestUtils.RandomInts(50, 0, 100));
        AVLTreePrinter.Print(myAVLTree.Root);
        myAVLTree.Delete(TestUtils.RandomInts(50, 0, 100));
        AVLTreePrinter.Print(myAVLTree.Root);

        Console.WriteLine("\n\n\nPress any key to end the project demonstration!");
        Console.ReadKey();
    }
    public static void TestLinkedList()
    {
        Func<LL.LinkedList<int>.Node, LL.LinkedList<int>.Node, int> nodeComparer = (Node1, Node2) =>
        {
            if (Node1.Content > Node2.Content) return 1;
            if (Node1.Content < Node2.Content) return -1;
            return 0;
        };
        LL.SortableLinkedList<int> myLinkedList = new LL.SortableLinkedList<int>(nodeComparer);
        myLinkedList.AddFirst(TestUtils.RandomInts(25, 0, 100));
        myLinkedList.Output(LL.OutputType.Ascending);
        myLinkedList.Sort(LL.SortingType.BubbleSort);
        myLinkedList.Output(LL.OutputType.Ascending);

        Console.WriteLine("\n\n\nPress any key to end the project demonstration!");
        Console.ReadKey();
    }
    public static void TestMonsterFight()
    {
        GameManager gameManager = new GameManager();

        Console.WriteLine("\n\n\nPress any key to end the project demonstration!");
        Console.ReadKey();
    }
    public static void TestVectorUtils()
    {
        VT.VectorUtilsTest vectorUtilsTest = new VT.VectorUtilsTest();

        Console.WriteLine("\n\n\nPress any key to end the project demonstration!");
        Console.ReadKey();
    }

    public enum Project
    {
        AVLTree,
        LinkedList,
        MonsterFight,
        Vector
    }
}