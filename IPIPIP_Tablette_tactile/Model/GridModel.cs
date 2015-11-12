using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public CellModel[,] Tokens { get; private set; }
	    #endregion

        #region Constructors
        public GridModel()
        {
            this._columns = 10;
            this._rows = 10;
            this.initialize(_rows, _columns);
        }

        public GridModel(int numberOfRows, int numberOfColumns)
        {
            this._rows = numberOfRows;
            this._columns = numberOfColumns;
            this.initialize(numberOfRows, numberOfColumns);
        }
        #endregion

        protected void initialize(int numberOfRows, int numberOfColumns)
        {
            this._columns = numberOfColumns;
            this._rows = numberOfRows;
            this.Tokens = new CellModel[this._rows, this._columns];
            this.resetGrid();
        }

        protected void resetGrid()
        {
            for (var i = 0; i < this._rows; i++)
            {
                for (var j = 0; j < this._columns; j++)
                {
                    this.Tokens[i,j] = new CellModel(i,j);
                }
            }
        }

        #region Getters and setters
        public int Rows
        {
            get
            {
                return this._rows;
            }
            set
            {
                this._rows = value;
                this.resetGrid();
            }
        }

        public int Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                this._columns = value;
                this.resetGrid();
            }
        }
	    #endregion

    }
}
