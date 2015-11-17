namespace IPIPIP_Tablette_tactile.Adapters
{
    /// <summary>
    /// Singleton class to convert model units to view units
    /// </summary>
    public class UnitsAdapter
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static UnitsAdapter _instance = null;

        /// <summary>
        /// Used for singleton pattern
        /// </summary>
        public static UnitsAdapter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnitsAdapter();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        private UnitsAdapter() {}

        /// <summary>
        /// Coefficient to passe to view units
        /// </summary>
        private const int CoefModelUnitsToPixel = 1;

        /// <summary>
        /// Get View dimension from model dimension
        /// </summary>
        public int ModelToView(int size)
        {
            return size*CoefModelUnitsToPixel;
        }

        /// <summary>
        /// Get model dimension from view dimension
        /// </summary>
        public int ViewToModel(int size)
        {
            return size/CoefModelUnitsToPixel;
        }
    }
}