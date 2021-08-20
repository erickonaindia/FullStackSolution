using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.MVC.Infrastructure.Interfaces;

namespace Web.MVC.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IRestClientService _restClient;
        private string endpoint = "https://localhost:44303/api/parking";

        public ParkingController(IRestClientService restClient)
        {
            _restClient = restClient;
        }

        // GET: ParkingController
        public async Task<ActionResult> Index()
        {
            var json = await _restClient.GetAsync($"{endpoint}");
            var list = JsonConvert.DeserializeObject<List<ParkingViewModel>>(json);

            return View(list.AsEnumerable());
        }

        // GET: ParkingController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var json = await _restClient.GetAsync($"{endpoint}/{id}");
            var parking = JsonConvert.DeserializeObject<ParkingViewModel>(json);

            return View(parking);
        }

        // GET: ParkingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Parking parking = new Parking()
                    {
                        CreationDate = DateTime.Now,
                        Description = collection["Description"],
                        Name = collection["Name"]
                    };
                    await _restClient.PostAsync($"{endpoint}", parking);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ParkingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var json = await _restClient.GetAsync($"{endpoint}/{id}");
            var parking = JsonConvert.DeserializeObject<ParkingViewModel>(json);

            return View(parking);
        }

        // POST: ParkingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var json = await _restClient.GetAsync($"{endpoint}/{id}");
                    var parkingFound = JsonConvert.DeserializeObject<ParkingViewModel>(json);

                    Parking parking = new Parking()
                    {
                        Id = id,
                        Description = collection["Description"],
                        Name = collection["Name"],
                        CreationDate = parkingFound.CreationDate
                        
                    };

                    await _restClient.PutAsync($"{endpoint}", parking);

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParkingController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var json = await _restClient.GetAsync($"{endpoint}/{id}");
            var parking = JsonConvert.DeserializeObject<ParkingViewModel>(json);

            return View(parking);
        }

        // POST: ParkingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _restClient.DeleteAsync($"{endpoint}/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
