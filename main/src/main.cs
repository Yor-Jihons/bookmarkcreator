using System.Text;
using System;
using System.Collections.Generic;

namespace BookmarkCreator
{
    class Program
    {
        static void Main( string[] args )
        {
            try
            {
                var cmdline = CmdLines.CommandLine.Create( args );
                if( cmdline == null ) return;

                //Console.WriteLine( cmdline.DefinitionFilePath );
                //Console.WriteLine( cmdline.OutputFilePath );
                //Console.WriteLine( cmdline.Title );

                //Console.WriteLine( cmdline.TemplateFilePath );

                var data = Csvs.CsvReader.Read( cmdline.DefinitionFilePath );

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

                var template = (new Factories.TemplateFileScanner( cmdline.TemplateFilePath )).Scan();

                var resultBuilder = new StringBuilder( template );
                //resultBuilder.Replace( "[HERE]", contentBuilder.ToString() );

                //resultBuilder.Replace( "[TITLE]", cmdline.Title );

                //Console.WriteLine( "[RESULT]\n" + resultBuilder.ToString() );

                (new Factories.FilePrinter( cmdline.OutputFilePath )).Print( resultBuilder.ToString() );
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }
        }
    }
}
