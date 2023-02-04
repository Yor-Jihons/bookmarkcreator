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

    [Fact]
    public void DataListTest()
    {
        var dataList = new BookmarkCreator.Csvs.DataList( "Bookmark2" );
        string text1 = "How2Learn,http://how2learn.hahaha/,This is test.,#English#Spanish#French";
        dataList.Add( BookmarkCreator.Csvs.Data.Create( text1 ) );
        string text2 = "How2Speak,http://how2speak.hahaha/,This is test.LOL,#English";
        dataList.Add( BookmarkCreator.Csvs.Data.Create( text2 ) );

        Assert.Equal( "        <li><a href=\"#Bookmark2\">Bookmark2</a></li>", dataList.ToListHtmlString() );

        string exected = "";
        exected += "    <h2 id=\"Bookmark2\">Bookmark2</h2>\n";
        exected += "    <div class=\"table_area\">\n";
        exected += "        <table class=\"web_list_table\">\n";
        exected += "            <tr>\n";
        exected += "                <th class=\"id\">ID</th>\n";
        exected += "                <th class=\"title\">タイトル</th>\n";
        exected += "                <th class=\"url\">URL</th>\n";
        exected += "                <th class=\"summary\">概要</th>\n";
        exected += "            </tr>\n";
        exected += "\n";
        exected += "            <tr>\n";
        exected += "                <td class=\"id\">1</td>\n";
        exected += "                <td class=\"title\"><a href=\"http://how2learn.hahaha/\">How2Learn</a></td>\n";
        exected += "                <td class=\"url\">http://how2learn.hahaha/</td>\n";
        exected += "                <td class=\"summary\">This is test.</td>\n";
        exected += "            </tr>\n";
        exected += "            <tr>\n";
        exected += "                <td class=\"id\">2</td>\n";
        exected += "                <td class=\"title\"><a href=\"http://how2speak.hahaha/\">How2Speak</a></td>\n";
        exected += "                <td class=\"url\">http://how2speak.hahaha/</td>\n";
        exected += "                <td class=\"summary\">This is test.LOL</td>\n";
        exected += "            </tr>\n";
        exected += "        </table>\n";
        exected += "    </div>\n";

        Assert.Equal( exected, dataList.ToTableHtmlString() );
    }

    [Fact]
    public void CsvReaderTest()
    {
        string filepath = @"..\..\..\sample.csv";
        System.Collections.Generic.List<BookmarkCreator.Csvs.Data> ret = BookmarkCreator.Csvs.CsvReader.Read( filepath );

        Assert.Equal( 2, ret.Count );

        Assert.Equal( "Title = How2Learn, Url = http://how2learn.hahaha/, Summary = This is test., Genres =  #English #Spanish #French", ret[1].ToString() );
    }

    [Fact]
    public void ExecutorTest()
    {
        string filepath = @"..\..\..\sample.csv";
        var ret = BookmarkCreator.Executions.Executor.Read( filepath );

        string exected1 = "";
        exected1 += "Title = WhyYouLearn, Url = http://whyoulearn.hahaha/, Summary = This is test., Genres =  #English";
        exected1 += "\n";
        exected1 += "Title = How2Learn, Url = http://how2learn.hahaha/, Summary = This is test., Genres =  #English #Spanish #French";
        exected1 += "\n";
        Assert.Equal( exected1, ret[ "English" ].ToString() );

        string exected2 = "";
        exected2 += "Title = How2Learn, Url = http://how2learn.hahaha/, Summary = This is test., Genres =  #English #Spanish #French";
        exected2 += "\n";
        Assert.Equal( exected2, ret[ "Spanish" ].ToString() );

        string exected3 = "";
        exected3 += "    <ul>\n";
        exected3 += "        <li><a href=\"#English\">English</a></li>\n";
        exected3 += "        <li><a href=\"#Spanish\">Spanish</a></li>\n";
        exected3 += "        <li><a href=\"#French\">French</a></li>\n";
        exected3 += "    </ul>\n";
        exected3 += "\n";
        exected3 += "    <h2 id=\"English\">English</h2>\n";
        exected3 += "    <div class=\"table_area\">\n";
        exected3 += "        <table class=\"web_list_table\">\n";
        exected3 += "            <tr>\n";
        exected3 += "                <th class=\"id\">ID</th>\n";
        exected3 += "                <th class=\"title\">タイトル</th>\n";
        exected3 += "                <th class=\"url\">URL</th>\n";
        exected3 += "                <th class=\"summary\">概要</th>\n";
        exected3 += "            </tr>\n";
        exected3 += "\n";
        exected3 += "            <tr>\n";
        exected3 += "                <td class=\"id\">1</td>\n";
        exected3 += "                <td class=\"title\"><a href=\"http://whyoulearn.hahaha/\">WhyYouLearn</a></td>\n";
        exected3 += "                <td class=\"url\">http://whyoulearn.hahaha/</td>\n";
        exected3 += "                <td class=\"summary\">This is test.</td>\n";
        exected3 += "            </tr>\n";
        exected3 += "            <tr>\n";
        exected3 += "                <td class=\"id\">2</td>\n";
        exected3 += "                <td class=\"title\"><a href=\"http://how2learn.hahaha/\">How2Learn</a></td>\n";
        exected3 += "                <td class=\"url\">http://how2learn.hahaha/</td>\n";
        exected3 += "                <td class=\"summary\">This is test.</td>\n";
        exected3 += "            </tr>\n";
        exected3 += "        </table>\n";
        exected3 += "    </div>\n";
        exected3 += "\n";
        exected3 += "    <h2 id=\"Spanish\">Spanish</h2>\n";
        exected3 += "    <div class=\"table_area\">\n";
        exected3 += "        <table class=\"web_list_table\">\n";
        exected3 += "            <tr>\n";
        exected3 += "                <th class=\"id\">ID</th>\n";
        exected3 += "                <th class=\"title\">タイトル</th>\n";
        exected3 += "                <th class=\"url\">URL</th>\n";
        exected3 += "                <th class=\"summary\">概要</th>\n";
        exected3 += "            </tr>\n";
        exected3 += "\n";
        exected3 += "            <tr>\n";
        exected3 += "                <td class=\"id\">1</td>\n";
        exected3 += "                <td class=\"title\"><a href=\"http://how2learn.hahaha/\">How2Learn</a></td>\n";
        exected3 += "                <td class=\"url\">http://how2learn.hahaha/</td>\n";
        exected3 += "                <td class=\"summary\">This is test.</td>\n";
        exected3 += "            </tr>\n";
        exected3 += "        </table>\n";
        exected3 += "    </div>\n";
        exected3 += "\n";
        exected3 += "    <h2 id=\"French\">French</h2>\n";
        exected3 += "    <div class=\"table_area\">\n";
        exected3 += "        <table class=\"web_list_table\">\n";
        exected3 += "            <tr>\n";
        exected3 += "                <th class=\"id\">ID</th>\n";
        exected3 += "                <th class=\"title\">タイトル</th>\n";
        exected3 += "                <th class=\"url\">URL</th>\n";
        exected3 += "                <th class=\"summary\">概要</th>\n";
        exected3 += "            </tr>\n";
        exected3 += "\n";
        exected3 += "            <tr>\n";
        exected3 += "                <td class=\"id\">1</td>\n";
        exected3 += "                <td class=\"title\"><a href=\"http://how2learn.hahaha/\">How2Learn</a></td>\n";
        exected3 += "                <td class=\"url\">http://how2learn.hahaha/</td>\n";
        exected3 += "                <td class=\"summary\">This is test.</td>\n";
        exected3 += "            </tr>\n";
        exected3 += "        </table>\n";
        exected3 += "    </div>\n\n";
        Assert.Equal( exected3, BookmarkCreator.Executions.Executor.CreateContentString( ret ) );
    }
}