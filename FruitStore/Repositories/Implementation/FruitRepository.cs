using FruitStore.Context;
using FruitStore.Models;
using FruitStore.Models.ViewModel;
using FruitStore.Repositories.Interface;
using NuGet.Protocol.Plugins;

namespace FruitStore.Repositories.Implementation
{
    public class FruitRepository : IFruitRepository
    {
        private readonly MainDBContext database;
        public FruitRepository(MainDBContext mainDBContext)
        {
            database = mainDBContext;
        }
        public IEnumerable<Fruit> GetAllFruits()
        {
            var fruits = database.Fruits.ToList();
            return fruits;
        }
        public void CreateFruit(FruitCreateViewModel fruit)
        {
            Fruit NewFruit = new Fruit();
            NewFruit.Name = fruit.Name;
            NewFruit.Price = fruit.Price;
            database.Fruits.Add(NewFruit);
            database.SaveChanges();
        }
        public void UpdateFruit(FruitEditViewModel editfruit)
        {
            var fruit = database.Fruits.FirstOrDefault(f => f.FruitId == editfruit.FruitId);
            if (fruit != null)
            {
                fruit.Name = editfruit.Name;
                fruit.Price = editfruit.Price;
                database.Entry(fruit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                database.SaveChanges();
            }
        }
        public Fruit GetFruitById(int id)
        {
            var fruit = database.Fruits.FirstOrDefault(f => f.FruitId == id);
            return fruit;
        }
        public Fruit DeleteFruitById(int fruitId)
        {
            var fruit = database.Fruits.FirstOrDefault(f => f.FruitId == fruitId);
            if (fruit != null)
            {
                database.Fruits.Remove(fruit);
                database.SaveChanges();
            }
            return fruit;
        }
    }
}
