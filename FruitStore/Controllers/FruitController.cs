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

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FruitCreateViewModel fruitCreate)
        {
            _fruitRepo.CreateFruit(fruitCreate);
            return RedirectToAction("Index");
        }
        //Edit
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var fruits = _fruitRepo.GetFruitById(Id);
            return View(fruits);
        }
        [HttpPost]
        public IActionResult Edit(FruitEditViewModel fruitEdit)
        {
            _fruitRepo.EditFruit(fruitEdit);
            return RedirectToAction("Index");
        }
        //Details
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var fruits = _fruitRepo.GetFruitById(Id);
            return View(fruits);
        }
        //Delete
        [HttpGet]
        public IActionResult DeleteFruit(int Id)
        {
            var fruits = _fruitRepo.GetFruitById(Id);
            return View(fruits);
        }
        [HttpPost]
        public IActionResult Delete(int FruitId)
        {
            _fruitRepo.DeleteFruitById(FruitId);
            return RedirectToAction("Index");
        }

    }
}
