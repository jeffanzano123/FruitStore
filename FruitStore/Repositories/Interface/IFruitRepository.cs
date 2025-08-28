using FruitStore.Models;
using FruitStore.Models.ViewModel;

namespace FruitStore.Repositories.Interface
{
    public interface IFruitRepository
    {
        IEnumerable<Models.Fruit> GetAllFruits();
        void CreateFruit(FruitCreateViewModel fruit);
        void UpdateFruit(FruitEditViewModel editfruit);
        Fruit GetFruitById(int id);
        Fruit DeleteFruitById(int fruitId);
    }
}
