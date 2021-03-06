/* The following set of Context/Specification pairs are in place to specify the functionality that you need to complete for the MovieLibrary class.
 * MovieLibrary is an collection of Movie. It exposes the ability to search,sort, and iterate over all of the movies that it contains.
 * The current implementation of MovieLibrary has almost all of its methods throwing a NotImplementedException. Your job is to get all of the Contexts and their
 * accompanying specifications [tests] passing
 * 
 * This exercise will give you an opportunity to get some familiarity with the following contracts:
 * 
 *      -IEnumerable<T> - The Grandfather of all collection interfaces
 *      -IList<T>
 *      -IEquatable<T>
 *      -IComparer<T>
 *      -Comparison<T> delegate type
 *      -Predicate<T> delegate type
 *      -Generics     
 * 
 * The primary goals of this exercise are to get you familiar with a couple of things:
 *      Unit Testing Framework (Machine.Specification)
 *      BDD Style Test Naming Syntax
 *      Fluent Assertions - You will find most of these are extension methods that start with the name Should[NAME]
 *      Refactoring
 *      Core collection interfaces and types
 *      Encapsulation
 *      
 * The main purpose of the exercise is to give you practical exposure to some fundamental design principles that will
 * become more important as the week progresses
 * 
 *      Single Responsiblity Principle
 *      Open Closed Principle
 *      Tell Don't Ask 
 *      Code to contracts not implementations
 *      Favour Composition over inheritance
 *      
 *
 * The tests are complete. You will just need to get the implementation working. 
 * 
 * 
 * ************** RESTRICTIONS **************************************************************************************
 * No linq allowed - this is to force some interesting design problems to the surface
 * You can only change the code in the following classes:
 *          - Movie
 *          - MovieLibrary
 *          
 * If you have any questions please do not hesitate to email me at jp@developwithpassion.com
 * Or give me a call at (503)213-3507
 * 
 * Develop With Passion®!!
 */

using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using prep.matching;
using prep.sorting;
using prep.test_utilities;

namespace prep.movies
{
  [Subject(typeof(MovieLibrary))]
  public class MovieLibrarySpecs
  {
    public abstract class movie_library_concern : Observes<MovieLibrary>
    {
      protected static IList<Movie> movie_collection;

      Establish c = () =>
      {
        movie_collection = new List<Movie>();
        depends.on(movie_collection);
      };
    };

    public class when_counting_the_number_of_movies : movie_library_concern
    {
      static int number_of_movies;

      Establish c = () =>
        movie_collection.add_all(new Movie(), new Movie());

      Because b = () =>
        number_of_movies = sut.all_movies().Count();

      It should_return_the_number_of_all_movies_in_the_library = () =>
        number_of_movies.ShouldEqual(2);
    }

    public class when_asked_for_all_of_the_movies : movie_library_concern
    {
      static Movie first_movie;
      static Movie second_movie;
      static IEnumerable<Movie> all_movies;

      Establish c = () =>
      {
        first_movie = new Movie();
        second_movie = new Movie();

        movie_collection.add_all(first_movie, second_movie);
      };

      Because b = () =>
        all_movies = sut.all_movies();

      It should_receive_a_set_containing_each_movie_in_the_library = () =>
        all_movies.ShouldContainOnly(first_movie, second_movie);
    }

    public class when_trying_to_change_the_set_of_movies_returned_by_the_movie_library_to_a_mutable_type :
      movie_library_concern
    {
      static Movie first_movie;
      static Movie second_movie;

      Establish c = () =>
      {
        first_movie = new Movie();
        second_movie = new Movie();
        movie_collection.add_all(first_movie, second_movie);
      };

      Because b = () =>
        spec.catch_exception(() => sut.all_movies().downcast_to<IList<Movie>>());

      It should_get_an_invalid_cast_exception = () =>
        spec.exception_thrown.ShouldBeAn<InvalidCastException>();
    }

    public class when_iterating : movie_library_concern
    {
      Establish c = () =>
      {
        Enumerable.Range(1, 100).each(x => movie_collection.Add(new Movie()));
      };

      Because b = () =>
        result = sut.all_movies();

      It should_iterate = () =>
      {
      };

      static IEnumerable<Movie> result;
    }

    public class when_adding_a_movie_to_the_library : movie_library_concern
    {
      static Movie movie;

      Establish c = () => movie = new Movie();

      Because b = () =>
        sut.add(movie);

      It should_store_it_in_the_movie_collection = () =>
      {
        movie_collection.Contains(movie).ShouldBeTrue();
        movie_collection.Count.ShouldEqual(1);
      };
    }

    public class when_adding_an_existing_movie_in_the_collection_again : movie_library_concern
    {
      static Movie movie;

      Establish c = () =>
      {
        movie = new Movie();
        movie_collection.Add(movie);
      };

