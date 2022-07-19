using System;

namespace Utilities
{
    public static class ConsoleWrapper
    {
        public static int ReadInt(string message)
        {
            do
            {
                Clear();
                Console.WriteLine(message);
                string? consoleInput = Console.ReadLine();
                if (int.TryParse(consoleInput, out int inputInt))
                {
                    return inputInt;
                }
                Console.WriteLine("Invalid input, retry!\n");
            } while (true);
        }

        public static float ReadFloat(string message)
        {
            do
            {
                Clear();
                Console.WriteLine(message);
                string? consoleInput = Console.ReadLine();
                if (float.TryParse(consoleInput, out float inputFloat))
                {
                    return inputFloat;
                }
                Console.WriteLine("Invalid input, retry!\n");
            } while (true);
        }

        public static void Clear()
        {
            Console.Clear();
        }
    } 
}
