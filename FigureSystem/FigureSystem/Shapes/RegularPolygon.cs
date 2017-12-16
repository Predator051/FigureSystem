using System;
using System.Collections.Generic;

namespace FigureSystem
{
	using UpdateParams = Tuple<ShapeType, EventType, Vector, double>;

	public class RegularPolygon: Shape
	{
		double mAngleAboutAbscissa;
		double mRadiusOut;
		UInt32 mCVertex;
		Vector mCenter;
		double mRadiusIn;

		public RegularPolygon (double angleAboutAbscissa, UInt32 countVertex, Vector center, double radiusIn)
			:base()
		{
			mAngleAboutAbscissa = angleAboutAbscissa;
			mCenter = center;
			mCVertex = countVertex;
			mRadiusIn = radiusIn;
			mRadiusOut = mRadiusIn / Math.Cos (Math.PI/countVertex);

			if (countVertex < 3)
				throw new ArgumentException ("Wrong value of accurancy! It must be 20 or more");
		}

		public override double Area ()
		{
			double edge = 2 * mRadiusOut * Math.Sin (Math.PI / mCVertex); 
			double area = (mCVertex / 4.0) * edge * edge * (1.0 / Math.Tan (Math.PI / mCVertex));
			return area;
		}

		public override double Perimeter ()
		{
			return Area()*2/mRadiusIn; 
		}

		public override void Move (Vector vec)
		{
			mCenter = new Vector (vec);
		}

		public override void Rotate (Vector vec, double angle)
		{
			mCenter.Rotate (vec, angle);
			mAngleAboutAbscissa += angle;
		}

		public override List<Vector> GetVertex ()
		{
			List<Vector> vertexs = new List<Vector>();

			for (int i = 0; i < mCVertex; i++)
			{
				double angle = 2 * Math.PI * i / mCVertex;
				double x = mCenter.X + mRadiusOut * Math.Cos (angle);
				double y = mCenter.Y + mRadiusOut * Math.Sin (angle);
				vertexs.Add (new Vector (x, y));
			}

			return vertexs;
		}

		public override void Scale (Vector vec, double scaleFactor)
		{
			mRadiusIn *= scaleFactor;
			mRadiusOut *= scaleFactor;

			mCenter -= vec;
			mCenter *= scaleFactor;
			mCenter += vec;
		}

		public override void update (object o)
		{
			var param = (UpdateParams)(o);
			if (param.Item1 != ShapeType.RegularPolygon && param.Item1 != ShapeType.All)
				return;

			base.update (o);
		}
	}
}

