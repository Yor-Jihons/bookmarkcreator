using System;
using System.Collections.Generic;

namespace BookmarkCreator.Csvs
{
    public class Data
    {
        public static Data Create( string text )
        {
            var texts = text.Split( "," );

            if( texts.Length < 1 ) throw new Exceptions.FileFormatException( "The definition file has no title for a item." );

            string title = texts[0];

            if( texts.Length < 2 ) throw new Exceptions.FileFormatException( "The definition file has no URL for a item." );

            string url = texts[1];

            if( texts.Length < 3 ) throw new Exceptions.FileFormatException( "The definition file has no summary for a item." );

            string summary = texts[2];

            if( texts.Length < 4 ) throw new Exceptions.FileFormatException( "The definition file has no genre for a item." );

            var genres = Genre.Create( texts[3] );

        return new Data( title, url, summary, genres );
        }

        public Data( string title, string url, string summary, Genre genre )
        {
            this.Title   = title;
            this.Url     = url;
            this.Summary = summary;
            this.Genre   = genre;
        }

        public List<string> CreateList4TagsNotRegistered( Dictionary<string, Data> tags )
        {
            return this.Genre.CreateList4TagsNotRegistered( tags );
        }

        public override string ToString()
        {
            return "Title = " + this.Title + ", " + "Url = " + this.Url + ", " + "Summary = " + this.Summary + ", Genres = " + this.Genre.ToString();
        }

        private string Title{ get; set; }
        private string Url{ get; set; }
        private string Summary{ get; set; }
        private Genre Genre{ get; set; }
    }
}
