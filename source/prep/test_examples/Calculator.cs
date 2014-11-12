using System;
using System.Data;
using System.Security;
using System.Threading;

namespace prep.test_examples
{
  public interface ICanPowerDown
  {
    void shut_off();
  }

  public interface ICalculate
  {
    int add(int first, int second);
  }

  public class Calculator : ICalculate, ICanPowerDown
  {
    IDbConnection connection;
    int offset;

    public Calculator(IDbConnection connection, int offset, int offset2)
    {
      this.connection = connection;
      this.offset = offset;
    }

    public int add(int first, int second)
    {
      ensure_positive_arguments(first, second);

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return first + second + offset;
    }

    static void ensure_positive_arguments(int first, int second)
    {
      if (first < 0 || second < 0)
        throw new ArgumentException();
    }

    public void shut_off()
    {
      if (Thread.CurrentPrincipal.IsInRole("blah")) return;

      throw new SecurityException("You cannot do this");
    }
  }
}