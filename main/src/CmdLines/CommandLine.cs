/**
* @file
* @brief The class to manage the command-line arguments.
*/

using System;
using System.Text;

namespace BookmarkCreator.CmdLines
{
    /// <summary>
    /// The class to manage the command-line arguments.
    /// </summary>
    public class CommandLine
    {
        /// <summary>
        /// Create the object of this class.
        /// </summary>
        /// <param name="args">The commandline-arguments.</param>
        /// <returns>The object of this class.</returns>
        public static CommandLine Create( string[] args )
        {
            // Analyze the commandline arguments.
            string definitionFile = "", outputFile = @".\bookmark.html", title = "bookmark", template = "";
            StringComparison sc = StringComparison.CurrentCultureIgnoreCase;
            foreach( var arg in args )
            {
                if( arg.Equals( "--help", sc ) || arg.Equals( "-h", sc ) )
                {
                    Console.WriteLine( CommandLine.CreateHelpString() );
                    return null;
                }
                else if( arg.Equals( "--version", sc ) || arg.Equals( "-v", sc ) )
                {
                    Console.WriteLine(
                        System.Diagnostics.FileVersionInfo.GetVersionInfo(
                            System.Reflection.Assembly.GetExecutingAssembly().Location
                        ).FileVersion
                    );
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
                else if( arg.Contains( "--template=" )  || arg.Contains( "-tmp=" ) || arg.Contains( "-tmplt=" ) )
                {
                    template = CommandLine.SubStringEx( arg );
                }
                else if( arg.Contains( "--title=", sc ) || arg.Contains( "-t=", sc ) )
                {
                    title = CommandLine.SubStringEx( arg );
                }
            }

            // If the arguments lacked, throw the Exception.
            if( definitionFile.Equals( string.Empty ) )
                throw new Exceptions.CmdLineArgException( "\n" + CommandLine.CreateHelpString() );

        return new CommandLine( definitionFile, outputFile, title, template );
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="definitionFile">The file path as a definition file.</param>
        /// <param name="outputFile">The html-file path as a result.</param>
        /// <param name="title">The title for the tag "title", html.</param>
        /// <param name="template">The path of the template file for result html file.</param>
        public CommandLine( string definitionFile, string outputFile, string title, string template )
        {
            this.DefinitionFilePath = definitionFile;
            this.OutputFilePath     = outputFile;
            this.Title              = title;
            this.TemplateFilePath   = template;
        }

        /// <value>The file path as a definition file.</value>
        public string DefinitionFilePath{ get; private set; }

        /// <value>The file path as a output file.</value>
        public string OutputFilePath{ get; private set; }

        /// <value>The string as a title.</value>
        public string Title{ get; private set; }

        /// <value>The file path as a template file.</value>
        public string TemplateFilePath{ get; private set; }

        /// <summary>
        /// Create the help string for cmdline.
        /// </summary>
        /// <returns>The string for cmdline.</returns>
        private static string CreateHelpString()
        {
            var builder = new StringBuilder();
            builder.Append( "[CMD]\n" );
            builder.Append( "$ BookmarkCreator -g\n" );
            builder.Append( "$ BookmarkCreator --definition=<FILEPATH> [--output=<FILEPATH>] [--title=<STR>] [--template=<FILEPATH>]\n" );
            builder.Append( "$ BookmarkCreator --version\n" );
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
            builder.Append( "--title=<STR>:\n" );
            builder.Append( "    Pass the title for the tag \"title\", with HTML.\n" );
            builder.Append( "    (Shortened: -t=<STR>)\n" );
            builder.Append( "--template=<FILEPATH>:\n" );
            builder.Append( "    Pass the file path as a template file. If you ommit this option, this program will run with a default template.\n" );
            builder.Append( "    (Shortened: -tmp=<FILEPATH> or -tmplt=<FILEPATH>)\n" );
            builder.Append( "--version:\n" );
            builder.Append( "    Show this version.\n" );
            builder.Append( "    (Shortened: -v)\n" );
            builder.Append( "--help:\n" );
            builder.Append( "    Show this help.\n" );
            builder.Append( "    (Shortened: -h)\n" );
            builder.Append( "More information, see also  https://yorroom2.cloudfree.jp/mainroom/en/bookmarkcreator.html or https://yorroom2.cloudfree.jp/help/ja/bookmarkcreator.html ." );
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
