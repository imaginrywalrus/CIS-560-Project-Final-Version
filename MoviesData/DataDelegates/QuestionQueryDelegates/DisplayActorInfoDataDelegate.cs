using DataAccess;
using MoviesData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesData.DataDelegates.QuestionQueryDelegates
{
    internal class DisplayActorInfoDataDelegate : DataReaderDelegate<IReadOnlyList<Actor>>
    {
        public DisplayActorInfoDataDelegate()
            : base("Movies.DisplayActorInfo")
        {

        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);
        }

        public override IReadOnlyList<Actor> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.HasRows())
            {
                return null;
            }

            var actor = new List<Actor>();

            while (reader.Read())
            {
                Actor addActor = new Actor(
                   reader.GetInt32("ActorID"),
                   reader.GetString("FirstName"),
                   reader.GetString("MiddleName"),
                   reader.GetString("LastName")
                   /*
                   reader.GetString("IsRemoved"),
                   reader.GetString("CreatedOn"),
                   reader.GetString("UpdatedOn")
                   */
                   );
                actor.Add(addActor);
            }

            return actor;
        }
    }
}
