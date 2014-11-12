using System;
using System.Data;

namespace prep.test_examples
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      ensure_positive_arguments(first, second);

      connection.Open();
      return first + second;
    }

    static void ensure_positive_arguments(int first, int second)
    {
      if (first < 0 || second < 0)
        throw new ArgumentException();
    }
  }
}