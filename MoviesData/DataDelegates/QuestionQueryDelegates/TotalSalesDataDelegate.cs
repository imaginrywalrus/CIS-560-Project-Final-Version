using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class TotalSalesDataDelegate : DataReaderDelegate<double>
    {
        private readonly string movieName;

        public TotalSalesDataDelegate(string movieName)
           : base("Movies.TotalSales")
        {
            this.movieName = movieName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p1 = command.Parameters.Add("movieName", SqlDbType.NVarChar);
            p1.Value = movieName;
        }

        public override double Translate(SqlCommand command, IDataRowReader reader)
        {
            
            if (!reader.HasRows())
            {
                throw new RecordNotFoundException(movieName.ToString());
            }
            

            return reader.GetDouble("TotalSales");
        }
    }
}