using System;
using System.Collections.Generic;

using IPIPIP_Tablette_tactile.Model;

namespace IPIPIP_Tablette_tactile.Factory
{
    /// <summary>
    /// Singleton class to create TokenModel
    /// </summary>
    public class TokenFactory
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static TokenFactory _instance = null;

        /// <summary>
        /// Used for singleton pattern
        /// </summary>
        public static TokenFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TokenFactory();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        private TokenFactory () {}

        /// <summary>
        /// Create a token by its position, and different identifiers
        /// </summary>
        public TokenModel CreateToken(int x, int y, long tagValue, int tagSchema, long extendedValue, long value)
        {
            
            return new TokenModel(x, y, TokenFactory.CreateUniqueIdentifier(tagValue, tagSchema, extendedValue, value));
        }

        /// <summary>
        /// Create a token
        /// </summary>
        public TokenModel CreateToken(int x, int y, string id)
        {

            return new TokenModel(x, y, id);
        }

        /// <summary>
        /// Get the unique identifier from a tag structure
        /// </summary>
        public static string CreateUniqueIdentifier(long tagValue, int tagSchema, long extendedValue, long value)
        {
            return String.Concat(
                new List<string>
                {
                    tagValue.ToString(),
                    tagSchema.ToString(),
                    extendedValue.ToString(),
                    value.ToString()
                }
            );
        }
    }
}