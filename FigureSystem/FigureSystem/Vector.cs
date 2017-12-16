using System;

namespace FigureSystem
{
	public class Vector
	{
		double mX;
		double mY;

		public Vector(double x, double y)
		{
			mX = x;
			mY = y;
		}
		public Vector(Vector other)
		{
			X = other.X;
			Y = other.Y;
		}

		public double Y { get{ return mY;} set{ mY = value;} }
		public double X { get{ return mX; } set{ mX = value; } }

		public static Vector operator + (Vector left, Vector right)
		{
			return new Vector(left.X + right.X, left.Y + right.Y);
		}
		public static Vector operator - (Vector left, Vector right)
		{
			return new Vector(left.X - right.X, left.Y - right.Y);
		}
		public static Vector operator *(Vector left, double right)
		{
			left.X *= right;
			left.Y *= right;
			return left;
		}
		public static double operator *(Vector left, Vector right)
		{
			return left.X * right.X + left.Y * right.Y;
		}

		public static double Angle(Vector left, Vector right)
		{
			return (left * right) / (left.Abs() + right.Abs());
		}

		public double Abs()
		{
			return Math.Sqrt(X*X + Y*Y);
		}

		public void Rotate(Vector vec, double angle)
		{
			angle = (Math.PI*angle)/180.0;
			double newX = vec.X + (X - vec.X) * Math.Cos (angle)
				- (Y - vec.Y) * Math.Sin (angle);
			double newY = vec.Y + (Y - vec.Y) * Math.Cos (angle)
				+ (X - vec.X) * Math.Sin (angle);

			X = newX;
			Y = newY;
		}

		public override string ToString()
		{
			return "Y: " + (Y > 0.0000000000001? Y : 0) + " X: " + (X > 0.0000000000001? X : 0);
		}
	}
}

