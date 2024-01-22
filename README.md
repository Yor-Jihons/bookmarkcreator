# BookmarkCreator

This is the product which makes the HTML file as a bookmark.

## 1. Requirements

- dotnet 6.0.202
- Windows OS (later 7)

## 2. Install

Step 1. Run the bat-file commpile.bat with a command-line argument.
You can pass the arguments { "debug" | "release" | "publish" }.
You can also run dotnet as usual.

```
$ compile publish
```

or like

```
$ dotnet publish -o .\bin\Publish -c Release --self-contained true -r win-x64 -nologo
```

## 3. Usage

Step 1. Run the bat file "run.bat".

```
$ run.bat
```

See also [the online help](https://yor-jroom.com/help/en/bookmarkcreator.html) ( or [for Japanese](https://yor-jroom.com/help/ja/bookmarkcreator.html) ).

## 4. Licenses

This library is released under the MIT License.

## 5. Development Environment

- dotnet
- Language: C#

## 6. Contact

Author: Yor-Jihons  
GitHub: [BookmarkCreator](https://github.com/Yor-Jihons/bookmarkcreator)  
