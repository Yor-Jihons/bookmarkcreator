/**
* @file CmdLineArgException.cs
* @brief The exception which the command-line arguments process was failed.
*/
using System;

namespace BookmarkCreator.Exceptions
{
    public class CmdLineArgException : System.Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="msg">表示文字列</param>
        public CmdLineArgException( string msg ) : base(msg){}
    }
}
