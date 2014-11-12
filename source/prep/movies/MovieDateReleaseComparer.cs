using System.Collections.Generic;

namespace prep.movies
{
  public class MovieDateReleaseComparer : IComparer<Movie>
  {
    public int Compare(Movie x, Movie y)
    {
      // >0 == x > y
      // <0 == x < y
      // =0 == x = y
      return x.date_published.CompareTo(y.date_published);
    }
  }
}