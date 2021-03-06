﻿using prep.matching.core;

namespace prep.movies
{
  public class IsPublishedBy : IMatchA<Movie>
  {
    ProductionStudio studio;

    public IsPublishedBy(ProductionStudio studio)
    {
      this.studio = studio;
    }

    public bool matches(Movie movie)
    {
      return movie.production_studio == studio;
    }
  }
}