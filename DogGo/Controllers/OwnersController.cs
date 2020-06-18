using System;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private readonly OwnerRepository _ownerRepo;
        private readonly DogRepository _dogRepo;
        private readonly WalkerRepository _walkerRepo;
        private readonly NeighborhoodRepository _neighborhoodRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public OwnersController(IConfiguration config)
        {
            _ownerRepo = new OwnerRepository(config);
            _dogRepo = new DogRepository(config);
            _walkerRepo = new WalkerRepository(config);
            _neighborhoodRepo = new NeighborhoodRepository(config);
        }

        // GET: Owners
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();

            return View(owners);
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            ProfileViewModel vm = new ProfileViewModel();

            vm.Owner = _ownerRepo.GetOwnerById(id);

            if (vm.Owner == null)
            {
                return NotFound();
            }

            vm.Dogs = _dogRepo.GetAllDogsByOwner(id);

            vm.Walkers = _walkerRepo.GetWalkersInNeighborhood(vm.Owner.NeighborhoodId);

            return View(vm);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            neighborhoods.Sort((x, y) => string.Compare(x.Name, y.Name));

            OwnerFormViewModel vm = new OwnerFormViewModel()
            {
                Owner = new Owner(),
                Neighborhoods = neighborhoods
            };

            return View(vm);
        }

        // POST: Owners/CreateS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int id)
        {
            OwnerFormViewModel vm = new OwnerFormViewModel();

            vm.Owner = _ownerRepo.GetOwnerById(id);

            if (vm.Owner == null)
            {
                return NotFound();
            }

            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            neighborhoods.Sort((x, y) => string.Compare(x.Name, y.Name));

            vm.Neighborhoods = neighborhoods;

            return View(vm);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }
    }
}
