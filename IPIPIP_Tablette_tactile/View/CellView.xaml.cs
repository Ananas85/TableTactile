using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IPIPIP_Tablette_tactile.Adapters;
using IPIPIP_Tablette_tactile.Model;
using IPIPIP_Tablette_tactile.ObservablePattern;
using IPIPIP_Tablette_tactile.Utils;

namespace IPIPIP_Tablette_tactile.View
{
    /// <summary>
    /// Interaction logic for CellView.xaml
    /// </summary>
    public partial class CellView : IObserver
    {
        /// <summary>
        /// The linked cellModel
        /// </summary>
        protected CellModel CellModel;

        /// <summary>
        /// The thickness
        /// </summary>
        public int Thickness { 
            get { return DefaultConstants.CellBorderThickness(); }
        }

        public CellView(CellModel cell)
        {
            InitializeComponent();
            this.Width = UnitsAdapter.Instance.ModelToView(cell.Width) + 2 * Thickness;
            this.Height = UnitsAdapter.Instance.ModelToView(cell.Height) + 2 * Thickness;
            this.CellModel = cell;
            this.Paint();
        }

        /// <summary>
        /// Paint the cell
        /// </summary>
        protected void Paint()
        {
            //TopLine
            this.DrawALine(0, (int)this.Width, 0, 0);
            //BottomLine
            this.DrawALine(0, (int)this.Width, (int)this.Height - this.Thickness, (int)this.Height - this.Thickness);
            //LeftLine
            this.DrawALine(0, 0, 0, (int)this.Height);
            //RightLine
            this.DrawALine((int)this.Width - this.Thickness, (int)this.Width - this.Thickness, 0, (int)this.Height);
        }

        /// <summary>
        /// Paint a line
        /// </summary>
        /// <param name="x1">Begin X</param>
        /// <param name="x2">End X</param>
        /// <param name="y1">Begin Y</param>
        /// <param name="y2">End Y</param>
        protected void DrawALine(int x1, int x2, int y1, int y2)
        {
            var color = Brushes.White;
            Line line = new Line();
            line.Stroke = color;
            line.StrokeThickness = this.Thickness;
            line.Y1 = y1;
            line.Y2 = y2;
            line.X1 = x1;
            line.X2 = x2;
            this.MyCanvas.Children.Add(line);
        }

        #region Getters
        public int GetRow()
        {
            return this.CellModel.RowIndex;
        }

        public int GetColumn()
        {
            return this.CellModel.ColumnIndex;
        }
        #endregion

        /// <summary>
        /// TODO implement reaction
        /// </summary>
        /// <param name="observable">The observable</param>
        public void Update(Observable observable)
        {
            if (observable is CellModel)
            {
                //TODO
            }
        }
    }
}
