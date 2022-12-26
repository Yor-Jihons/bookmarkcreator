using System;

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

                var tags = Executions.Executor.Read( cmdline.DefinitionFilePath );

                string contentString = Executions.Executor.CreateContentString( tags );

                string htmlString = Executions.Executor.CreateHtmlString( cmdline.TemplateFilePath, contentString );

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
