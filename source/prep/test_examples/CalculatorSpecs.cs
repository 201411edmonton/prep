using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

namespace prep.test_examples
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern_for_calculation : Observes<ICalculate, Calculator>
    {
      //Arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      protected static IDbConnection connection;
      protected static IDbCommand command;
    }

    public abstract class concern_for_powering_down : Observes<ICanPowerDown, Calculator>
    {
    }

    public class when_shutting_off_the_calculator : concern_for_powering_down
    {
      public class and_they_are_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          sut.shut_off();

        It allows_them_to_shut_if_off = () =>
        {
        };

        static IPrincipal principal;
      }

      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It does_not_allow_them_to_shut_if_off = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal principal;
      }
    }

    public class when_adding : concern_for_calculation
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

        It runs_a_query = () =>
          command.received(x => x.ExecuteNonQuery());

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

      public class and_an_offset_is_specified
      {
        Establish c = () =>
        {
          depends.on(1);
        };

        Because b = () =>
          result = sut.add(2, 3);

        It applies_the_sum_with_the_offset = () =>
          result.ShouldEqual(6);

        static int result;
      }
    }
  }
}