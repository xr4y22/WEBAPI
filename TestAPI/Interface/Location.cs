using TestAPI.Models.Response;
using TestAPI.Models;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models.Request;

namespace TestAPI.Interface
{
    public class Location : ILocation
    {
        public ResponseModels<MLocation> GetLocation(PagingRequest paging)
        {
            using (var context = new SanataContext())
            {
                ResponseModels<MLocation> resp = new Models.Response.ResponseModels<MLocation>(paging);
                var list = context.MLocations.Take(resp.pageSize).Skip(resp.pageIndex).ToList();
                resp.totalCount = list.Count;
                resp.data = list;
                return resp;
            }
        }

        public MLocation GetLocationById(int id)
        {
            using (var context = new SanataContext())
            {
                return context.MLocations.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public DataItem AddLocation(LocationRequest location)
        {
            using (var context = new SanataContext())
            {
                var item = location.getItem();
                context.MLocations.Add(item);
                context.SaveChanges();
                DataItem loc = new DataItem();
                loc.id = item.Id;
                return loc;
            }
        }

        public string UpdateLocation(MLocation location)
        {
            using (var context = new SanataContext())
            {
                var item = context.MLocations.Where(x => x.Id == location.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Name = location.Name;
                    context.MLocations.Update(item);
                    context.SaveChanges();

                }
                return "";
            }
        }

        public string DeleteLocation(int id)
        {
            using (var context = new SanataContext())
            {

                var item = context.MLocations.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    context.Database.ExecuteSqlRaw("delete from mItemLocation where IdLocation=" + id);
                    context.MLocations.Remove(item);
                    context.SaveChanges();

                }
                return "";
            }
        }

        public DataItem AddItemLocation(int id, ItemLocationRequest item)
        {
            DataItem data = new DataItem();
            try
            {
                using (var context = new SanataContext())
                {
                    context.Database.ExecuteSqlRaw("insert into mItemLocation values('" + item.iditem + "','" + id + "'," + item.stock + ")");
                    data.id = item.iditem;

                    return data;
                }
            }
            catch (Exception ex)
            {
                return data;
            }

        }

        public string UpdateItemLocation(int id, ItemLocationRequest item)
        {
            DataItem data = new DataItem();
            try
            {
                using (var context = new SanataContext())
                {
                    context.Database.ExecuteSqlRaw("update mItemLocation set  Stock=" + item.stock + " where IdItem='" + id + "' and IdLocation ='" + id + "'");
                    // data.id = item.IdItem;

                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public ResponseModels<DataItem> GetItemLocation(int id)
        {
            using (var context = new SanataContext())
            {
                ResponseModels<DataItem> resp = new Models.Response.ResponseModels<DataItem>();
                var list = context.MItemLocations.Where(x => x.IdItem == id).Take(resp.pageSize).Skip(resp.pageIndex).Select(c => new DataItem
                {

                    id = c.IdItem,
                    name = c.IdLocationNavigation.Name,
                    stock = c.Stock

                }).ToList();

                resp.totalCount = list.Count();
                resp.data = list;
                return resp;
            }
        }
    }
}
