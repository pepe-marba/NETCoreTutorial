using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCoreTutorial.Models;
using NETCoreTutorial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreTutorial.Controllers.Api
{
    [Route("/api/trips/{tripName}/stops")]
    public class StopsController:Controller
    {
        private ILogger<StopsController> _logger;
        private IWorldRepository _repository;

        public StopsController(IWorldRepository repository, ILogger<StopsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripByName(tripName);

                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get stops: {0}", ex);
            }

            return BadRequest("Failed to get stops");
        }
    }
}
