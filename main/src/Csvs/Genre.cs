using System;
using System.Collections.Generic;

using System.Linq;

namespace BookmarkCreator.Csvs
{
    public class Genre
    {
        public static Genre Create( string text )
        {
            var genres = text.Split( "#" );
            genres = genres.Where((source, index) => !source.Equals( string.Empty ) ).ToArray();
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
                text += " #" + this.Genres[i];
            }
        return text;
        }

        public string[] Genres{ get; private set; }
    }
}
