using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NETCoreTutorial.Models;
using NETCoreTutorial.Services;
using NETCoreTutorial.ViewModels;
using System;
using System.Linq;

namespace NETCoreTutorial.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _respository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IWorldRepository repository, ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _respository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            //try
            //{
            //    var data = _respository.GetAllTrips();
            //    return View(data);
            //}
            //catch (Exception ex)
            //{

            //    _logger.LogError($"Failed to get trips in Index page: {ex.Message}");
            //    return Redirect("/error");
            //}
            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                //First parameter is to define whether the error will be assigned to a field 
                // Or empty if is for all the model
                ModelState.AddModelError("Email", "We Don't support AOL addresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From The World", model.Message);

                ViewBag.UserMessage = " Message sent";
                ModelState.Clear();
            }

            return View();

        }

        public IActionResult About()
        {

            return View();
        }
    }
}
