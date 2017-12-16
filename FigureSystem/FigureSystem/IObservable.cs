using System;

namespace FigureSystem
{
	public interface IObservable
	{
		void AddObserver(IObserver o);
		void RemoveObserver(IObserver o);
		void NotifyObservers(object o);
	}
}

