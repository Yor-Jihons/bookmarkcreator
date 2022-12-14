using System;
using System.Collections.Generic;

namespace BookmarkCreator.Csvs
{
    public class CsvReader
    {
        public List<Data> Read( string filepath )
        {
            List<Data> data = new List<Data>();
            var sr = new System.IO.StreamReader( filepath, new System.Text.UTF8Encoding( false ) );
            String tmp = "";
            while( (tmp = sr.ReadLine()) != null ){
                data.Add( Data.Create( tmp ) );
            }
            sr.Close();
        return data;
        }
    }
}
