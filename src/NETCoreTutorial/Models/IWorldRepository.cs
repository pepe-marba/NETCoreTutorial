﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace NETCoreTutorial.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();

        void AddTrip(Trip trip);
        Task<bool> SaveChangesAsync();

        Trip GetTripByName(string tripName);
    }
}