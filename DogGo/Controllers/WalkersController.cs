﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly WalkerRepository _walkerRepo;
        private readonly OwnerRepository _ownerRepo;
        private readonly DogRepository _dogRepo;
        private readonly WalkRepository _walkRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkersController(IConfiguration config)
        {
            _walkerRepo = new WalkerRepository(config);
            _ownerRepo = new OwnerRepository(config);
            _dogRepo = new DogRepository(config);
            _walkRepo = new WalkRepository(config);
        }

        // GET: Walkers
        public ActionResult Index()
        {

            bool truthyValue = (User != null) && User.Identity.IsAuthenticated;

            if (truthyValue)
            {
                int ownerId = GetCurrentUserId();
                Owner owner = _ownerRepo.GetOwnerById(ownerId);

                List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);

                return View(walkers);
            }
            else
            {
                List<Walker> walkers = _walkerRepo.GetAllWalkers();

                return View(walkers);
            }
        }

        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            WalkerViewModel vm = new WalkerViewModel();

            vm.Walker = _walkerRepo.GetWalkerById(id);

            if (vm.Walker == null)
            {
                return NotFound();
            }

            vm.Walks = _walkRepo.GetAllWalkersWalks(vm.Walker.Id);

            foreach(Walk walk in vm.Walks)
            {
                walk.Dog.Owner = _ownerRepo.GetOwnerById(walk.Dog.OwnerId);
            }

            vm.TotalWalkTime = vm.Walks.Sum(item => item.Duration);

            return View(vm);
        }

        // GET: Walkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Walkers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Walkers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Walkers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Walkers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Walkers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}