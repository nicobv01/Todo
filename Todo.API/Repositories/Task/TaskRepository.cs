using Todo.API.Models;
using Todo.API.Data;
using System.Security.Claims;

namespace Todo.API.Repositories.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

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

        public async Task<bool> Insert(Item item, int user_id)
        {
            item.UserId = user_id;

            var result = await _context.Tasks.AddAsync(item);
            await _context.SaveChangesAsync();
            return result != null;
        }

        Task<bool> ITaskRepository.Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
