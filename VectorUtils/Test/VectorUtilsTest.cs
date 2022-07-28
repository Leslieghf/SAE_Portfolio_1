using Utilities;

namespace VectorUtils.Test
{
    public class VectorUtilsTest
    {
        public VectorUtilsTest()
        {
            Console.WriteLine("Available Operator Tests");
            foreach (string testName in Enum.GetNames(typeof(VectorUtilTestOperator)))
            {
                Console.WriteLine($"\t{testName}");
            }

            Console.WriteLine("\nAvailable Method Tests");
            foreach (string testName in Enum.GetNames(typeof(VectorUtilTestMethod)))
            {
                Console.WriteLine($"\t{testName}");
            }

        SelectTest:
            Console.WriteLine("\nPlease enter a valid test:");
            string? consoleInput = Console.ReadLine();
            bool parseOperatorSuccess = Enum.TryParse(consoleInput, out VectorUtilTestOperator testOperator);
            bool parseMethodSuccess = Enum.TryParse(consoleInput, out VectorUtilTestMethod testMethod);

            if (!parseOperatorSuccess && !parseMethodSuccess)
            {
                Console.WriteLine("\nInvalid input!");
                goto SelectTest;
            }
            else if (parseOperatorSuccess)
            {
                Console.Clear();
                TestOperator(testOperator);
            }
            else if (parseMethodSuccess)
            {
                Console.Clear();
                TestMethod(testMethod);
            }



        }

        public static void TestOperator(VectorUtilTestOperator vectorUtilTestOperator)
        {
            Console.WriteLine();
            switch (vectorUtilTestOperator)
            {
                case VectorUtilTestOperator.VectorNegate:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        Vector3 outputVector = -inputVector;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = -inputVector");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorVectorAddition:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVectorA = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        Vector3 inputVectorB = ReadVector3("Creating Vector B:");
                        Vector3 outputVector = inputVectorA + inputVectorB;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector A = {inputVectorA}");
                        Console.WriteLine($"Vector B = {inputVectorB}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVectorA + inputVectorB");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorIntAddition:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        int inputInt = ConsoleWrapper.ReadInt("Please enter an integer:");
                        Vector3 outputVector = inputVector + inputInt;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine($"Int = {inputInt}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVector + inputInt");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorVectorSubtraction:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVectorA = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        Vector3 inputVectorB = ReadVector3("Creating Vector B:");
                        Vector3 outputVector = inputVectorA - inputVectorB;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector A = {inputVectorA}");
                        Console.WriteLine($"Vector B = {inputVectorB}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVectorA - inputVectorB");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorIntSubtraction:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        int inputInt = ConsoleWrapper.ReadInt("Please enter an integer:");
                        Vector3 outputVector = inputVector - inputInt;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine($"Int = {inputInt}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVector - inputInt");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorIntMultiplication:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        int inputInt = ConsoleWrapper.ReadInt("Please enter an integer:");
                        Vector3 outputVector = inputVector * inputInt;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine($"Int = {inputInt}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVector * inputInt");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestOperator.VectorIntDivision:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestOperator}");
                        Vector3 inputVector = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        int inputInt = ConsoleWrapper.ReadInt("Please enter an integer:");
                        Vector3 outputVector = inputVector / inputInt;

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine($"Int = {inputInt}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = inputVector / inputInt");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                default:
                    throw new Exception("Invalid operator!");
            }

            Console.WriteLine("\nDone Testing!");
            Console.ReadKey();
        }
        public static void TestMethod(VectorUtilTestMethod vectorUtilTestMethod)
        {
            switch (vectorUtilTestMethod)
            {
                case VectorUtilTestMethod.Length:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        float outputFloat = Vector3.Length(inputVector);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputFloat = Length(inputVector)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Float = {outputFloat}");

                        break;
                    }
                case VectorUtilTestMethod.SquaredLength:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        float outputFloat = Vector3.SquaredLength(inputVector);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputFloat = SquaredLength(inputVector)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Float = {outputFloat}");

                        break;
                    }
                case VectorUtilTestMethod.Normalize:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVector = ReadVector3("Creating Vector:");
                        Console.WriteLine();
                        Vector3 outputVector = Vector3.Normalize(inputVector);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector = {inputVector}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = Normalize(inputVector)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestMethod.Distance:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVectorA = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        Vector3 inputVectorB = ReadVector3("Creating Vector B:");
                        Console.WriteLine();
                        float outputFloat = Vector3.Distance(inputVectorA, inputVectorB);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector A = {inputVectorA}");
                        Console.WriteLine($"Vector B = {inputVectorA}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputFloat = Distance(inputVectorA, inputVectorB)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Float = {outputFloat}");

