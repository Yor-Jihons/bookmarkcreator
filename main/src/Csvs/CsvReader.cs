/**
* @file
* @brief The static class to read the definition file.
*/

using System;
using System.Collections.Generic;

namespace BookmarkCreator.Csvs
{
    /// <summary>
    /// The static class to read the definition file.
    /// </summary>
    public static class CsvReader
    {
        /// <summary>
        /// Read the the definition file.
        /// </summary>
        /// <param name="filepath">The file path as a definition file.</param>
        /// <returns>The list of the class Data, which the definition file has.</returns>
        public static List<Data> Read( string filepath )
        {
            List<Data> data = new List<Data>();
            var sr = new System.IO.StreamReader( filepath, new System.Text.UTF8Encoding( false ) );
            String tmp = "";
            while( (tmp = sr.ReadLine()) != null )
            {
                if( tmp.StartsWith( "// " ) ) continue;

                data.Add( Data.Create( tmp ) );
            }
            sr.Close();
        return data;
        }
    }
}
