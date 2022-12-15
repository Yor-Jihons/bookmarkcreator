using System;
using System.Collections.Generic;

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

        public List<string> CreateList4TagsNotRegistered( Dictionary< string, List<Csvs.Data> > tags )
        {
            List<string> list = new List<string>();
            foreach( var genre in this.Genres )
            {
                if( !tags.ContainsKey( genre ) )
                {
                    list.Add( genre );
                }
            }
        return list;
        }

        private string[] Genres{ get; set; }
    }
}
