using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05_Weltall_2
{
    struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x = 0 , double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
        }

        public static Vector operator *(double a, Vector b)
        {
            return new Vector(a * b.X, a * b.Y, a * b.Z);
        }

        public static Vector operator *(Vector b, double a)
        {
            return a * b;
        }

        public static Vector operator /(Vector b, double a)
        {
            return 1/a * b;
        }

        public static implicit operator Vector (double x)
        {
            return new Vector(x: x);
        }

        public static explicit operator double (Vector v)
        {
            return v.Norm();
        }

        public double Norm()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static bool operator == (Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return ! (a == b);
        }

        public override bool Equals (Object o)
        {
            return (this == (Vector)o);
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        public double this [int index]
        {
            get {
                switch (index) {
                    case 0: 
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return String.Format("({0} {1} {2})", X, Y, Z);
        }
    }
}
