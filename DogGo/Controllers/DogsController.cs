using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DogGo.Controllers
{
    public class DogsController : Controller
    {
        private readonly DogRepository _dogRepo;
        private readonly OwnerRepository _ownerRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public DogsController(IConfiguration config)
        {
            _dogRepo = new DogRepository(config);
            _ownerRepo = new OwnerRepository(config);
        }

        // GET: Dogs
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetAllDogsByOwner(ownerId);

            return View(dogs);
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            dog.Owner = _ownerRepo.GetOwnerById(dog.OwnerId);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // GET: Dogs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id 
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: Dogs/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            dog.Owner = _ownerRepo.GetOwnerById(dog.OwnerId);

            if (dog == null || dog.OwnerId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                if (dog.OwnerId == GetCurrentUserId())
                {
                    _dogRepo.UpdateDog(dog);

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        // GET: Dogs/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            dog.Owner = _ownerRepo.GetOwnerById(dog.OwnerId);

            if (dog.OwnerId == GetCurrentUserId())
            {

                return View(dog);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Dogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id, Dog dog)
        {
            dog = _dogRepo.GetDogById(id);
            
            try
            {
                if (dog.OwnerId == GetCurrentUserId())
                {
                    _dogRepo.DeleteDog(id);

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}