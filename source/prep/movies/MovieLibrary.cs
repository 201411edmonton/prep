using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.movies
{
    public class MovieLibrary
    {
        private IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;
            movies.Add(movie);
        }

        private bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        private List<Movie> movies_published_by(ProductionStudio studio)
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio == studio)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return movies_published_by(ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            var set = movies_published_by(ProductionStudio.Pixar);
            set.AddRange(movies_published_by(ProductionStudio.Disney));
            return set;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            var matches = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    matches.Add(movie);
            }
            return matches;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}