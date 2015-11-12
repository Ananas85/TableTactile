using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPIPIP_Tablette_tactile.Model.Abstract;

namespace IPIPIP_Tablette_tactile.Model
{
    /// <summary>
    /// The concrete game we implement (e.g Morpion)
    /// </summary>
    public class GameModel : AbstractGameModel
    {
        public GameModel()
        {
            this.initialize(3, 3);
        }

        public GameModel(int rows, int columns)
        {
            this.initialize(rows,columns);
        }

        protected void initialize(int rows, int columns)
        {
            this.observers = new List<ObservablePattern.IObserver>();
            this.TokenModels = new List<TokenModel>();
            this.GridModel = new GridModel(rows, columns);
        }
    }
}