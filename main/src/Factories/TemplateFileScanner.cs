/**
* @file
* @brief The class to read a file.
*/

namespace BookmarkCreator.Factories
{
    /// <summary>
    /// The class to read a file.
    /// </summary>
    public class TemplateFileScanner
    {
        /// <summary>
        /// Costructor.
        /// </summary>
        /// <param name="filepath">The file path which the user wants to read.</param>
        public TemplateFileScanner( string filepath )
        {
            this.FilePath = filepath;
        }

        /// <summary>
        /// Read the file.
        /// </summary>
        /// <returns>The string from a file.</returns>
        public string Scan()
        {
            if( this.FilePath.Equals( string.Empty ) )
            {
                var asm = System.Reflection.Assembly.GetExecutingAssembly();
                using(var stream = asm.GetManifestResourceStream( "template.html" ) )
                {
                    using(var sr = new System.IO.StreamReader( stream ) )
                    {
                        return sr.ReadToEnd();
                    }
                }
            }

            using(var sr = new System.IO.StreamReader( this.FilePath, new System.Text.UTF8Encoding( false ) ) )
            {
                return sr.ReadToEnd();
            }
        }

        /// <value>The file path which the user wants to read.</value>
        private string FilePath{ get; set; }
    }
}
