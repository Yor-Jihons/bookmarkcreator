/**
* @file CmdLineArgException.cs
* @brief The exception which the command-line arguments process was failed.
*/
using System;

namespace BookmarkCreator.Exceptions
{
    public class FileFormatException : System.Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="msg">表示文字列</param>
        public FileFormatException( string msg ) : base(msg){}
    }
}
