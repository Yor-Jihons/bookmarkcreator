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

                Dictionary<string, List<Csvs.Data> > tags = new Dictionary<string, List<Csvs.Data> >();
                foreach( var d in data )
                {
                    Console.WriteLine( d.ToString() );
                }
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }
        }
    }
}
