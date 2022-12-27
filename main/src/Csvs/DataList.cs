/**
* @file
* @brief The class as a list in order to manage the data which the definition-file has.
*/

using System.Collections.Generic;
using System.Text;

namespace BookmarkCreator.Csvs
{
    /// <summary>
    /// The class as a list in order to manage the data which the definition-file has.
    /// </summary>
    public class DataList
    {
        /// <summary>
        /// The class as a list in order to manage the data which the definition-file has.
        /// </summary>
        /// <param name="title">The title for the HTML file.</param>
        public DataList( string title )
        {
            this.Title = title;
            this.Data = new List<Data>();
        }

        /// <summary>
        /// Add an object of the class Data.
        /// </summary>
        /// <param name="data">An object of the class Data.</param>
        public void Add( Csvs.Data data )
        {
            this.Data.Add( data );
        }

        /// <summary>
        /// Create the string made from the data which this object has.
        /// </summary>
        /// <returns>The string made from the data which this object has.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach( var data in this.Data )
            {
                builder.Append( data.ToString() );
                builder.Append( "\n" );
            }
        return builder.ToString();
        }

        /// <summary>
        /// Create an html string for a list.
        /// </summary>
        /// <returns>An html string for a list.</returns>
        public string ToListHtmlString()
        {
            var builder = new StringBuilder();
            builder.Append( "        " );
            builder.Append( "<li><a href=\"#" );
            builder.Append( this.Title );
            builder.Append( "\">" );
            builder.Append( this.Title );
            builder.Append( "</a></li>" );
        return builder.ToString();
        }

        /// <summary>
        /// Create an html string for the table.
        /// </summary>
        /// <returns>An html string for the table.</returns>
        public string ToTableHtmlString()
        {
            var builder = new StringBuilder();
            builder.Append( "    ");
            builder.Append( "<h2 id=\"" );
            builder.Append( this.Title );
            builder.Append( "\">" );
            builder.Append( this.Title );
            builder.Append( "</h2>\n" );
            builder.Append( "    ");
            builder.Append( "<div class=\"table_area\">\n" );
            builder.Append( "        ");
            builder.Append( "<table class=\"web_list_table\">\n" );
            builder.Append( "            ");
            builder.Append( "<tr>\n" );
            builder.Append( "                ");
            builder.Append( "<th class=\"id\">ID</th>\n" );
            builder.Append( "                ");
            builder.Append( "<th class=\"title\">タイトル</th>\n" );
            builder.Append( "                ");
            builder.Append( "<th class=\"url\">URL</th>\n" );
            builder.Append( "                ");
            builder.Append( "<th class=\"summary\">概要</th>\n" );
            builder.Append( "            ");
            builder.Append( "</tr>\n" );
            builder.Append( "\n" );
            int i = 1;
            foreach( var data in this.Data )
            {
                builder.Append( data.ToTableHtmlString( i ) );
                i++;
            }
            builder.Append( "        ");
            builder.Append( "</table>\n" );
            builder.Append( "    ");
            builder.Append( "</div>\n" );
        return builder.ToString();
        }

        /// <value>The title for the HTML file.</value>
        private string Title{ get; set; }

        /// <value>The list of the class Data, which this object manages.</value>
        private List<Csvs.Data> Data{ get; set; }
    }
}
