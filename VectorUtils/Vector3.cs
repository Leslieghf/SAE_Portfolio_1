namespace VectorUtils
{
    public class Vector3
    {
        #region Fields
        public static Vector3 zero { get { return new Vector3(0, 0, 0); } }
        public static Vector3 one { get { return new Vector3(1, 1, 1); } }
        public static Vector3 up { get { return new Vector3(0, 1, 0); } }
        public static Vector3 down { get { return new Vector3(0, -1, 0); } }
        public static Vector3 forward { get { return new Vector3(0, 0, 1); } }
        public static Vector3 back { get { return new Vector3(0, 0, -1); } }
        public static Vector3 left { get { return new Vector3(-1, 0, 0); } }
        public static Vector3 right { get { return new Vector3(1, 0, 0); } }
        public static Vector3 posInfinity { get { return new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vector3 negInfinity { get { return new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }

        private float x;
        private float y;
        private float z;
        #endregion

        #region Properties
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public float Z { get { return z; } set { z = value; } }

        public float magnitude { get { return Length(); } }
        public float squaredMagnitude { get { return SquaredLength(); } }
        public Vector3 normalized { get { return Normalize(); } }
        #endregion

        #region Constructors
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float n)
        {
            x = n;
            y = n;
            z = n;
        }

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        #endregion

        #region Operator Overloads

        #region Special
        public static Vector3 operator -(Vector3 vector)
        {
            return new Vector3(-vector.x, -vector.y, -vector.z);
        }
        #endregion

        #region Addition
        public static Vector3 operator + (Vector3 vectorAddendA, Vector3 vectorAddendB)
        {
            return new Vector3(vectorAddendA.x + vectorAddendB.x, vectorAddendA.y + vectorAddendB.y, vectorAddendA.z + vectorAddendB.z);
        }

        public static Vector3 operator + (Vector3 vectorAddend, float floatAddend)
        {
            return new Vector3(vectorAddend.x + floatAddend, vectorAddend.y + floatAddend, vectorAddend.z + floatAddend);
        }
        #endregion

        #region Subtraction
        public static Vector3 operator - (Vector3 vectorMinuend, Vector3 vectorSubtrahend)
        {
            return new Vector3(vectorMinuend.x - vectorSubtrahend.x, vectorMinuend.y - vectorSubtrahend.y, vectorMinuend.z - vectorSubtrahend.z);
        }

        public static Vector3 operator - (Vector3 vectorMinuend, float floatSubtrahend)
        {
            return new Vector3(vectorMinuend.x - floatSubtrahend, vectorMinuend.y - floatSubtrahend, vectorMinuend.z - floatSubtrahend);
        }
        #endregion

        #region Multiplication
        public static Vector3 operator * (Vector3 vectorMultiplicand, float floatMultiplier)
        {
            return new Vector3(vectorMultiplicand.x * floatMultiplier, vectorMultiplicand.y * floatMultiplier, vectorMultiplicand.z * floatMultiplier);
        }
        #endregion

        #region Division
        public static Vector3 operator / (Vector3 vectorDividend, float floatDivisor)
        {
            return new Vector3(vectorDividend.x / floatDivisor, vectorDividend.y / floatDivisor, vectorDividend.z / floatDivisor);
        }
        #endregion

        #endregion

        #region Methods

        #region Length
        public static float Length(Vector3 vector)
        {
            return MathF.Sqrt(MathF.Pow(vector.x, 2) + MathF.Pow(vector.y, 2) + MathF.Pow(vector.z, 2));
        }
        public float Length()
        {
            return MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2) + MathF.Pow(z, 2));
        }
        #endregion

        #region SquaredLength
        public static float SquaredLength(Vector3 vector)
        {
            return MathF.Pow(vector.x, 2) + MathF.Pow(vector.y, 2) + MathF.Pow(vector.z, 2);
        }
        public float SquaredLength()
        {
            return MathF.Pow(x, 2) + MathF.Pow(y, 2) + MathF.Pow(z, 2);
        }
        #endregion

        #region Normalize
        public static Vector3 Normalize(Vector3 vector)
        {
            float length = vector.magnitude;
            return new(vector.x / length, vector.y / length, vector.z / length);
        }
        public Vector3 Normalize()
        {
            float length = magnitude;
            return new(x / length, y / length, z / length);
        }
        #endregion

        #region Distance
        public static float Distance(Vector3 originVector, Vector3 targetVector)
        {
            return MathF.Sqrt(MathF.Pow(targetVector.x - originVector.x, 2) + MathF.Pow(targetVector.y - originVector.y, 2) + MathF.Pow(targetVector.z - originVector.z, 2));
        }
        public float Distance(Vector3 targetVector)
        {
            return Distance(this, targetVector);
        }
        #endregion

        #region DotProduct
        public static float DotProduct(Vector3 vectorMultiplicand, Vector3 vectorMultiplier)
        {
            return (vectorMultiplicand.x * vectorMultiplier.x) + (vectorMultiplicand.y * vectorMultiplier.y) + (vectorMultiplicand.z * vectorMultiplier.z);
        }
        public float DotProduct(Vector3 vectorMultiplier)
        {
            return (x * vectorMultiplier.x) + (y * vectorMultiplier.y) + (z * vectorMultiplier.z);
        }
        #endregion

        #region CrossProduct
        public static Vector3 CrossProduct(Vector3 vectorMultiplicand, Vector3 vectorMultiplier)
        {
            return new Vector3
            ( 
                (vectorMultiplicand.y * vectorMultiplier.z) - (vectorMultiplicand.z * vectorMultiplier.y), 
                (vectorMultiplicand.z * vectorMultiplier.x) - (vectorMultiplicand.x * vectorMultiplier.z), 
                (vectorMultiplicand.x * vectorMultiplier.y) - (vectorMultiplicand.y * vectorMultiplier.x) 
            );
        }
        public Vector3 CrossProduct(Vector3 vectorMultiplier)
        {
            return new Vector3
            (
                (y * vectorMultiplier.z) - (z * vectorMultiplier.y),
                (z * vectorMultiplier.x) - (x * vectorMultiplier.z),
                (x * vectorMultiplier.y) - (y * vectorMultiplier.x)
            );
        }
        #endregion

        #region NearestVector
        public static Vector3 NearestVector(Vector3 vectorOrigin, IList<Vector3> vectorList)
        {
            if (vectorList == null || vectorList.Count == 0)
            {
                throw new ArgumentException("No Vector3s to check have been supplied!");
            }
            else if (vectorList.Count == 1)
            {
                return vectorList[0];
            }

            Vector3 nearestVector = vectorList[0];
            float nearestVectorDistance = Distance(vectorOrigin, nearestVector);
            foreach (Vector3 vector in vectorList)
            {
                float vectorDistance = Distance(vectorOrigin, vector);
                if (vectorDistance < nearestVectorDistance)
                {
                    nearestVectorDistance = vectorDistance;
                    nearestVector = vector;
                }
            }

            return nearestVector;
        }
        public Vector3 NearestVector(IList<Vector3> vectorList)
        {
            if (vectorList == null || vectorList.Count == 0)
            {
                throw new ArgumentException("No Vector3s to check have been supplied!");
            }
            else if (vectorList.Count == 1)
            {
                return vectorList[0];
            }

            Vector3 nearestVector = vectorList[0];
            float nearestVectorDistance = Distance(nearestVector);
            foreach (Vector3 vector in vectorList)
            {
                float vectorDistance = Distance(vector);
                if (vectorDistance < nearestVectorDistance)
                {
                    nearestVectorDistance = vectorDistance;
                    nearestVector = vector;
                }
            }

            return nearestVector;
        }
        #endregion

        #region FurthestVector
        public static Vector3 FurthestVector(Vector3 vectorOrigin, IList<Vector3> vectorList)
        {
            if (vectorList == null || vectorList.Count == 0)
            {
                throw new ArgumentException("No Vector3s to check have been supplied!");
            }
            else if (vectorList.Count == 1)
            {
                return vectorList[0];
            }

            Vector3 furthestVector = vectorList[0];
            float furthestVectorDistance = Distance(vectorOrigin, furthestVector);
            foreach (Vector3 vector in vectorList)
            {
                float vectorDistance = Distance(vectorOrigin, vector);
                if (vectorDistance > furthestVectorDistance)
                {
                    furthestVectorDistance = vectorDistance;
                    furthestVector = vector;
                }
            }

            return furthestVector;
        }
        public Vector3 FurthestVector(IList<Vector3> vectorList)
        {
            if (vectorList == null || vectorList.Count == 0)
            {
                throw new ArgumentException("No Vector3s to check have been supplied!");
            }
            else if (vectorList.Count == 1)
            {
                return vectorList[0];
            }

            Vector3 furthestVector = vectorList[0];
            float furthestVectorDistance = Distance(furthestVector);
            foreach (Vector3 vector in vectorList)
            {
                float vectorDistance = Distance(vector);
                if (vectorDistance > furthestVectorDistance)
                {
                    furthestVectorDistance = vectorDistance;
                    furthestVector = vector;
                }
            }

            return furthestVector;
        }
        #endregion

        #endregion

        #region Method Overloads
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
        #endregion
    }
}