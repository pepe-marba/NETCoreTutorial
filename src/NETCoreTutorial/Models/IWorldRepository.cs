using System.Collections.Generic;

namespace NETCoreTutorial.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}