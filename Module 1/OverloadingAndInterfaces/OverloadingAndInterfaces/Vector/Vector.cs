using System; 
using System.Collections;

namespace OverloadingAndInterfaces.Vector
{
    public class Vector : ICloneable
    {
        public double x, y, z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector(Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }
        public override string ToString()
        {
            return "( " + x + " , " + y + " , " + z + " )";
        }

        public object Clone()
        {
            var a = this.MemberwiseClone(); //берет все значения наших свойств и вставляет их в новый объект 
            //для reference types скопирует только ссылку (опасно!)
            //в этом случае нужна дополнительная логика
            //a.Point = new Point(10, 1);
            return a;
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            Vector result = new Vector(lhs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }
        public static Vector operator *(double lhs, Vector rhs)
        {
            return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector operator *(Vector lhs, double rhs)
        {
            return rhs * lhs;
        }
        public static double operator *(Vector lhs, Vector rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        //public static bool operator ==(Vector lhs, Vector rhs)
        //{
        //    if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
        //        return true;
        //    else
        //        return false;
        //}
        private const double Epsilon = 0.0000001;
        public static bool operator ==(Vector lhs, Vector rhs)
        {
            if (Math.Abs(lhs.x - rhs.x) < Epsilon &&
                Math.Abs(lhs.y - rhs.y) < Epsilon &&
                Math.Abs(lhs.z - rhs.z) < Epsilon)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        throw new IndexOutOfRangeException(
                            "Attempt to retrieve Vector element " + i);
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException(
                            "Attempt to set Vector element " + i);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {

            // return new VectorEnumerator(this);
            #region magic yield return
            //The yield keyword is used to specify the value(or values)
            //to be returned to the caller’s foreach construct.
            //When the yield return statement is reached, the current location in the container is stored, 
            //and execution is restarted from this location the next time the iterator is called.
            yield return this[0];
            yield return this[1];
            yield return this[2];
            #endregion
        }

        private class VectorEnumerator : IEnumerator
        {
            Vector theVector;      // Vector object that this enumerator refers to 
            int location;   // which element of theVector the enumerator is currently referring to 
            public VectorEnumerator(Vector theVector)
            {
                this.theVector = theVector;
                location = -1;
            }
            public bool MoveNext()
            {
                ++location;
                return (location > 2) ? false : true;
            }
            public object Current
            {
                get
                {
                    if (location < 0 || location > 2)
                        throw new InvalidOperationException(
                        "The enumerator is either before the first element or " +
                            "after the last element of the Vector");
                    return theVector[(int)location];
                }
            }
            public void Reset()
            {
                location = -1;
            }
        }
    }
}
