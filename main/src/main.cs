using System;
using System.Collections.Generic;

namespace BookmarkCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cmdline = CmdLines.CommandLine.Create( args );
                if( cmdline == null ) return;

                Console.WriteLine( cmdline.DefinitionFilePath );
                Console.WriteLine( cmdline.OutputFilePath );
                Console.WriteLine( cmdline.Title );

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

                foreach( KeyValuePair<string, Csvs.DataList> item in tags )
                {
                    Console.WriteLine( "[Key]\n" + item.Key );
                    Console.WriteLine( "[Value]\n" + item.Value.ToString() );

                    Console.WriteLine( "[RESULT]\n" + item.Value.ToHtmlString() );
                }
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }
        }
    }
}
