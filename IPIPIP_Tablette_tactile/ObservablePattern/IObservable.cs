using System.Collections.Generic;

namespace IPIPIP_Tablette_tactile.ObservablePattern
{
    /// <summary>
    /// Reimplementation of the observable
    /// </summary>
    public abstract class Observable
    {
        /// <summary>
        /// Our list of observers
        /// </summary>
        protected List<IObserver> Observers;

        /// <summary>
        /// Add an observer
        /// </summary>
        public void AddObserver(IObserver observer)
        {
            if (this.Observers == null)
            {
                this.Observers = new List<IObserver>();
            }
            this.Observers.Add(observer);
        }

        /// <summary>
        /// Remove an observer
        /// </summary>
        public void RemoveObserver(IObserver observer)
        {
            this.Observers.Remove(observer);
        }

        /// <summary>
        /// Notify all observers
        /// </summary>
        public void Notify()
        {
            foreach (IObserver observer in this.Observers)
            {
                observer.Update(this);
            }
        }
    }
}