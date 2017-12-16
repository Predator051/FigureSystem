using System;
using System.Collections.Generic;

namespace FigureSystem
{
	using UpdateParams = Tuple<ShapeType, EventType, Vector, double>;

	public class Circle: Shape
	{
		double mRadius;
		Vector mCenter;
		UInt32 mAccurancy;

		public Circle (double radius, Vector center, UInt32 accurancy = 20)
			:base()
		{
			mRadius = radius;
			mCenter = center;
			mAccurancy = accurancy;

			if (accurancy < 20)
				throw new ArgumentException ("Wrong value of accurancy! It must be 20 or more");
		}

		public override double Area ()
		{
			return Math.PI*mRadius*mRadius;
		}

		public override double Perimeter ()
		{
			return 2*Math.PI*mRadius;
		}

		public override void Move (Vector vec)
		{
			mCenter = new Vector (vec);
		}

		public override void Rotate (Vector vec, double angle)
		{
			mCenter.Rotate (vec, angle);
		}

		public override void Scale (Vector vec, double scaleFactor)
		{

			if (scaleFactor <= 0) {
				throw new ArgumentException ("Argument is less 0");

			}

			mCenter -= vec;
			mCenter *= scaleFactor;
			mCenter += vec;
			mRadius *= scaleFactor;
		}

		public override List<Vector> GetVertex ()
		{
			List<Vector> vertexs = new List<Vector>();

			for (int i = 0; i < mAccurancy; i++)
			{
				double angle = 2 * Math.PI * i / mAccurancy;
				double x = mCenter.X + mRadius * Math.Cos (angle);
				double y = mCenter.Y + mRadius * Math.Sin (angle);
				vertexs.Add (new Vector (x, y));
			}

			return vertexs;
		}

		public override void update (object o)
		{
			var param = (UpdateParams)(o);
			if (param.Item1 != ShapeType.Cicrle && param.Item1 != ShapeType.All)
				return;

			base.update (o);
		}
	}
}

