using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace NETCoreTutorial.Models
{
    public class WorldUser:IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}