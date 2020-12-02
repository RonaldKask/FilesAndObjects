using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndObjects
{
    class Movie
    {
        public string title;
        public string rating;
        public string year;

        public Movie(string _title, string _rating, string _year)
        {
            title = _title;
            rating = _rating;
            year = _year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"movietv.txt";
            List<string> movieList = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();

            List<Movie> listofMovies = new List<Movie>();

            foreach(string movieItem in movieList)
            {
                string[] tempArray = movieItem.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                Movie newMovie = new Movie(tempArray[0], tempArray[1], tempArray[2]);

                listofMovies.Add(newMovie);
            }

            foreach(Movie movie in listofMovies)
            {
                Console.WriteLine($"Title: {movie.title}, Rating: {movie.rating}, Year of release:{movie.year}");
            }

            Console.WriteLine("What's your favorite movie? Title:");
            string favoriteTitle = Console.ReadLine();
            Console.WriteLine("Enter the rating for the movie: ");
            string favoriteRating = Console.ReadLine();
            Console.WriteLine("The year of the movies release: ");
            string favoriteYear = Console.ReadLine();

            Movie favMovie = new Movie(favoriteTitle, favoriteRating, favoriteYear);

            string favMovieLine = $"{favMovie.title};{favMovie.rating};{favMovie.year}";
            movieList.Add(favMovieLine);
            File.WriteAllLines(Path.Combine(filePath, fileName), movieList);
        }
    }
}
