using System;
using System.Collections.Generic;
using MoviesData.DataDelegates.QuestionQueryDelegates;
using MoviesData.DataDelegates.ReportQueryDelegates;
using MoviesData.Models;
using DataAccess;

namespace MoviesData
{
    public class SqlActorRepository : IActorRepository
    {
        private readonly SqlCommandExecutor executor;
        public SqlActorRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Actor AddActor(string firstName, string middleName, string lastName)
        {
            var d = new AddActorDataDelegate(firstName, middleName, lastName);
            return executor.ExecuteReader(d);
        }

        public Actor AddDirector(string firstName, string middleName, string lastName)
        {
            var d = new AddActorDataDelegate(firstName, middleName, lastName);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Actor> DisplayActorInfo()
        {
            var d = new DisplayActorInfoDataDelegate();
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<(Actor, Actor, Movie)> ActorInCommon(string firstName, string lastName)
        {
            var d = new ActorInCommonDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

        public double ActorTotalSalary(string firstName, string lastName)
        {
            var d = new ActorTotalSalaryDataDelegate(firstName, lastName);
            return executor.ExecuteReader(d);
        }

    }
}
