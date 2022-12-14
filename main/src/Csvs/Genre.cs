using System;

namespace BookmarkCreator.Csvs
{
    public class Genre
    {
        public static Genre Create( string text )
        {
            var genres = text.Split( "#" );
        return new Genre( genres );
        }

        public Genre( string[] genres )
        {
            this.Genres = genres;
        }

        public override string ToString()
        {
            string text = "";
            for( int i = 0; i < this.Genres.Length; i++ )
            {
                text += this.Genres[i];
            }
        return text;
        }

        private string[] Genres{ get; set; }
    }
}
