using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Models.Request;
using TestAPI.Models.Response;

namespace TestAPI.Interface
{
    public interface ISupplier
    {
        ResponseModels<MSupplier> GetSupplier(PagingRequest paging);
        MSupplier GetSupplierById(int id);

        DataItem AddSupplier(SupplierRequest supplier);
        string UpdateSupplier(MSupplier supplier);

        string DeleteSupplier(int id);

        ResponseModels<DataItem> GetItemSupplier(int id);


        //ResponseModels<MLocation> GetLocation();
        //MLocation GetLocationById(int id);

        //DataItem AddLocation(MLocation location);
        //string UpdateLocation(MLocation location);

        //string DeleteLocation(int id);

        //ResponseModels<MItem> GetItem();
        //MItem GetItemById(int id);

        //DataItem AddItem(MItem items);
        //string UpdateItem(MItem items);

        //string DeleteItem(int id);

        DataItem AddSupplierItem(SupplierItemRequest item,int id);
        string UpdateSupplierItem(SupplierItemRequest item, int id);

        //ResponseModels<DataItem> GetItemLocation(int id);
        //DataItem AddItemLocation(int id,ItemLocationRequest item);
        //string UpdateItemLocation(int id, ItemLocationRequest item);


    }
}
