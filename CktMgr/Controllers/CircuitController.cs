using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CktMgr.CircuitLib;
using CktMgr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CktMgr.Controllers
{
    [Authorize(Policy = "AuthorizedUser")]  // makes the user have the claim Authorized User
    public class CircuitController : Controller
    {
        private ICircuitRepo _cktRepo;

        public int Address { get; private set; }

        public CircuitController(ICircuitRepo cktRepo)
        {
            _cktRepo = cktRepo;
        }

        // GET: Circuit
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_cktRepo.ListAll());
        }

        // GET: Circuit/Details/5
        public ActionResult Details(int id)
        {
            
            return View(_cktRepo.GetById(id));
        }

        // GET:  spash screen for the search
        // how do I make this Circuit/Search
        // [Route("search/inputform")]
        public ActionResult Search()
        {
            return View();
        }

        // POST:  Search terms coming back in

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Route("searchresponse/Address/City/State/Zip")]
        public ActionResult Search(SearchModel modelToSearch, IFormCollection collection)
        {

            try

            {
                List<Circuit> returnResults = new List<Circuit>();
                returnResults = _cktRepo.SearchAddress(modelToSearch);

                return View("SearchReturn", returnResults);
            }
            catch
            {
                return View();  // returns view at not Implemented exception
            }
        }
        public ActionResult SearchAddressPage()
        {
            return View();
        }

        [HttpGet]
        [Route("[controller]/[action]/Address/{Address?}/City/{City}/State/{State}/Zip/{Zip}/page/{PageNumber}")]
        // public ActionResult SearchAddressPageReturn2(SearchViewModel modelToSearch, IFormCollection collection, int PageNumber = 1)
        // public ActionResult SearchAddressPageReturn2(SearchViewModel modelToSearch, String Address, String City, String State, String Zip, IFormCollection collection, int PageNumber = 1)
        public ActionResult SearchAddressPageReturn2(SearchViewModel modelToSearch, String Address, String City, String State, String Zip, int PageNumber = 1)

        {
            SearchModel modelToPass = new SearchModel();
            // modelToPass.Address = Address;
            // modelToPass.City = City;
            // modelToPass.State = State;
            // modelToPass.Zip = Zip;

            modelToPass.Address = (Address == "ASDFJKL") ? "" : Address;
            modelToPass.City = (City == "ASDFJKL") ? "" : City;
            modelToPass.State = (State == "ASDFJKL") ? "" : State;
            modelToPass.Zip = (Zip == "99999") ? "" : Zip;

            modelToSearch.SearchModel = modelToPass;

            try

            {
                List<Circuit> returnResults = new List<Circuit>();

                returnResults = _cktRepo.SearchAddressPageReturn(modelToSearch.SearchModel, PageNumber);

                SearchViewModel viewModel = new SearchViewModel();
                viewModel.Circuits = returnResults;
                viewModel.PageNumber = PageNumber;
                viewModel.SearchModel = modelToSearch.SearchModel;
                // alternative was to add returnResults to modelToSearch

                return View("SearchAddressPageReturn", viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();  // returns view at not Implemented exception
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        [Route("[controller]/[action]/Address/{Address}/City/{City}/State/{State}/Zip/{Zip}/page/{PageNumber}")]
        public ActionResult SearchAddressPageReturn(SearchViewModel modelToSearch, IFormCollection collection, int PageNumber = 1)

        {

            try

            {
                List<Circuit> returnResults = new List<Circuit>();
                
                returnResults = _cktRepo.SearchAddressPageReturn(modelToSearch.SearchModel, PageNumber);

                SearchViewModel viewModel = new SearchViewModel();
                viewModel.Circuits = returnResults;
                viewModel.PageNumber = PageNumber;
                viewModel.SearchModel = modelToSearch.SearchModel;
                // alternative was to add returnResults to modelToSearch

                return View("SearchAddressPageReturn", viewModel);
            }
            catch
            {
                return View();  // returns view at not Implemented exception
            }
        }



        // GET: Circuit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Circuit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Circuit newCkt, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //_cktRepo.Add(newCkt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Circuit/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_cktRepo.GetById(id));
        }

        // POST: Circuit/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(Circuit editCircuit, int id, IFormCollection collection)
        // {
        //    try
        //    {
        //        // TODO: Add update logic here
        //        _cktRepo.Edit(editCircuit);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Circuit/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_cktRepo.GetById(id));
        }

        // POST: Circuit/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        _cktRepo.Delete(id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        // }
    }
}