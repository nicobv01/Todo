using Todo.API.Models;

namespace Todo.API.Repositories
{
    public interface IItemRepository
    {
        Task<bool> Insert(Item item);
        Task<bool> CompleteTask(int id);
        Task<Item>? GetTask(int item_id);
        Task<IEnumerable<Item>> GetTasks();
    }
}
