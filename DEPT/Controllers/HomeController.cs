using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DEPT.Models;
using DEPT.DAL.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using DEPT.ViewModel;

namespace DEPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ICountryRepository _countryRepository;
        protected readonly IConnectionRepository _connectionRepository;



        public HomeController(ILogger<HomeController> logger, ICountryRepository countryRepository, IConnectionRepository connectionRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _connectionRepository = connectionRepository;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Connection = await _connectionRepository.ShakeHands();
           return View();
        }

        public async Task<IActionResult> GetAllCountries()
        {
            List<Country> countries = await _countryRepository.GetAllCountries();

            return View(new CountryViewModel
            {
                Countries = countries
            }
            );
        }

        public async Task<IActionResult> GetCountryByCode(string code)
        {
            Country country = await _countryRepository.GetCountryByCode(code);
            return View(country);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
