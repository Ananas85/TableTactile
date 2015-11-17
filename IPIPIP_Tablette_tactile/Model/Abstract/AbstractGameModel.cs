using System.Collections.Generic;
using System.Linq;
using IPIPIP_Tablette_tactile.Adapters;
using IPIPIP_Tablette_tactile.ObservablePattern;

namespace IPIPIP_Tablette_tactile.Model.Abstract
{
    /// <summary>
    /// The model of the Game we implement
    /// Its a grid and a list of token / piece
    /// </summary>
    public abstract class AbstractGameModel : Observable
    {
        #region Class attributes
        /// <summary>
        /// The GridModel, use the special getter provided by c#
        /// </summary>
        public GridModel GridModel { get; set; }

        /// <summary>
        /// The tokenModels, use the special getter provided by C#
        /// </summary>
        public HashSet<TokenModel> TokenModels { get; set; }
	    #endregion

        /// <summary>
        /// To know if a token is already on our game
        /// </summary>
        public bool ContainsTokenByIdentifier(string id)
        {
            return TokenModels.Any(token => token.Id == id);
        }

        /// <summary>
        /// To remove a token id from our game
        /// </summary>
        public void RemoveTokenByIdentifier(string id)
        {
            this.TokenModels.RemoveWhere(token => token.Id == id);
        }

        /// <summary>
        /// To add a token in our game
        /// </summary>
        public void AddToken(TokenModel token)
        {
            if (!this.ContainsTokenByIdentifier(token.Id))
            {
                this.TokenModels.Add(token);
                if (this.GridModel.pointIsInGrid(token.X, token.Y))
                {
                    int row = GridAdapter.Instance.ConvertXPixel(this.GridModel.Axis, this.GridModel.CellWidth, this.GridModel.Columns, token.X);
                    int column = GridAdapter.Instance.ConvertYPixel(this.GridModel.Ordinate, this.GridModel.CellHeight,
                        this.GridModel.Rows, token.Y);
                    this.GridModel.Cells[row, column].Token = token;
                }
            }
        }
    }
}
