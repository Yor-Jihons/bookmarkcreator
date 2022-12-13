using System;

namespace BookmarkCreator.Factories
{
    public class FilePrinter
    {
        public FilePrinter( string filepath )
        {
            this.FilePath = filepath;
        }

        public void Print( string htmlText )
        {
            using(var sr = new System.IO.StreamWriter( this.FilePath, false, new System.Text.UTF8Encoding( false ) ) )
            {
                sr.WriteLine( htmlText );
            }
        }

        private string FilePath{ get; set; }
    }
}
