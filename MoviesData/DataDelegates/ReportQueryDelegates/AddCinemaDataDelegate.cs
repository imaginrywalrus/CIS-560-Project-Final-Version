using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddCinemaDataDelegate : DataReaderDelegate<Cinema>
    {
        private readonly string state;
        private readonly string city;
        private readonly string address;

        public AddCinemaDataDelegate(string state, string city, string address)
           : base("Movies.AddCinema")
        {
            this.state = state;
            this.city = city;
            this.address = address;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("State", SqlDbType.NVarChar);
            p.Value = state;

            p = command.Parameters.Add("City", SqlDbType.NVarChar);
            p.Value = city;

            p = command.Parameters.Add("Address", SqlDbType.NVarChar);
            p.Value = address;

            p = command.Parameters.Add("CinemaID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Cinema Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Cinema((int)command.Parameters["CinemaID"].Value, state, city, address);
        }
    }
}