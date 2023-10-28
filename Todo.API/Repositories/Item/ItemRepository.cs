using Todo.API.Models;
using Todo.API.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.API.Repositories;

namespace Todo.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;

        public ItemRepository(AppDbContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<bool> Insert(Item item)
        {
            try
            {
                item.UserId = _userContext.GetCurrentUserId();
                var result = await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
            }catch
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CompleteTask(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            item.IsDone = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
