using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreTutorial.Models
{
    public class WorldRepository :IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting All trips from DB");
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .Where(x => x.Name == tripName)
                .FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            //The reason this is wrapped in parenthesis is that every SaveChanges action
           // returns the number of affected columns, if it is smaller or equal to 0
           // changes were not saved
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
