using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.ReportQueryDelegates
{
    internal class AddDirectorDataDelegate : DataReaderDelegate<Director>
    {
        private readonly string firstName;
        private readonly string middleName;
        private readonly string lastName;

        public AddDirectorDataDelegate(string firstName, string middleName, string lastName)
           : base("Movies.AddDirector")
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;
            
            var p = command.Parameters.Add("MiddleName", SqlDbType.NVarChar);
            p.Value = middleName;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("DirectorID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Director Translate(SqlCommand command, IDataRowReader reader)
        {
            return new Director((int)command.Parameters["DirectorID"].Value, firstName, middleName, lastName);
        }
    }
}