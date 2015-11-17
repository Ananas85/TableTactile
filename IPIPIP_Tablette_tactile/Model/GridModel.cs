using IPIPIP_Tablette_tactile.Utils;

namespace IPIPIP_Tablette_tactile.Model
{
    public class GridModel
    {
        #region Class attributes
        /// <summary>
        /// BackingStore of number of columns
        /// </summary>
        private int _columns; 

        /// <summary>
        /// BackingStore number of rows
        /// </summary>
        private int _rows;

        private int _cellWidth;

        private int _cellHeight;

        private int _axis;

        private int _ordinate;

        public CellModel[,] Cells { get; private set; }
	    #endregion

        #region Constructors
        public GridModel()
        {
            this.Initialize(
                DefaultConstants.NumberOfRows(),
                DefaultConstants.NumberOfColumns(),
                DefaultConstants.CellWidth(),
                DefaultConstants.CellHeight(),
                DefaultConstants.GridAxis(),
                DefaultConstants.GridOrdinate()
            );
        }

        public GridModel(int rows, int columns, int cellWidth, int cellHeight, int gridAxis, int gridOrdinate)
        {
            this.Initialize(rows, columns, cellWidth, cellHeight, gridAxis, gridOrdinate);
        }
        #endregion

        /// <summary>
        /// Useful for constructor
        /// </summary>
        protected void Initialize(int rows, int columns, int cellWidth, int cellHeight, int gridAxis, int gridOrdinate)
        {
            this._columns = columns;
            this._rows = rows;
            this._cellWidth = cellWidth;
            this._cellHeight = cellHeight;
            this._axis = gridAxis;
            this._ordinate = gridOrdinate;
            this.Cells = new CellModel[this._rows, this._columns];
            this.ResetGrid();
        }

        /// <summary>
        /// Set all cells
        /// </summary>
        protected void ResetGrid()
        {
            for (var i = 0; i < this._rows; i++)
            {
                for (var j = 0; j < this._columns; j++)
                {
                    this.Cells[i,j] = new CellModel(i,j, this._cellWidth, this._cellHeight);
                }
            }
        }

        /// <summary>
        /// Know if a point is in the grid
        /// </summary>
        public bool pointIsInGrid(int x, int y)
        {
            return (x > _axis && x <= (_axis + (this._columns*this._cellWidth)) && y > _ordinate &&
                    y <= (_ordinate + (this._rows*this._cellHeight)));
        }

        #region Getters and setters
        public int Rows
        {
            get
            {
                return this._rows;
            }
        }

        public int Columns
        {
            get
            {
                return this._columns;
            }
        }

        public int CellWidth
        {
            get
            {
                return this._cellWidth;
            }
        }


        public int CellHeight
        {
            get
            {
                return this._cellHeight;
            }
        }


        public int Axis
        {
            get
            {
                return this._axis;
            }
        }


        public int Ordinate
        {
            get
            {
                return this._ordinate;
            }
        }
	    #endregion

    }
}
