/**
* @file
* @brief The exception which reading a file was failed.
*/
using System;

namespace BookmarkCreator.Exceptions
{
    /// <summary>
    /// The exception which reading a file was failed.
    /// </summary>
    public class FileFormatException : System.Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        public FileFormatException( string msg ) : base(msg){}
    }
}
