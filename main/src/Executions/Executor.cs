/**
* @file
* @brief The util class to separate methods from the method Main.
*/

using System.Collections.Generic;
using System.Text;

namespace BookmarkCreator.Executions
{
    /// <summary>
    /// The util class to separate methods from the method Main.
    /// </summary>
    public static class Executor
    {
        /// <summary>
        /// Read the definition file.
        /// </summary>
        /// <param name="filepath">The path of the definition file.</param>
        /// <returns>The dictionary for the data.</returns>
        public static Dictionary<string, Csvs.DataList> Read( string filepath )
        {
            var data = Csvs.CsvReader.Read( filepath );

            Dictionary<string, Csvs.DataList> tags = new Dictionary<string, Csvs.DataList>();
            foreach( var d in data )
            {
                var genres = d.GetGenres();
                foreach( var genre in genres )
                {
                    if( !tags.ContainsKey( genre ) )
                    {
                        tags[ genre ] = new Csvs.DataList( genre );
                    }

                    tags[ genre ].Add( d );
                }
            }
        return tags;
        }

        /// <summary>
        /// Create the string from the data.
        /// </summary>
        /// <param name="tags">The dictionary of the data.</param>
        /// <returns>The string made from the data.</returns>
        public static string CreateContentString( Dictionary<string, Csvs.DataList> tags )
        {
            var listBuilder = new StringBuilder();
            listBuilder.Append( "    <ul>\n" );
            var tableBuilder = new StringBuilder();

            foreach( KeyValuePair<string, Csvs.DataList> item in tags )
            {
                listBuilder.Append( item.Value.ToListHtmlString() );
                listBuilder.Append( "\n" );
                tableBuilder.Append( item.Value.ToTableHtmlString() );
                tableBuilder.Append( "\n" );
            }

            listBuilder.Append( "    </ul>\n\n" );

            var contentBuilder = new StringBuilder( listBuilder.ToString() );
            contentBuilder.Append( tableBuilder );
        return contentBuilder.ToString();
        }

        /// <summary>
        /// Create the html string with template file.
        /// </summary>
        /// <param name="templateFilePath">The file path as a template html.</param>
        /// <param name="contentString">The string made from the dictionary for the data.</param>
        /// <returns>The result html string.</returns>
        public static string CreateHtmlString( string templateFilePath, string contentString )
        {
            var template = (new Factories.TemplateFileScanner( templateFilePath )).Scan();
            var resultBuilder = new StringBuilder( template );
            resultBuilder.Append( contentString );
        return resultBuilder.ToString();
        }
    }
}