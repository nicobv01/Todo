using System.Threading.Tasks;
using Todo.API.Models;

namespace Todo.Tests.Data;

public class ItemMockData
{
    public static Item GetItem()
    {
        var item = new Item
        {
            Id = 3,
            Title = "Test Item",
            IsDone = "0",
            UserId = 1
        };

        return item;
    }

    public static Item GetItemById(int id)
    {
        var item = GetItems().FirstOrDefault(x => x.Id == id);
        return item;
    }

    public static List<Item> GetItems()
    {
        var items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Title = "Test item",
                IsDone = "0",
                UserId = 1
            },
            new Item
            {
                Id = 2,
                Title = "Test item 2",
                IsDone = "0",
                UserId = 1
            }
        };

        return items;
    }
}
