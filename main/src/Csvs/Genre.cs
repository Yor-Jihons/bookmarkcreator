/**
* @file
* @brief The class to manage the genres which the class Data has.
*/

using System.Linq;

namespace BookmarkCreator.Csvs
{
    /// <summary>
    /// The class to manage the genres which the class Data has.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Create the object of this class (as a factory).
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The object of this class.</returns>
        public static Genre Create( string text )
        {
            var genres = text.Split( "#" );
            genres = genres.Where((source, index) => !source.Equals( string.Empty ) ).ToArray();
        return new Genre( genres );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="genres">The array of string, which means genre.</param>
        private Genre( string[] genres )
        {
            this.Genres = genres;
        }

        /// <summary>
        /// Create the string to debug.
        /// </summary>
        /// <returns>The string to debug.</returns>
        public override string ToString()
        {
            string text = "";
            for( int i = 0; i < this.Genres.Length; i++ )
            {
                text += " #" + this.Genres[i];
            }
        return text;
        }

        /// <value>The array of string, which means genre.</value>
        public string[] Genres{ get; private set; }
    }
}
