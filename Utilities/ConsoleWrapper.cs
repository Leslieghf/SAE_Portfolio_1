using System;
using VectorUtils.Test;

namespace Utilities
{
    public static class ConsoleWrapper
    {
        public static TEnum ReadEnum<TEnum>() where TEnum : struct, Enum
        {
            SelectEnum:
            Clear();
            WriteEnum<TEnum>();

            Console.WriteLine($"\nPlease enter a valid {typeof(TEnum).Name}:");
            string? consoleInput = Console.ReadLine();
            bool parseEnumSuccess = Enum.TryParse(consoleInput, out TEnum parsedEnum);
            if (!parseEnumSuccess)
            {
                Console.WriteLine("\nInvalid input!");
                Console.Read();
                goto SelectEnum;
            }
            return parsedEnum;
        }
        public static void WriteEnum<TEnum>() where TEnum : struct, Enum
        {
            Console.WriteLine($"\nAvailable {typeof(TEnum).Name}s");
            foreach (string enumEntryName in Enum.GetNames(typeof(TEnum)))
            {
                Console.WriteLine($"\t{enumEntryName}");
            }
        }

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
