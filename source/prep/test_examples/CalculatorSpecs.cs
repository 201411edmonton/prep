using System;
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
      
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Because b = () =>
          result = sut.add(2, 3);

        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;

      }

      public class a_negative_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It cannot_do_the_addition = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}