                        break;
                    }
                case VectorUtilTestMethod.DotProduct:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVectorA = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        Vector3 inputVectorB = ReadVector3("Creating Vector B:");
                        Console.WriteLine();
                        float outputFloat = Vector3.DotProduct(inputVectorA, inputVectorB);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector A = {inputVectorA}");
                        Console.WriteLine($"Vector B = {inputVectorA}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputFloat = DotProduct(inputVectorA, inputVectorB)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Float = {outputFloat}");

                        break;
                    }
                case VectorUtilTestMethod.CrossProduct:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputVectorA = ReadVector3("Creating Vector A:");
                        Console.WriteLine();
                        Vector3 inputVectorB = ReadVector3("Creating Vector B:");
                        Console.WriteLine();
                        Vector3 outputVector = Vector3.CrossProduct(inputVectorA, inputVectorB);

                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Vector A = {inputVectorA}");
                        Console.WriteLine($"Vector B = {inputVectorA}");
                        Console.WriteLine("\nTest Code:");
                        Console.WriteLine("outputVector = CrossProduct(inputVectorA, inputVectorB)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestMethod.NearestVector:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputOriginVector = ReadVector3("Creating Origin Vector:");
                        Console.WriteLine();
                        Vector3[] inputVectorArray = ReadVector3Array("Creating Vector Array:");
                        Console.WriteLine();
                        Vector3 outputVector = Vector3.NearestVector(inputOriginVector, inputVectorArray);
                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Origin Vector = {inputOriginVector}");
                        Console.WriteLine("\nVector Array:");
                        for (int i = 0; i < inputVectorArray.Length; i++)
                        {
                            Console.WriteLine($"\tVector {i} = {inputVectorArray[i]}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Test Code:");
                        Console.WriteLine("outputVector = NearestVector(inputOriginVector, inputVectorArray)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                case VectorUtilTestMethod.FurthestVector:
                    {
                        Console.WriteLine($"Selected {vectorUtilTestMethod}");
                        Vector3 inputOriginVector = ReadVector3("Creating Origin Vector:");
                        Console.WriteLine();
                        Vector3[] inputVectorArray = ReadVector3Array("Creating Vector Array:");
                        Console.WriteLine();
                        Vector3 outputVector = Vector3.FurthestVector(inputOriginVector, inputVectorArray);
                        Console.Clear();
                        Console.WriteLine("Input:");
                        Console.WriteLine($"Origin Vector = {inputOriginVector}");
                        Console.WriteLine("\nVector Array:");
                        for (int i = 0; i < inputVectorArray.Length; i++)
                        {
                            Console.WriteLine($"\tVector {i} = {inputVectorArray[i]}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Test Code:");
                        Console.WriteLine("outputVector = FurthestVector(inputOriginVector, inputVectorArray)");
                        Console.WriteLine("\nOutput:");
                        Console.WriteLine($"Vector = {outputVector}");

                        break;
                    }
                default:
                    throw new Exception("Invalid method!");
            }
        }

        public static Vector3[] ReadVector3Array(string message)
        {
        GetArrayLength:
            int arrayLength = ConsoleWrapper.ReadInt("Enter Array Length:");
            if (arrayLength < 1)
            {
                Console.WriteLine($"Array Length must be atleast 1!");
                goto GetArrayLength;
            }

            Vector3[] vectorArray = new Vector3[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                vectorArray[i] = ReadVector3($"Creating Vector No. {i}:");
            }

            return vectorArray;
        }
        public static Vector3 ReadVector3(string message)
        {
            Console.WriteLine(message);
            int x = ConsoleWrapper.ReadInt("Please enter an integer for the x component:");
            int y = ConsoleWrapper.ReadInt("Please enter an integer for the y component:");
            int z = ConsoleWrapper.ReadInt("Please enter an integer for the z component:");
            return new Vector3(x, y, z);
        }
    }

    public enum VectorUtilTestOperator
    {
        VectorNegate,
        VectorVectorAddition,
        VectorIntAddition,
        VectorVectorSubtraction,
        VectorIntSubtraction,
        VectorIntMultiplication,
        VectorIntDivision,
    }

    public enum VectorUtilTestMethod
    {
        Length,
        SquaredLength,
        Normalize,
        Distance,
        DotProduct,
        CrossProduct,
        NearestVector,
        FurthestVector
    }
}