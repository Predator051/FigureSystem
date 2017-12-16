using System;
using System.Collections.Generic;

namespace FigureSystem
{

	using UpdateParams = Tuple<ShapeType, EventType, Vector, double>;

	public class Rectangle: Shape
	{
		double mWidht;
		double mHeight;
		double mAngleAboutAbscissa;
		Vector mDownLeftVertex;

		public Rectangle (double width, double heigth, Vector downLeftVertex, double angleAboutAbscissa)
			:base()
		{
			if (width < 0 || heigth < 0 || angleAboutAbscissa < 0) {
				throw new ArgumentException ("Argument is less 0");
			
			}

			mWidht = width;
			mHeight = heigth;
			mDownLeftVertex = downLeftVertex;
			mAngleAboutAbscissa = angleAboutAbscissa;
		}

		public override double Area ()
		{
			return mWidht * mHeight;
		}

		public override double Perimeter ()
		{
			return mWidht*2 + mHeight*2;
		}

		public override List<Vector> GetVertex ()
		{
			List<Vector> result = new List<Vector> ();

			Vector leftTop = new Vector (mDownLeftVertex.X, mDownLeftVertex.Y + mHeight);
			leftTop.Rotate (mDownLeftVertex, mAngleAboutAbscissa);
			Vector rightTop = new Vector (mDownLeftVertex.X+mWidht, mDownLeftVertex.Y+mHeight);
			rightTop.Rotate (mDownLeftVertex, mAngleAboutAbscissa);
			Vector rightDown = new Vector (mDownLeftVertex.X + mWidht, mDownLeftVertex.Y);
			rightDown.Rotate (mDownLeftVertex, mAngleAboutAbscissa);

			result.Add (new Vector (mDownLeftVertex));
			result.Add (leftTop);
			result.Add (rightTop);
			result.Add (rightDown);

			return result;
		}

		public override void Move (Vector vec)
		{
			mDownLeftVertex = new Vector (vec);
		}

		public override void Rotate (Vector vec, double angle)
		{
			mDownLeftVertex.Rotate (vec, angle);
			mAngleAboutAbscissa += angle;
		}

		public override void Scale (Vector vec, double scaleFactor)
		{
			
			mDownLeftVertex -= vec;
			mDownLeftVertex *= scaleFactor;
			mDownLeftVertex += vec;
			mWidht *= scaleFactor;
			mHeight *= scaleFactor;
		}

		public override void update (object o)
		{
			var param = (UpdateParams)(o);
			if (param.Item1 != ShapeType.Rectangle && param.Item1 != ShapeType.All)
				return;
			
			base.update (o);
		}
	}
}

