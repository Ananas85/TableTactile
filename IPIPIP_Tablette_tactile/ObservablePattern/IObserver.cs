using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPIPIP_Tablette_tactile.ObservablePattern
{
    public interface IObserver
    {
        void update(IObservable observable);
    }
}
