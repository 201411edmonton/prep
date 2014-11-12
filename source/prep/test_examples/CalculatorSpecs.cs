using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace prep.test_examples
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      //Arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      protected static IDbConnection connection;
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        //Act
        Because b = () =>
          result = sut.add(2, 3);

        //Assert
        It returns_the_sum = () =>
          result.ShouldEqual(5);

        It opens_a_connection_to_the_database = () =>
          connection.received(x => x.Open());

        static int result;
      }

      public class a_negative_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It does_not_use_the_connection = () =>
          connection.never_received(x => x.Open());
          
        It cannot_do_the_addition = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}