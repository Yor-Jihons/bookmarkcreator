/**
* @file
* @brief The class to contain the data which the definition-file has.
*/

using System.Text;

namespace BookmarkCreator.Csvs
{
    /// <summary>
    /// The class to contain the data which the definition-file has.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Create the object of this class (as a factory).
        /// </summary>
        /// <param name="text">The text which the definition-file has.</param>
        /// <returns>The object of this class.</returns>
        public static Data Create( string text )
        {
            var texts = text.Split( "," );

            if( texts.Length < 1 || texts[0].Equals( string.Empty ) ) throw new Exceptions.FileFormatException( "The definition file has no title for a item." );

            string title = texts[0];

            if( texts.Length < 2 || texts[1].Equals( string.Empty )  ) throw new Exceptions.FileFormatException( "The definition file has no URL for a item." );

            string url = texts[1];

            if( texts.Length < 3 ) throw new Exceptions.FileFormatException( "The definition file has no summary for a item." );

            string summary = texts[2];

            if( texts.Length < 4 || texts[3].Equals( string.Empty )  ) throw new Exceptions.FileFormatException( "The definition file has no genre for a item." );

            var genres = Genre.Create( texts[3] );

        return new Data( title, url, summary, genres );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">The title for an url.</param>
        /// <param name="url">The target url.</param>
        /// <param name="summary">The summary text.</param>
        /// <param name="genre">The object of the class Genre, which the url has.</param>
        private Data( string title, string url, string summary, Genre genre )
        {
            this.Title   = title;
            this.Url     = url;
            this.Summary = summary;
            this.Genre   = genre;
        }

        /// <summary>
        /// Get the array of the class Genre.
        /// </summary>
        /// <returns>The array of the class Genre.</returns>
        public string[] GetGenres()
        {
            return this.Genre.Genres;
        }

        /// <summary>
        /// Creaate the html string for the table.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The html string for the table.</returns>
        public string ToTableHtmlString( int id )
        {
            var builder = new StringBuilder();
            builder.Append( "            " );
            builder.Append( "<tr>\n" );
            builder.Append( "                " );
            builder.Append( "<td class=\"id\">" );
            builder.Append( id.ToString() );
            builder.Append( "</td>\n" );
            builder.Append( "                " );
            builder.Append( "<td class=\"title\"><a href=\"" );
            builder.Append( this.Url );
            builder.Append( "\">" );
            builder.Append( this.Title );
            builder.Append( "</a></td>\n" );
            builder.Append( "                " );
            builder.Append( "<td class=\"url\">" );
            builder.Append( this.Url );
            builder.Append( "</td>\n" );
            builder.Append( "                " );
            builder.Append( "<td class=\"summary\">" );
            builder.Append( this.Summary );
            builder.Append( "</td>\n" );
            builder.Append( "            " );
            builder.Append( "</tr>\n" );
        return builder.ToString();
        }

        /// <summary>
        /// Create the string to debug.
        /// </summary>
        /// <returns>The string to debug.</returns>
        public override string ToString()
        {
            return "Title = " + this.Title + ", " + "Url = " + this.Url + ", " + "Summary = " + this.Summary + ", Genres = " + this.Genre.ToString();
        }

        /// <value>The title for the Url.</value>
        private string Title{ get; set; }

        /// <value>The Url.</value>
        private string Url{ get; set; }

        /// <value>The summary text.</value>
        private string Summary{ get; set; }

        /// <value>The object of the class Genre, which the Url has.</value>
        private Genre Genre{ get; set; }
    }
}
