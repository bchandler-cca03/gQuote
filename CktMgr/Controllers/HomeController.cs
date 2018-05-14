using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CktMgr.Models;
using Microsoft.AspNetCore.Authorization;
using CktMgr.CircuitLib;

namespace CktMgr.Controllers
{
    public class HomeController : Controller
    {
        // private CircuitRepo _circuitRepo = new CircuitRepo();

        public IActionResult Index()
        {
            // add code to populate Full address into 1-field
            // var totalAddrStr = Circuit.GetFullAddress();

            return View();
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "gQuote provides Off-Net Search and Pricing for Company G";

            Circuit newCircuit = new Circuit()
            {
                Id = 0,
                // Address = "101 7th Avenue SE",
                Address = " 7th Avenue SE",
                City = "New York",
                State = "NY",
                Zip = "10101",
                DeliveryMethod = "Fiber",
                Speed = "100",
                Term = "12",
                MRR = "$1000",
                NRR = "$500"
            };

            //_circuitRepo.AddCircuit(newCircuit);
            return View(newCircuit);
        }
        [Authorize]  // Authorize means you have a login
        public IActionResult Contact()
        {
            ViewData["Message"] = "Billy 'The Eliminator' Gibbons";

            return View();
        }
        public IActionResult WhatIsHFC()
        {
            ViewData["Message"] = "Billy 'The Eliminator' Gibbons";

            return View();
        }
        public IActionResult WhatIsAchieved()
        {
            ViewData["Message"] = "Billy 'The Eliminator' Gibbons";

            return View();
        }
        public IActionResult WhatIsEoC()
        {
            ViewData["Message"] = "Billy 'The Eliminator' Gibbons";

            return View();
        }
        public IActionResult WhereIsEoC()
        {
            ViewData["Message"] = "Billy 'The Eliminator' Gibbons";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
