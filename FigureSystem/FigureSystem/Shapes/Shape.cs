using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FigureSystem
{

	using UpdateParams = Tuple<ShapeType, EventType, Vector, double>;

	public class Shape: IObserver
    {
        public Shape()
        {
        }
        
        virtual public List<Vector> GetVertex()
        {
            return null;
        }

        virtual public double Area()
        {
            return 0.0;
        }
        virtual public double Perimeter()
        {
            return 0.0;
        }
        public void PrintInfo()
        {
            Console.WriteLine("I am {0}", GetType());
            Console.WriteLine("My perimeter is {0}", Perimeter());
            Console.WriteLine("My area is {0}", Area());

            List<Vector> dots = GetVertex();

            if (dots != null)
            {
                Console.WriteLine("My vertex are: ");
                foreach (Vector dot in GetVertex())
                {
                    Console.WriteLine("{0} ", dot);
                }

                Console.WriteLine();
            }
        }

        public virtual void Rotate(Vector vec, double angle)
        {

        }

		public virtual void Move(Vector vec)
        {

        }

		public virtual void Scale(Vector vec, double scaleFactor)
        {

        }

		public virtual void update(object o)
		{
			var param = (UpdateParams)o;
			switch (param.Item2) {
			case EventType.Move:
				{
					Move (param.Item3);
					Console.WriteLine ("I'm {0} moving on {1}", GetType (), param.Item3);
					break;
				}
			case EventType.Rotate:
				{
					Rotate (param.Item3, param.Item4);
					Console.WriteLine ("I'm {0} rotating on {1} about {2}", GetType (), param.Item4, param.Item3);
					break;
				}
			case EventType.Scale:
				{
					Scale (param.Item3, param.Item4);
					Console.WriteLine ("I'm {0} scaling on {1} about", GetType (), param.Item4, param.Item3);
					break;
				}
			}

		}
    }
}
