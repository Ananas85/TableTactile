using IPIPIP_Tablette_tactile.ObservablePattern;

namespace IPIPIP_Tablette_tactile.Model
{
    /// <summary>
    /// Representation of a cell
    /// </summary>
    public class CellModel : Observable
    {
        private int _rowIndex;
        private int _columnIndex;
        private int _width;
        private int _height;

        private TokenModel _tokenModel;

        public CellModel(int rowIndex, int columnIndex, int width, int height)
        {
            this._rowIndex = rowIndex;
            this._columnIndex = columnIndex;
            this._width = width;
            this._height = height;
            this._tokenModel = null;
        }

        #region Simple getters
        public int RowIndex
        {
            get { return _rowIndex; }
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public TokenModel Token
        {
            get { return _tokenModel;}
            set { this._tokenModel = value; this.Notify(); }
        }
        #endregion
    }
}
