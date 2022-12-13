using System;

namespace BookmarkCreator.Factories
{

    public class TemplateFileScanner
    {
        public TemplateFileScanner( string filepath )
        {
            this.FilePath = filepath;
        }

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

        private string FilePath{ get; set; }
    }
}
