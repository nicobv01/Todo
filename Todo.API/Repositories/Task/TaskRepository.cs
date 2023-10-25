using Todo.API.Models;

namespace Todo.API.Repositories.Task
{
    public class TaskRepository : ITaskRepository
    {
        Task<bool> ITaskRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> ITaskRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Item> ITaskRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITaskRepository.Insert(Item item)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITaskRepository.Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
