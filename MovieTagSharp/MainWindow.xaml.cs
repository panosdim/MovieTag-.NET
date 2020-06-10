using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TagLib;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using Path = System.IO.Path;

namespace MovieTagSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName;
        private string tmdbKey = System.Configuration.ConfigurationManager.AppSettings["tmdb"];
        private TMDbClient client;
        public static string baseUrl { get; set; }
        private string posterSize;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTmdb();
        }

        private async void InitializeTmdb()
        {
            client = new TMDbClient(tmdbKey);
            await client.GetConfigAsync();
            baseUrl = client.Config.Images.SecureBaseUrl;
            List<string> posterSizes = client.Config.Images.PosterSizes;
            posterSize = "w500";
            if (!posterSizes.Contains("w500"))
            {
                posterSize = posterSizes.First();
            }
        }

        private void openMovie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Movie files (mkv, mp4)|*.mkv; *.mp4|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            if (openFileDialog.ShowDialog() == true)
            {
                searchName.IsEnabled = true;
                search.IsEnabled = true;
                writeTags.IsEnabled = true;

                fileName = openFileDialog.FileName;

                string movieRegex = @"([ .\w']+?)(\W\d{4}\W?.*)";
                string movieName = Path.GetFileNameWithoutExtension(fileName);
                Match match = Regex.Match(movieName, movieRegex);

                if (match.Success)
                {
                    movieName = match.Groups[1].Value.Replace(@".", " ");
                }

                searchName.Text = movieName;

                // Clear previous search results
                searchResults.Items.Clear();
                writeTags.IsEnabled = false;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            searchResults.Items.Clear();
            search.IsEnabled = false;

            SearchContainer<SearchMovie> results = client.SearchMovieAsync(searchName.Text).Result;
            foreach (SearchMovie result in results.Results)
            {
                searchResults.Items.Add(result);
            }

            search.IsEnabled = true;
            writeTags.IsEnabled = false;
        }

        private void searchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            writeTags.IsEnabled = true;
        }

        private void writeTags_Click(object sender, RoutedEventArgs e)
        {
            writeTags.IsEnabled = false;

            var selectedMovie = (SearchMovie)searchResults.SelectedItem;
            string posterPath = selectedMovie.PosterPath;

            var file = File.Create(fileName);
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(baseUrl + posterSize + posterPath);
                var picture = new Picture(imageBytes);
                file.Tag.Pictures = new Picture[] { picture };
                file.Save();
            }

            writeTags.IsEnabled = true;
        }
    }
}
