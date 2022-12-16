using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkCreator.Csvs
{
    public class DataList
    {
        public DataList( string title )
        {
            this.Title = title;
            this.Data = new List<Data>();
        }

        public void Add( Csvs.Data data )
        {
            this.Data.Add( data );
        }

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

        public string ToHtmlString()
        {
            var builder = new StringBuilder();
            builder.Append( "    ");
            builder.Append( "<h2 id=\"#" );
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

        private string Title{ get; set; }

        private List<Csvs.Data> Data{ get; set; }
    }
}
