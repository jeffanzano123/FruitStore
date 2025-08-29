using FruitStore.Context;
using FruitStore.Models;
using FruitStore.Models.ViewModel;
using FruitStore.Repositories.Interface;
using NuGet.Protocol.Plugins;

namespace FruitStore.Repositories.Implementation
{
    public class FruitRepository : BaseRepository<Fruit>, IFruitRepository
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
        //Create
        public void CreateFruit(FruitCreateViewModel fruit)
        {
            Fruit NewFruit = new Fruit();
            NewFruit.Name = fruit.Name;
            NewFruit.Price = fruit.Price;
            database.Fruits.Add(NewFruit);
            database.SaveChanges();
        }
        //Edit
        public void EditFruit(FruitEditViewModel editfruit)
        {
            var fruit = GetById(editfruit.FruitId);
            if (fruit != null)
            {
                fruit.Name = editfruit.Name;
                fruit.Price = editfruit.Price;
                database.Entry(fruit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                database.SaveChanges();
            }
        }
        //Details
        public virtual Fruit GetFruitById(int id)
        {
            var fruit = GetById(id);
            return fruit;
        }
        //Delete
        public Fruit DeleteFruitById(int fruitId)
        {
            var fruit = GetById(fruitId);
            if (fruit != null)
            {
                database.Fruits.Remove(fruit);
                database.SaveChanges();
            }
            return fruit;
        }

        public override Fruit GetById(int id)
        {
            var fruit = database.Fruits.FirstOrDefault(f => f.FruitId == id);
            return fruit;
        }
    }
}
