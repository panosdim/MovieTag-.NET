# Movie Tag Sharp
A .Net Core WPF application that write tags and cover art images in mp4 and mkv video files.
It uses the [JSON API](http://api.themoviedb.org/) provided by [TMdB](https://www.themoviedb.org/).

## Screenshots
![main](https://user-images.githubusercontent.com/10371312/50688641-0979df00-102f-11e9-8ce0-e5eec0fca3e6.PNG)
![search](https://user-images.githubusercontent.com/10371312/50688660-1ac2eb80-102f-11e9-8f30-293cbab2380c.PNG)
![write](https://user-images.githubusercontent.com/10371312/50688666-1e567280-102f-11e9-8f8a-3d490d67e43c.PNG)

## Build
In order to build the project you need [Visual Studio](https://visualstudio.microsoft.com/).
Clone the repository and open the project with Visual Studio.

Then in `App.config` file replace the value of `tmdb` key with your TMDb key.

## Libraries Used
* [TagLib#](https://github.com/mono/taglib-sharp) used for editing metadata of movie files.
* [themoviedbapi](https://github.com/holgerbrandl/themoviedbapi) used to access the TMDb API.
* [TMDbLib](https://github.com/LordMike/TMDbLib) used for interaction with TMDb API.
