using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using IPIPIP_Tablette_tactile.Adapters;
using IPIPIP_Tablette_tactile.Model;
using IPIPIP_Tablette_tactile.Utils;

namespace IPIPIP_Tablette_tactile.View
{
    /// <summary>
    /// Interaction logic for CGridView.xaml
    /// </summary>
    public partial class CGridView
    {
        #region Properties
        /// <summary>
        /// The thickeness of a cell
        /// </summary>
        public int CellBorderThickness { get; set; }

        /// <summary>
        /// Our list of cells
        /// </summary>
        protected List<CellView> CellViews;

        /// <summary>
        /// The model of the grid
        /// </summary>
        private GridModel _gridModel;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CGridView()
        {
            this.Init(
                DefaultConstants.CellBorderThickness()
            );
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CGridView(int cellBorderThickness)
        {
            this.Init(cellBorderThickness);
        }

        /// <summary>
        /// Our border thickness
        /// </summary>
        protected void Init(int cellBorderThickness)
        {
            InitializeComponent();
            this.CellViews = new List<CellView>();
            this.CellBorderThickness = cellBorderThickness;
        }

        /// <summary>
        /// Init all cells
        /// </summary>
        protected void InitCells()
        {
            foreach (var cellModel in this._gridModel.Cells)
            {
                CellView cell = new CellView(cellModel);
                this.CellViews.Add(cell);
                cellModel.AddObserver(cell);
                MyCanvas.Children.Add(cell);
                Canvas.SetLeft(
                    cell,
                    UnitsAdapter.Instance.ModelToView(
                        GridAdapter.Instance.ConvertIndexXtoPixel(this.GridModel.CellWidth, 0, cell.GetRow())
                    )
                );
                Canvas.SetTop(
                    cell,
                    UnitsAdapter.Instance.ModelToView(
                        GridAdapter.Instance.ConvertIndexYtoPixel(this.GridModel.CellHeight, 0, cell.GetColumn())
                    )
                );
            }
        }

        #region Getters and setters
        public GridModel GridModel
        {
            get
            {
                return _gridModel;
            }
            set
            {
                _gridModel = value;
                this.InitCells();
            }
        }

        public int Ordinate
        {
            get { return UnitsAdapter.Instance.ModelToView(this.GridModel.Ordinate); }
        }

        public int Axis
        {
            get { return UnitsAdapter.Instance.ModelToView(this.GridModel.Axis); }
        }
        #endregion

    }
}
