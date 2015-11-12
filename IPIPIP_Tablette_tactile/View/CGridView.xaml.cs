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
        /// The model of the grid
        /// </summary>
        private GridModel gridModel;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CGridView()
        {
            InitializeComponent();
            cellWidth = 30;
            cellHeight = 30;
            ordinate = 50;
            axis = 50;
        }

        public CGridView(int cellWidth, int cellHeight, int ordinate, int axis)
        {
            InitializeComponent();
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            this.ordinate = ordinate;
            this.axis = axis;
        }

        public void paint()
        {
            Width = gridModel.Columns * cellWidth;
            for (int i = 0; i <= gridModel.Rows; i++)
            {
                Line line = new Line();
                line.StrokeThickness = 4;
                line.Stroke = Brushes.White;
                line.X1 = 0;
                line.X2 = gridModel.Columns * cellWidth;
                int ordinateLine = GridFacade.Instance.convertIndexYtoPixel(this, i) - ordinate;
                line.Y1 = ordinateLine;
                line.Y2 = ordinateLine;
                myCanvas.Children.Add(line);
            }

            Height = gridModel.Rows * cellHeight;
            for (int i = 0; i <= gridModel.Columns; i++)
            {
                Line line = new Line();
                line.StrokeThickness = 4;
                line.Stroke = Brushes.White;
                int axisLine = GridFacade.Instance.convertIndexXtoPixel(this, i) - axis;
                line.X1 = axisLine;
                line.X2 = axisLine;
                line.Y1 = 0;
                line.Y2 = gridModel.Rows * cellHeight;
                myCanvas.Children.Add(line);
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