      Because b = () =>
        sut.add(movie);

      It should_not_restore_the_movie_in_the_collection = () =>
        movie_collection.Count.ShouldEqual(1);
    }

    public class when_adding_two_different_copies_of_the_same_movie : movie_library_concern
    {
      static Movie another_copy_of_speed_racer;
      static Movie speed_racer;

      Establish c = () =>
      {
        speed_racer = new Movie {title = "Speed Racer"};
        another_copy_of_speed_racer = new Movie {title = "Speed Racer"};
        movie_collection.Add(speed_racer);
      };

      Because b = () =>
        sut.add(another_copy_of_speed_racer);

      It should_store_only_1_copy_in_the_collection = () =>
        movie_collection.Count.ShouldEqual(1);
    }

    public class when_searching_for_movies : concern_for_searching_and_sorting
    {
      /* Look at the potential method explosion that can start to occur as you start to search on different criteria
             * see if you can apply OCP (Open closed principle) to ensure that you can accomodate all means of searching for
             * movies using different criteria. Feel free to change/remove explicit methods if you find a way to encompass searching
             * without the need for using explicit methods. For this exercise, no linq queries are allowed!!.*/

      It should_be_able_to_find_all_movies_published_by_pixar = () =>
      {
        var results = sut.all_movies().@where(x => x.production_studio).equal_to(ProductionStudio.Pixar);

        results.ShouldContainOnly(cars, a_bugs_life);
      };

      It should_be_able_to_find_all_movies_published_by_pixar_or_disney = () =>
      {
        var criteria = Match<Movie>.with_attribute(x => x.production_studio)
          .equal_to(ProductionStudio.Pixar, ProductionStudio.Disney);

        var results = sut.all_movies().all_items_matching(criteria);

        results.ShouldContainOnly(a_bugs_life, pirates_of_the_carribean, cars);
      };

      It should_be_able_to_find_all_movies_not_published_by_pixar = () =>
      {
        var results = sut.all_movies().where(x => x.production_studio).not.equal_to(ProductionStudio.Pixar);

        results.ShouldNotContain(cars, a_bugs_life);
      };

      It should_be_able_to_find_all_movies_published_after_a_certain_year = () =>
      {
        var criteria = Match<Movie>.with_attribute(x => x.date_published).greater_than(2004);

        var results = sut.all_movies().all_items_matching(criteria);

        results.ShouldContainOnly(yours_mine_and_ours, shrek, theres_something_about_mary);
      };

      It should_be_able_to_find_all_movies_published_between_a_certain_range_of_years = () =>
      {
        var criteria = Match<Movie>.with_attribute(x => x.date_published.Year).between(1982, 2003);

        var results = sut.all_movies().all_items_matching(criteria);

        results.ShouldContainOnly(indiana_jones_and_the_temple_of_doom, a_bugs_life, pirates_of_the_carribean);
      };

      It should_be_able_to_find_all_kid_movies = () =>
      {
        var criteria = Match<Movie>.with_attribute(x => x.genre).equal_to(Genre.kids);

        var results = sut.all_movies().all_items_matching(criteria);

        results.ShouldContainOnly(a_bugs_life, shrek, cars);
      };

      It should_be_able_to_find_all_action_movies = () =>
      {
        var criteria = Match<Movie>.with_attribute(x => x.genre).equal_to(Genre.action);

        var results = sut.all_movies().all_items_matching(criteria);

        results.ShouldContainOnly(indiana_jones_and_the_temple_of_doom, pirates_of_the_carribean);
      };
    }

    public class when_sorting_movies : concern_for_searching_and_sorting
    {
      /* Look at the potential method explosion that can start to occur as you start to sort on different criteria
             * see if you can apply OCP (Open closed principle) to ensure that you can accomodate all means of sorting for
             * movies using different criteria. Feel free to change/remove explicit methods if you find a way to encompass sorting
             * without the need for using explicit methods. For this exercise, no linq queries are allowed!!. */

      It should_be_able_to_sort_all_movies_by_title_descending = () =>
      {
        var comparer = Compare<Movie>.by(x => x.title,SortDirection.descending);

        var results = sut.all_movies().sort_using(comparer);

        results.ShouldContainOnlyInOrder(yours_mine_and_ours, theres_something_about_mary, shrek,
          pirates_of_the_carribean, indiana_jones_and_the_temple_of_doom,
          cars, a_bugs_life);
      };

      It should_be_able_to_sort_all_movies_by_title_ascending = () =>
      {
        var comparer = Compare<Movie>.by(x => x.title);

        var results = sut.all_movies().sort_using(comparer);

        results.ShouldContainOnlyInOrder(a_bugs_life, cars, indiana_jones_and_the_temple_of_doom,
          pirates_of_the_carribean, shrek,
          theres_something_about_mary, yours_mine_and_ours);
      };

