namespace IPIPIP_Tablette_tactile.Model
{
    /// <summary>
    /// Class which represent a token / piece everywhere in the table
    /// Construct by the TokenFactory
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// The axis
        /// </summary>
	    private int _x;

        /// <summary>
        /// The ordinate
        /// </summary>
	    private int _y;

        /// <summary>
        /// The unique id
        /// </summary>
        private string _id;

        /// <summary>
        /// The constructor
        /// Don't use it, you should use the Factory instead
        /// </summary>
        /// <param name="x">The axis of the token</param>
        /// <param name="y">The ordinate of the token</param>
        /// <param name="id">The unique Id of the token</param>
        public TokenModel(int x, int y, string id)
        {
            this._x = x;
            this._y = y;
            this._id = id;
        }

        /// <summary>
        /// Return the axis of the token
        /// </summary>
        public int X
        {
            get { return this._x; }
        }

        /// <summary>
        /// Return the ordinate of the token
        /// </summary>
        public int Y
        {
            get { return this._y; }
        }

        /// <summary>
        /// Return the Unique ID of the token
        /// </summary>
        public string Id
        {
            get { return this._id; }
        }
    }
}
