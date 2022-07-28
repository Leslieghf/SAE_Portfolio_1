using System;
using VectorUtils.Test;
using VectorUtils;

namespace Utilities
{
    public static class ConsoleWrapper
    {
        public static TEnum ReadEnum<TEnum>() where TEnum : struct, Enum
        {
        SelectEnum:
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

        public static int ReadInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            do
            {
                Console.WriteLine(message);
                string? consoleInput = Console.ReadLine();
                if (int.TryParse(consoleInput, out int inputInt) && inputInt >= min && inputInt <= max)
                {
                    return inputInt;
                }
                Console.WriteLine("Invalid input, retry!\n");
            } while (true);
        }

        public static float ReadFloat(string message, float min = float.MinValue, float max = float.MaxValue)
        {
            do
            {
                Console.WriteLine(message);
                string? consoleInput = Console.ReadLine();
                if (float.TryParse(consoleInput, out float inputFloat) && inputFloat >= min && inputFloat <= max)
                {
                    return inputFloat;
                }
                Console.WriteLine("Invalid input, retry!\n");
            } while (true);
        }

        public static bool ReadBool(string message)
        {
            do
            {
                Console.WriteLine(message);
                Console.WriteLine("'y' for yes, 'n' for no");
                string? consoleInput = Console.ReadLine();
                if (consoleInput != null)
                {
                    if (consoleInput.ToLower() == "y")
                    {
                        return true;
                    }
                    if (consoleInput.ToLower() == "n")
                    {
                        return false;
                    }
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
