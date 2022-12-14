using System;

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
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }
        }
    }
}
