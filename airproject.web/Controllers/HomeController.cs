using airproject.domain.Application.Ports.Inbound;
using airproject.domain.Application.Services;
using airproject.domain.Domain;
using airproject.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace airproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<QueryAirConditionForCityCommand> _validator;        
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager<QueryAirConditionForCityCommand, Location> _serviceManager;
        public HomeController(
            IValidator<QueryAirConditionForCityCommand> validator,            
            ILogger<HomeController> logger,
            IServiceManager<QueryAirConditionForCityCommand, Location> serviceManager)
        {
            _validator = validator;            
            _logger = logger;
            _serviceManager = serviceManager;
        }
        public IActionResult Index(string city, string sort)
        {
            try
            {
                var query = new QueryAirConditionForCityCommand(_validator, city, sort);
                var results = _serviceManager.Query(query);
                return View(results);
            }
            catch(ValidationException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                
                foreach(var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Replay(int index = 0)
        {
            try
            {
                var result = _serviceManager.Replay(index);
                return View("Index", result);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}