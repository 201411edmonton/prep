using System;
using System.Data;

namespace prep.test_examples
{
    public class Calculator
    {
        private IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_positive_arguments(first, second);
            connection.Open();
            var command = connection.CreateCommand();
            command.ExecuteNonQuery();
            return first + second;
        }

        private static void ensure_positive_arguments(int first, int second)
        {
            if (first < 0 || second < 0)
                throw new ArgumentException();
        }
    }
}