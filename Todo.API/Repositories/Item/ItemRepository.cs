using Todo.API.Models;
using Todo.API.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Todo.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserIdFromToken()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return int.Parse(userId);
        }

        public async Task<bool> Insert(Item item)
        {
            item.UserId = GetUserIdFromToken(); ;

            var result = await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return result != null;
        }
    }
}
