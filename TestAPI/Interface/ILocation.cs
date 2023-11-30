using TestAPI.Models.Response;
using TestAPI.Models;
using TestAPI.Models.Request;

namespace TestAPI.Interface
{
    public interface ILocation
    {
        ResponseModels<MLocation> GetLocation(PagingRequest paging);
        MLocation GetLocationById(int id);

        DataItem AddLocation(LocationRequest location);
        string UpdateLocation(MLocation location);

        string DeleteLocation(int id);


        ResponseModels<DataItem> GetItemLocation(int id);
        DataItem AddItemLocation(int id, ItemLocationRequest item);
        string UpdateItemLocation(int id, ItemLocationRequest item);
    }
}
