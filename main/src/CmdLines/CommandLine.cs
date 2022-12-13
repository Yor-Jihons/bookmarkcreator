using System.Security.Cryptography.X509Certificates;
using System;
using System.Text;

namespace BookmarkCreator.CmdLines
{
    public class CommandLine
    {
        public static CommandLine Create( string[] args )
        {
            string definitionFile = "", outputFile = "";
            StringComparison sc = StringComparison.CurrentCultureIgnoreCase;
            foreach( var arg in args )
            {
                if( arg.Equals( "--help", sc ) || arg.Equals( "-h", sc ) )
                {
                    Console.WriteLine( CommandLine.CreateHelpString() );
                    return null;
                }

                if( arg.Equals( "-g", sc ) )
                {
                    string txt = (new Factories.TemplateFileScanner( "" )).Scan();
                    (new Factories.FilePrinter( "new_template.html" )).Print( txt );
                    return null;
                }

                if( arg.Contains( "--definition=", sc ) || arg.Contains( "-d=", sc ) )
                {
                    definitionFile = CommandLine.SubStringEx( arg );
                }
                else if( arg.Contains( "--output=", sc ) || arg.Contains( "-o=", sc ) )
                {
                    outputFile = CommandLine.SubStringEx( arg );
                }
            }

            if( (definitionFile.Equals( string.Empty ) || outputFile.Equals( string.Empty )) )
                throw new Exceptions.CmdLineArgException( "\n" + CommandLine.CreateHelpString() );

        return new CommandLine( definitionFile, outputFile );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="definitionFile">The file path as a definition file.</param>
        /// <param name="outputFile">The html-file path as a result.</param>
        public CommandLine( string definitionFile, string outputFile )
        {
            this.DefinitionFilePath = definitionFile;
            this.OutputFilePath     = outputFile;
        }

        public string DefinitionFilePath{ get; private set; }

        public string OutputFilePath{ get; private set; }

        private static string CreateHelpString()
        {
            var builder = new StringBuilder();
            builder.Append( "[CMD]\n" );
            builder.Append( "$ BookmarkCreator -g\n" );
            builder.Append( "$ BookmarkCreator --definition=<FILEPATH> [--output=<FILEPATH>]\n" );
            builder.Append( "$ BookmarkCreator --help\n" );
            builder.Append( "\n" );
            builder.Append( "[ARGUMENTS]\n" );
            builder.Append( "-g:\n" );
            builder.Append( "    Create an html-file as a template.\n" );
            builder.Append( "--definition=<FILEPATH>:\n" );
            builder.Append( "    Pass the file, which is based on csv, as a definition-file.\n" );
            builder.Append( "    (Shortened: -d=<FILEPATH>)\n" );
            builder.Append( "--output=<FILEPATH>:\n" );
            builder.Append( "    Pass the directory path where you want to create a result html file on.\n" );
            builder.Append( "    (Shortened: -o=<FILEPATH>)\n" );
            builder.Append( "--help:\n" );
            builder.Append( "    Show this help.\n" );
            builder.Append( "    (Shortened: -h)\n" );
        return builder.ToString();
        }

        /// <summary>
        /// Create a string which deleted "...=" from "...=<***>".
        /// </summary>
        /// <param name="str">A string</param>
        /// <returns>A string which deleted "...=" from "...=<***>".</returns>
        private static string SubStringEx( string str ){
            // 1. 文字列から "=" の位置を取り出す
            int beginPos = str.IndexOf( "=" );
            beginPos++; // その次から取り出す

            // 2. 取り出す
            string res = str.Substring( beginPos );
        return res;
        }
    }
}
