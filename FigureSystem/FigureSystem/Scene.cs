using System;
using System.Collections.Generic;

namespace FigureSystem
{
	public class Scene: IObservable
	{
		private static Scene mInstance;
		List<IObserver> mShapes;

		private Scene ()
		{
			mShapes = new List<IObserver> ();
		}

		public List<IObserver> GetShapes
		{
			get  { return mShapes; }

		}

		public static Scene getInstance()
		{
			if (mInstance == null)
				mInstance = new Scene();
			return mInstance;
		}

		public void AddObserver(IObserver o)
		{
			mShapes.Add (o);
		}

		public void RemoveObserver(IObserver o)
		{
			mShapes.Remove (o);
		}

		public void NotifyObservers(object o)
		{
			foreach (IObserver shape in mShapes) {
				shape.update (o);
			}
		}

		public void rotate(Vector point, double factor, ShapeType sType = ShapeType.All)
		{
			NotifyObservers (Tuple.Create<ShapeType, EventType, Vector, double> (sType, EventType.Rotate, point, factor));
		}

		public void scale(Vector point, double factor, ShapeType sType = ShapeType.All)
		{
			if (factor <= 0)
				throw new ArgumentException ("Scale value is <= 0: {0}");

			NotifyObservers (Tuple.Create<ShapeType, EventType, Vector, double> (sType, EventType.Scale, point, factor));
		}
			
		public void move(Vector point, ShapeType sType = ShapeType.All)
		{
			NotifyObservers (Tuple.Create<ShapeType, EventType, Vector, double> (sType, EventType.Move, point, 0));
		}
	}
}

