using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCoreTutorial.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();

        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop, string userName);
        Task<bool> SaveChangesAsync();

        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string name);
    }
}