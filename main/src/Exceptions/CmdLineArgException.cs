/**
* @file
* @brief The exception which the command-line arguments process was failed.
*/
using System;

namespace BookmarkCreator.Exceptions
{
    /// <summary>
    /// The exception which the command-line arguments process was failed.
    /// </summary>
    public class CmdLineArgException : System.Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        public CmdLineArgException( string msg ) : base(msg){}
    }
}
