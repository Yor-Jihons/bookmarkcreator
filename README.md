# BookmarkCreator 1.0.0

This is the product which makes the HTML file as a bookmark.

## 1. Requirements

- dotnet 6.0.202
- Windows OS
- [NLog - NuGet Gallery](https://www.nuget.org/packages/NLog/)

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

## 4. Licenses

This library is released under the MIT License.

[NLog - NuGet Gallery](https://www.nuget.org/packages/NLog/) is under the BSD-3-Clause license.

The image files in the directory "main/res/Frames" are downloaded from [GAHAG | 著作権フリー写真・イラスト素材集](https://gahag.net/), and under the [CC0](https://creativecommons.org/share-your-work/public-domain/cc0) License.

The Icon file are downloaded from [icon-icons.com](https://icon-icons.com/ja/%E3%82%A2%E3%82%A4%E3%82%B3%E3%83%B3/%E3%82%A2%E3%83%97%E3%83%AA/129133), and under the CC Atribution.

## 5. Development Environment

- dotnet
- Language: C#

## 6. Changes

## 7. Contact

Author: Yor-Jihons  
GitHub: [BookmarkCreator](https://github.com/Yor-Jihons/bookmarkcreator)  
