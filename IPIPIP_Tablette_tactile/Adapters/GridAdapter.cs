using System;

namespace IPIPIP_Tablette_tactile.Adapters
{
    /// <summary>
    /// The singleton utils class to convert cell and pixels
    /// </summary>
    class GridAdapter
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static GridAdapter _instance = null;

        /// <summary>
        /// Used for SingletonPattern
        /// </summary>
        public static GridAdapter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GridAdapter();
                }
                return _instance;
            }
        }

        private GridAdapter()
        { }

        /// <summary>
        /// Convert a cell axis to a pixel axis
        /// </summary>
        public int ConvertIndexXtoPixel(int cellWidth, int axis, int x)
        {
            return cellWidth * x + axis;
        }

        /// <summary>
        /// Convert a cell ordinate to a pixel ordinate
        /// </summary>
        public int ConvertIndexYtoPixel(int cellHeight, int ordinate, int y)
        {
            return cellHeight * y + ordinate;
        }

        /// <summary>
        /// Convert a pixel axis to a cell row
        /// </summary>
        public int ConvertXPixel(int axis, int cellWidth, int columns, int xpixel)
        {
            if (xpixel >= axis && xpixel <= (axis + (columns * cellWidth)))
            {
                return (int)Math.Ceiling((double)(xpixel - axis) / (cellWidth));
            }
            return -1;
        }

        /// <summary>
        /// Convert a pixel ordinate to a cell column
        /// </summary>
        public int ConvertYPixel(int ordinate, int cellHeight, int rows, int ypixel)
        {
            if (ypixel >= ordinate && ypixel <= (ordinate + (rows * cellHeight)))
            {
                return (int)Math.Ceiling((double)(ypixel - ordinate) / (cellHeight));
            }
            return -1;
        }
    }
}
