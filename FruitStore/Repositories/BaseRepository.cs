using FruitStore.Models;

namespace FruitStore.Repositories
{
    public abstract class BaseRepository<TModel>
    {
        public abstract TModel GetById(int id);
    }
}
