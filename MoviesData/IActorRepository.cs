using System;
using System.Collections.Generic;
using MoviesData.Models;

namespace MoviesData
{
    public interface IActorRepository
    {
        Director AddDirector(string firstName, string middleName, string lastName);

        Actor AddActor(string firstName, string middleName, string lastName);

        double ActorTotalSalary(string firstName, string lastName);

        IReadOnlyList<(Actor, Actor, Movie)> ActorInCommon(string firstName, string lastName);

        IReadOnlyList<Actor> DisplayActorInfo();
    }
}
