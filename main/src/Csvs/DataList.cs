using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkCreator.Csvs
{
    public class DataList
    {
        public DataList()
        {
            this.Data = new List<Data>();
        }

        public void Add( Csvs.Data data )
        {
            this.Data.Add( data );
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach( var data in this.Data )
            {
                builder.Append( data.ToString() );
                builder.Append( "\n" );
            }
        return builder.ToString();
        }

        private List<Csvs.Data> Data{ get; set; }
    }
}
