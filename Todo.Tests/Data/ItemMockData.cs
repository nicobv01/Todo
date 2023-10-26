using System.Threading.Tasks;
using Todo.API.Models;

namespace Todo.Tests.Data
{
    public class ItemMockData
    {
        public static Item getItem()
        {
            var item = new Item
            {
                Id = 1,
                Title = "Test Item",
                IsDone = false,
                UserId = 1
            };

            return item;
        }

        public static List<Item> getItems()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Title = "Test item",
                    IsDone = false,
                    UserId = 1
                },
                new Item
                {
                    Id = 2,
                    Title = "Test item 2",
                    IsDone = false,
                    UserId = 1
                }
            };

            return items;
        }
    }
}
