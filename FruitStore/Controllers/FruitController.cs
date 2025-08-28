using FruitStore.Context;
using FruitStore.Models;
using FruitStore.Models.ViewModel;
using FruitStore.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Controllers
{
    public class FruitController : Controller
    {
        private readonly IFruitRepository _fruitRepo;

        private readonly MainDBContext database;
        public FruitController(MainDBContext _database, IFruitRepository fruitRepo) 
        {
            database = _database;
            _fruitRepo = fruitRepo;
        }
        //List of fruits
        [HttpGet]
        public IActionResult Index()
        {
            var fruits = _fruitRepo.GetAllFruits();
            return View(fruits);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Create
        [HttpPost]
        public IActionResult Create(FruitCreateViewModel fruit)
        {
            _fruitRepo.CreateFruit(fruit);
            return RedirectToAction("Index");
        }
        //Update
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var fruit = _fruitRepo.GetFruitById(Id);
            return View(fruit);
        }
        [HttpPost]
        public IActionResult Edit(FruitEditViewModel fruitEditViewModel)
        {
            _fruitRepo.UpdateFruit(fruitEditViewModel);
            return RedirectToAction("Index");
        }
        //Details
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var fruit = _fruitRepo.GetFruitById(Id);
            return View(fruit);
        }
        //Delete
        [HttpGet]
        public IActionResult DeleteFruit(int Id)
        {
            var fruit = _fruitRepo.GetFruitById(Id);
            return View(fruit);
        }
        [HttpPost]
        public IActionResult Delete(int FruitId)
        {
            _fruitRepo.DeleteFruitById(FruitId);
            return RedirectToAction("Index");
        }

    }
}
