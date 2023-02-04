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
    public void DataTest1()
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

    [Fact]
    public void DataTest2()
    {
        // タイトルが無い場合
        try
        {
            string text1 = "#English#Spanish#French";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
            Assert.Equal( 2, 1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // URLが無い場合
        try
        {
            string text1 = "How2Learn";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
            Assert.Equal( 2, 1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // Summaryが無い場合
        try
        {
            string text1 = "How2Learn,http://how2learn.hahaha/";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
            Assert.Equal( 2, 1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // Genresが無い場合
        try
        {
            string text1 = "How2Learn,http://how2learn.hahaha/,This is test.";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
            Assert.Equal( 2, 1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // タイトルが空の場合
        try
        {
            string text1 = ",http://how2learn.hahaha/,This is test.,#English#Spanish#French";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // URLが空の場合
        try
        {
            string text1 = "How2Learn,,This is test.,#English#Spanish#French";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }

        // Sammaryが空の場合
        try
        {
            string text1 = "How2Learn,http://how2learn.hahaha/,,#English#Spanish#French";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
            Assert.Equal( 1, 1 );
        }
        catch( Exception )
        {
            Assert.True( false );
        }

        // Genresが空の場合
        try
        {
            string text1 = "How2Learn,http://how2learn.hahaha/,This is test.,";
            var data1 = BookmarkCreator.Csvs.Data.Create( text1 );
        }
        catch( Exception )
        {
            Assert.True( true );
        }
    }
}