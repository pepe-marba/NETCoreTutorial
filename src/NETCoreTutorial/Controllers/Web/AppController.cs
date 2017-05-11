using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NETCoreTutorial.Services;
using NETCoreTutorial.ViewModels;

namespace NETCoreTutorial.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }

        public IActionResult Index()
        {
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
