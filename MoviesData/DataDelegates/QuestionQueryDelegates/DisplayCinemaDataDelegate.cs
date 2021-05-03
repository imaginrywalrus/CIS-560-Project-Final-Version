using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class DisplayCinemaDataDelegate : DataReaderDelegate<IReadOnlyList<Cinema>>
    {

        public DisplayCinemaDataDelegate()
            : base("Movies.DisplayCinemaInfo")
        {

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<Cinema> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.HasRows())
            {
                return null;
            }

            var cinema = new List<Cinema>();

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
                cinema.Add(addCinema);
            }

            return cinema;
        }
    }
}
