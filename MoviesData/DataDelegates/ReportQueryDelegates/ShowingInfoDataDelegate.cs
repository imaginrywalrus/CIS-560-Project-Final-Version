using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class ShowingInfoDataDelegate : DataReaderDelegate<IReadOnlyList<(Cinema, string, double, double)>>
    {

        public ShowingInfoDataDelegate()
           : base("Movies.ShowingInfo")
        {
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<(Cinema, string, double, double)> Translate(SqlCommand command, IDataRowReader reader)
        {
            var showingInfo = new List<(Cinema, string, double, double)>();
            while (reader.Read())
            {
                Cinema addCinema = new Cinema(
                   reader.GetInt32("CinemaID"),
                   reader.GetString("State"),
                   reader.GetString("City"),
                   reader.GetString("Address")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                string movieName = reader.GetString("MovieName");
                double sales = reader.GetDouble("Sales");
                double runningSales = reader.GetDouble("RunningSales");
                showingInfo.Add((addCinema, movieName, sales,runningSales));
            }
            return showingInfo;
        }
    }
}