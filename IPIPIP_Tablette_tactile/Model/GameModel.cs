using System.Collections.Generic;
using System.Linq;
using IPIPIP_Tablette_tactile.Adapters;
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
            this.TokenModels = new HashSet<TokenModel>();
            this.GridModel = new GridModel();
        }

        public GameModel(int rows, int columns, int cellWidth, int cellHeight, int gridAxis, int gridOrdinate)
        {
            this.TokenModels = new HashSet<TokenModel>();
            this.GridModel = new GridModel(rows, columns, cellWidth, cellHeight, gridAxis, gridOrdinate);
        }
    }
}