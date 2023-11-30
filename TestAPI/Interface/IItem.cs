using TestAPI.Models.Response;
using TestAPI.Models;
using TestAPI.Models.Request;

namespace TestAPI.Interface
{
    public interface IItem
    {
        ResponseModels<MItem> GetItem(PagingRequest paging);
        MItem GetItemById(int id);

        DataItem AddItem(ItemRequest items);
        string UpdateItem(MItem items);

        string DeleteItem(int id);
    }
}
