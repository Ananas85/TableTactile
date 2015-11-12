using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using IPIPIP_Tablette_tactile.Model;

namespace IPIPIP_Tablette_tactile.View
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class CGridView
    {
        #region Properties
        /// <summary>
        /// We put here the cell witdh to have only same size for each cell
        /// </summary>
        public int cellWidth { get; set; }

        /// <summary>
        /// We put here the cell height to have only same size for each cell
        /// </summary>
        public int cellHeight { get; set; }

        /// <summary>
        /// Where the grid is beginning on the axis
        /// </summary>
        public int axis { get; set; }

        /// <summary>
        /// Where the grid is beginning on the ordinate
        /// </summary>
        public int ordinate { get; set; }

        /// <summary>
        /// The thickeness of a cell
        /// </summary>
        public int cellBorderThickness { get; set; }

        /// <summary>
        /// Our list of cells
        /// </summary>
        protected List<CellView> cellViews;

        /// <summary>
        /// The model of the grid
        /// </summary>
        private GridModel gridModel;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CGridView()
        {
            this.init(
                DefaultDesignConstants.gridAxis(),
                DefaultDesignConstants.gridOrdinate(),
                DefaultDesignConstants.cellWidth(),
                DefaultDesignConstants.cellHeight(),
                DefaultDesignConstants.cellBorderThickness()
            );
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CGridView(int axis, int ordinate, int cellWidth, int cellHeight, int cellBorderThickness)
        {
            this.init(axis, ordinate, cellWidth, cellHeight, cellBorderThickness);
        }

        protected void init(int axis, int ordinate, int cellWidth, int cellHeight, int cellBorderThickness)
        {
            InitializeComponent();
            this.cellViews = new List<CellView>();
            this.axis = axis;
            this.ordinate = ordinate;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            this.cellBorderThickness = cellBorderThickness;
        }

        public void initCells()
        {
            foreach (var cellModel in this.gridModel.cells)
            {
                CellView cell = new CellView(cellModel);
                this.cellViews.Add(cell);
                myCanvas.Children.Add(cell);
                Canvas.SetLeft(cell, GridFacade.Instance.convertIndexXtoPixel(this.cellWidth, 0, cell.getRow()));
                Canvas.SetTop(cell, GridFacade.Instance.convertIndexYtoPixel(this.cellHeight, 0, cell.getColumn()));
            }
        }

        #region Getters and setters
        public GridModel GridModel
        {
            get
            {
                return gridModel;
            }
            set
            {
                gridModel = value;
            }
        }
        #endregion

    }
}
