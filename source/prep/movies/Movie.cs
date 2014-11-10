using System;

namespace prep.movies
{
  public class Movie
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }
    protected bool Equals(Movie other)
    {
        return title.Equals(other.title);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Movie)obj);
    }
  }
}