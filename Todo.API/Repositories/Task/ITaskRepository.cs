using Todo.API.Models;

namespace Todo.API.Repositories.Task
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetById(int id);
        Task<bool> Insert(Item item, int userid);
        Task<bool> Update(Item item);
        Task<bool> Delete(int id);
    }
}
