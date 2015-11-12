using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPIPIP_Tablette_tactile.View;

namespace IPIPIP_Tablette_tactile
{
    class GridFacade
    {
        private static GridFacade _instance = null;

        public static GridFacade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GridFacade();
                }
                return _instance;
            }
        }

        private GridFacade()
        { }

        /// <summary>
        /// Convert a cell axis to a pixel axis
        /// </summary>
        /// <param name="view"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int convertIndexXtoPixel(CGridView view, int x)
        {
            return view.cellWidth * x + view.axis;
        }

        /// <summary>
        /// Convert a cell ordinate to a pixel ordinate
        /// </summary>
        /// <param name="view"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int convertIndexYtoPixel(CGridView view, int y)
        {
            return view.cellHeight * y + view.ordinate;
        }

        /// <summary>
        /// Convert a pixel axis to a cell axis
        /// </summary>
        /// <param name="view"></param>
        /// <param name="xpixel"></param>
        /// <returns></returns>
        public int convertXPixel(CGridView view, int xpixel)
        {
            if (xpixel >= view.axis && xpixel <= (view.axis + (view.GridModel.Columns * view.cellWidth)))
            {
                return (int)Math.Ceiling((double)((xpixel - view.axis) / view.cellWidth));
            }
            return -1;
        }

        /// <summary>
        /// Convert a pixel ordinate to a cell ordinate
        /// </summary>
        /// <param name="view"></param>
        /// <param name="ypixel"></param>
        /// <returns></returns>
        public int convertYPixel(CGridView view, int ypixel)
        {
            if (ypixel >= view.ordinate && ypixel <= (view.ordinate + (view.GridModel.Rows * view.cellHeight)))
            {
                return (int)Math.Ceiling((double)(ypixel - view.ordinate) / (view.cellHeight));
            }
            return -1;
        }
    }
}
