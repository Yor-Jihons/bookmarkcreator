using System;
using Xunit;

namespace main.xTests;

public class UnitTest1
{
    /// <summary>
    /// Test for the class CommandLine.
    /// </summary>
    [Fact]
    public void TestCommandLine()
    {
        string[] args1 = new string[]{ "--definition=def_file.txt", "--output=result_file.html", "--title=Bookmark1", "--template=template.html" };
        var cmdline = BookmarkCreator.CmdLines.CommandLine.Create( args1 );

        Assert.NotSame( cmdline, null );

        Assert.Equal( cmdline.DefinitionFilePath, "def_file.txt" );
        Assert.Equal( cmdline.OutputFilePath, "result_file.html" );
        Assert.Equal( cmdline.Title, "Bookmark1" );
        Assert.Equal( cmdline.TemplateFilePath, "template.html" );
    }
}