/**
* @file
* @brief The class to write the file.
*/

namespace BookmarkCreator.Factories
{
    /// <summary>
    /// The class to write the file.
    /// </summary>
    public class FilePrinter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filepath">The file path which the user wants to create.</param>
        public FilePrinter( string filepath )
        {
            this.FilePath = filepath;
        }

        /// <summary>
        /// Write the data to the file.
        /// </summary>
        /// <param name="htmlText">The data, which is a html.</param>
        public void Print( string htmlText )
        {
            using(var sr = new System.IO.StreamWriter( this.FilePath, false, new System.Text.UTF8Encoding( false ) ) )
            {
                sr.WriteLine( htmlText );
            }
        }

        /// <value>The file path which the user wants to create.</value>
        private string FilePath{ get; set; }
    }
}
