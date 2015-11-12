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
using IPIPIP_Tablette_tactile.Model;

namespace IPIPIP_Tablette_tactile.View
{
    /// <summary>
    /// Interaction logic for CellView.xaml
    /// </summary>
    public partial class CellView : UserControl
    {
        public CellModel cellModel { get; set; }
        public int thickness { 
            get { return DefaultDesignConstants.cellBorderThickness(); }
        }

        public CellView(CellModel cell)
        {
            InitializeComponent();
            this.Width = DefaultDesignConstants.cellWidth() + 2 * thickness;
            this.Height = DefaultDesignConstants.cellHeight() + 2 * thickness;
            this.cellModel = cell;
            this.paint();
        }

        public void paint()
        {
            //TopLine
            this.drawALine(0, (int)this.Width, 0, 0);
            //BottomLine
            this.drawALine(0, (int)this.Width, (int)this.Height - this.thickness, (int)this.Height - this.thickness);
            //LeftLine
            this.drawALine(0, 0, 0, (int)this.Height);
            //RightLine
            this.drawALine((int)this.Width - this.thickness, (int)this.Width - this.thickness, 0, (int)this.Height);
        }

        protected void drawALine(int x1, int x2, int y1, int y2)
        {
            var color = Brushes.White;
            Line line = new Line();
            line.Stroke = color;
            line.StrokeThickness = this.thickness;
            line.Y1 = y1;
            line.Y2 = y2;
            line.X1 = x1;
            line.X2 = x2;
            this.myCanvas.Children.Add(line);
        }

        public int getRow()
        {
            return this.cellModel.rowIndex;
        }

        public int getColumn()
        {
            return this.cellModel.columnIndex;
        }
    }
}
