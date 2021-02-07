using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS
{

    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D() : this(0, 0)
        {
            X = 0;
            Y = 0;
        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            /* Is also called "the magnitude of a vector".
               To calculate the length, we use the Pythagoreon theorem.
               First we add up x² and Y² through the LengthSquared() function.
               Secondly we get the square root from it.
               And we have the length/magnitude!
               Often shown as |v|.
            */
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return X * X + Y * Y;
        }

        public Vector2D Add(Vector2D v)
        {
            this.X += v.X;
            this.Y += v.Y;
            return this;
        }

        public Vector2D Sub(Vector2D v)
        {
            this.X -= v.X;
            this.Y -= v.Y;
            return this;
        }

        public Vector2D Multiply(double value)
        {
            this.X *= value;
            this.Y *= value;
            return this;
        }

        public Vector2D divide(double value)
        {
            this.X /= value;
            this.Y /= value;
            return this;
        }

        public Vector2D Normalize()
        {
            /* The formula is N = v : |v|.
             Basically you want to recalculate the magnitude, so that the it is of a unit length (a length of 1).*/
            double length = Length();
            this.X = this.X / length;
            this.Y = this.Y / length;
            return this;
        }

        public Vector2D truncate(double maX)
        {
            if (Length() > maX)
            {
                Normalize();
                Multiply(maX);
            }
            return this;
        }

        public Vector2D Clone()
        {
            return new Vector2D(this.X, this.Y);
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }
    }
}
