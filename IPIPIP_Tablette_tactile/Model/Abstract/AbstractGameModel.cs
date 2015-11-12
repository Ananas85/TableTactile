using System.Collections.Generic;
using IPIPIP_Tablette_tactile.ObservablePattern;

namespace IPIPIP_Tablette_tactile.Model.Abstract
{
    /// <summary>
    /// The model of the Game we implement
    /// Its a grid and a list of token / piece
    /// </summary>
    public abstract class AbstractGameModel : IObservable
    {
        #region Class attributes
        public GridModel GridModel { get; set; }

        public List<TokenModel> TokenModels { get; set; }
	    #endregion
    }
}
