using System;
using prep.utility;

namespace prep.movies
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public bool Equals(Movie other)
    {
      if (other == null) return false;

      return ReferenceEquals(this, other)  || this.title.Equals(other.title);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return this.title.GetHashCode();
    }

    public static Condition<Movie> published_by(ProductionStudio studio)
    {
      return x => x.production_studio == studio;
    }

    public static Condition<Movie> in_genre(Genre genre)
    {
      return x => x.genre == genre;
    }

    public static Condition<Movie> published_by_pixar_or_disney()
    {
      throw new NotImplementedException();
    }
  }
}