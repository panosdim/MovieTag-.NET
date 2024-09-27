# Movie Tag
A .Net Core WPF application that write tags and cover art images in mp4 and mkv video files.
It uses the [JSON API](http://api.themoviedb.org/) provided by [TMDb](https://www.themoviedb.org/).

## Screenshots
![Main](https://user-images.githubusercontent.com/10371312/84494254-d884eb80-acb1-11ea-95b9-61fee3e9626a.PNG)
![Open](https://user-images.githubusercontent.com/10371312/84494258-da4eaf00-acb1-11ea-8ec4-3604417a2d8b.PNG)
![Opened](https://user-images.githubusercontent.com/10371312/84494263-db7fdc00-acb1-11ea-8475-a9c30076f129.PNG)
![Search](https://user-images.githubusercontent.com/10371312/84494272-dd499f80-acb1-11ea-9058-8b4c46a9b3c6.PNG)
![Selected](https://user-images.githubusercontent.com/10371312/84494275-de7acc80-acb1-11ea-8fc7-b80955a2279b.PNG)
![Saved](https://user-images.githubusercontent.com/10371312/84494280-e0449000-acb1-11ea-9355-f0a845970246.PNG)

## Build
In order to build the project you need [Visual Studio](https://visualstudio.microsoft.com/).
Clone the repository and open the project with Visual Studio.

Then in `App.config` file replace the value of `tmdb` key with your TMDb key.

## Libraries Used
* [TagLib#](https://github.com/mono/taglib-sharp) used for editing metadata of movie files.
* [TMDbLib](https://github.com/LordMike/TMDbLib) used for interaction with TMDb API.