      It should_be_able_to_sort_all_movies_by_date_published_descending = () =>
      {
        var date_comparer = Compare<DateTime>.by(x => x.Year)
          .then_by(x => x.Month);

        var comparer = Compare<Movie>.by(x => x.date_published,SortDirection.descending);

        var results = sut.all_movies().sort_using(comparer);

        results.ShouldContainOnlyInOrder(theres_something_about_mary, shrek, yours_mine_and_ours, cars,
          pirates_of_the_carribean, a_bugs_life,
          indiana_jones_and_the_temple_of_doom);
      };

      It should_be_able_to_sort_all_movies_by_date_published_ascending = () =>
      {
        var comparer = Compare<Movie>.by(x => x.date_published);

        var results = sut.all_movies().sort_using(comparer);

        results.ShouldContainOnlyInOrder(indiana_jones_and_the_temple_of_doom, a_bugs_life,
          pirates_of_the_carribean, cars, yours_mine_and_ours, shrek,
          theres_something_about_mary);
      };

      It should_be_able_to_sort_all_movies_by_studio_rating_and_year_published = () =>
      {
        //Studio Ratings (highest to lowest)
        //MGM
        //Pixar
        //Dreamworks
        //Universal
        //Disney
        var comparer = Compare<Movie>.by(x => x.production_studio,
          ProductionStudio.MGM,
          ProductionStudio.Pixar,
          ProductionStudio.Dreamworks,
          ProductionStudio.Universal,
          ProductionStudio.Disney)
          .then_by(x => x.date_published);

        var results = sut.all_movies().sort_using(comparer);
        /* should return a set of results 
                 * in the collection sorted by the rating of the production studio (not the movie rating) and year published. for this exercise you need to take the studio ratings
                 * into effect, which means that you first have to sort by movie studio (taking the ranking into account) and then by the
                 * year published. For this test you cannot add any extra properties/fields to either the ProductionStudio or
                 * Movie classes.*/

        results.ShouldContainOnlyInOrder(yours_mine_and_ours, theres_something_about_mary, a_bugs_life, cars, shrek,
          indiana_jones_and_the_temple_of_doom,
          pirates_of_the_carribean);
      };
    }

    public class concern_for_searching_and_sorting : movie_library_concern
    {
      protected static Movie a_bugs_life;
      protected static Movie cars;
      protected static Movie indiana_jones_and_the_temple_of_doom;
      protected static Movie pirates_of_the_carribean;
      protected static Movie shrek;
      protected static Movie yours_mine_and_ours;
      protected static Movie theres_something_about_mary;

      Establish c = () =>
        populate_movie_list(movie_collection);

      static void populate_movie_list(IList<Movie> movie_list)
      {
        indiana_jones_and_the_temple_of_doom = new Movie
        {
          title = "Indiana Jones And The Temple Of Doom",
          date_published = new DateTime(1982, 1, 1),
          genre = Genre.action,
          production_studio = ProductionStudio.Universal,
          rating = 10
        };

        cars = new Movie
        {
          title = "Cars",
          date_published = new DateTime(2004, 1, 1),
          genre = Genre.kids,
          production_studio = ProductionStudio.Pixar,
          rating = 10
        };

        yours_mine_and_ours = new Movie
        {
          title = "Yours Mine And Ours",
          date_published = new DateTime(2005, 1, 1),
          genre = Genre.comedy,
          production_studio = ProductionStudio.MGM,
          rating = 7
        };

        shrek = new Movie
        {
          title = "Shrek",
          date_published = new DateTime(2006, 5, 10),
          genre = Genre.kids,
          production_studio = ProductionStudio.Dreamworks,
          rating = 10
        };

        a_bugs_life = new Movie
        {
          title = "A Bugs Life",
          date_published = new DateTime(2000, 6, 20),
          genre = Genre.kids,
          production_studio = ProductionStudio.Pixar,
          rating = 10
        };

        theres_something_about_mary = new Movie
        {
          title = "There's Something About Mary",
          date_published = new DateTime(2007, 1, 1),
          genre = Genre.comedy,
          production_studio = ProductionStudio.MGM,
          rating = 5
        };

        pirates_of_the_carribean = new Movie
        {
          title = "Pirates of the Carribean",
          date_published = new DateTime(2003, 1, 1),
          genre = Genre.action,
          production_studio = ProductionStudio.Disney,
          rating = 10
        };

        movie_list.Add(cars);
        movie_list.Add(indiana_jones_and_the_temple_of_doom);
        movie_list.Add(pirates_of_the_carribean);
        movie_list.Add(a_bugs_life);
        movie_list.Add(shrek);
        movie_list.Add(yours_mine_and_ours);
        movie_list.Add(theres_something_about_mary);
      }
    }
  }
}