using System;
using Xunit;

namespace main.xTests;

public class UnitTest1
{
    /// <summary>
    /// Test for the class CommandLine.
    /// </summary>
    [Fact]
    public void CommandLineTest()
    {
        string[] args1 = new string[]{ "--definition=def_file.txt", "--output=result_file.html", "--title=Bookmark1", "--template=template.html" };
        var cmdline1 = BookmarkCreator.CmdLines.CommandLine.Create( args1 );

        Assert.NotSame( cmdline1, null );

        Assert.Equal( cmdline1.DefinitionFilePath, "def_file.txt" );
        Assert.Equal( cmdline1.OutputFilePath, "result_file.html" );
        Assert.Equal( cmdline1.Title, "Bookmark1" );
        Assert.Equal( cmdline1.TemplateFilePath, "template.html" );
    }

    [Fact]
    public void GenreTest()
    {
        string text = "#English#Spanish#French";
        var genre = BookmarkCreator.Csvs.Genre.Create( text );

        Assert.Equal( " #English #Spanish #French", genre.ToString() );

        Assert.Equal( "Spanish", genre.Genres[1] );
    }

    [Fact]
    public void DataTest()
    {
        string text = "How2Learn,http://how2learn.hahaha/,This is test.,#English#Spanish#French";
        var data = BookmarkCreator.Csvs.Data.Create( text );

        Assert.Equal( "Title = How2Learn, Url = http://how2learn.hahaha/, Summary = This is test., Genres =  #English #Spanish #French", data.ToString() );

        string exected1 = "            <tr>\n";
        exected1 += "                <td class=\"id\">1</td>\n";
        exected1 += "                <td class=\"title\"><a href=\"http://how2learn.hahaha/\">How2Learn</a></td>\n";
        exected1 += "                <td class=\"url\">http://how2learn.hahaha/</td>\n";
        exected1 += "                <td class=\"summary\">This is test.</td>\n";
        exected1 += "            </tr>\n";
        Assert.Equal( exected1, data.ToTableHtmlString( 1 ) );
    }
}