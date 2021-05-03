using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class ActorTotalSalaryDataDelegate : DataReaderDelegate<double>
    {
        private readonly string firstName;
        private readonly string lastName;

        public ActorTotalSalaryDataDelegate(string firstName, string lastName)
           : base("Movies.ActorTotalSalary")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("firstName", SqlDbType.NVarChar);
            var p2 = command.Parameters.Add("lastName", SqlDbType.NVarChar);
            p1.Value = firstName;
            p2.Value = lastName;
        }

        public override double Translate(SqlCommand command, IDataRowReader reader)
        {
            double salary = 0;
            if (!reader.HasRows())
            {
                return -1;
            }

            while (reader.Read())
            {
                salary =  reader.GetDouble("TotalSalary");
            }
            return salary;
        }
    }
}