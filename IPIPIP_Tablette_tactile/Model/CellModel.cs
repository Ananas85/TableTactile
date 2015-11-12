using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPIPIP_Tablette_tactile.Model
{
    public class CellModel
    {
        public int rowIndex {get; set;}
        public int columnIndex {get; set;}

	    public CellModel(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }
    }
}
