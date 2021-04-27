using System;
using System.Collections.Generic;
using MoviesData.Models;

namespace MoviesData
{
    public interface IActorRepository
    {
        float ActorTotalSalary(string firstName, string lastName);
        IReadOnlyList<(Actor, Actor, Movie)> ActorInCommon(string firstName, string lastName);
    }
}
