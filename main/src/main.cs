using System;

namespace BookmarkCreator
{
    class Program
    {
        static void Main( string[] args )
        {
            try
            {
                // Analize the command-line arguments.
                var cmdline = CmdLines.CommandLine.Create( args );
                if( cmdline == null ) return;

                // Read the definition file.
                var tags = Executions.Executor.Read( cmdline.DefinitionFilePath );

                // Make the object of dictionary data.
                string contentString = Executions.Executor.CreateContentString( tags );

                // Make the result html string.
                string htmlString = Executions.Executor.CreateHtmlString( cmdline.TemplateFilePath, contentString );

                // Write the file.
                (new Factories.FilePrinter( cmdline.OutputFilePath )).Print( htmlString );

                Console.WriteLine( "Created " + cmdline.OutputFilePath + " the bookmark-html file." );
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }
        }
    }
}
