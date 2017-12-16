using System;
using System.Collections.Generic;

namespace FigureSystem
{
	using UpdateParams = Tuple<ShapeType, EventType, Vector, double>;

	public class Square: Shape
	{
		double mEdge;
		double mAngleAboutAbscissa;
		Vector mDownLeftVertex;

		public Square (double edge, Vector downLeftVertex, double angleAboutAbscissa)
			:base()
		{
			mEdge = edge;
			mAngleAboutAbscissa = angleAboutAbscissa;
			mDownLeftVertex = downLeftVertex;
		}

		public override double Area ()
		{
			return mEdge * mEdge;
		}

		public override double Perimeter ()
		{
			return mEdge * 4;;
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
			mEdge *= scaleFactor;
		}

		public override List<Vector> GetVertex ()
		{
			List<Vector> result = new List<Vector> ();

			Vector leftTop = new Vector (mDownLeftVertex.X, mDownLeftVertex.Y + mEdge);
			leftTop.Rotate (mDownLeftVertex, mAngleAboutAbscissa);
			Vector rightTop = new Vector (mDownLeftVertex.X+mEdge, mDownLeftVertex.Y+mEdge);
			rightTop.Rotate (mDownLeftVertex, mAngleAboutAbscissa);
			Vector rightDown = new Vector (mDownLeftVertex.X + mEdge, mDownLeftVertex.Y);
			rightDown.Rotate (mDownLeftVertex, mAngleAboutAbscissa);

			result.Add (new Vector (mDownLeftVertex));
			result.Add (leftTop);
			result.Add (rightTop);
			result.Add (rightDown);

			return result;
		}

		public override void update (object o)
		{
			var param = (UpdateParams)(o);
			if (param.Item1 != ShapeType.Square && param.Item1 != ShapeType.All)
				return;

			base.update (o);
		}
	}
}

