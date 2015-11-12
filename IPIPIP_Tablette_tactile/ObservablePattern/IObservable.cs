using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPIPIP_Tablette_tactile.ObservablePattern
{
    public abstract class IObservable
    {
        protected List<IObserver> observers;

        public void addObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.update(this);
            }
        }
    }
}