using TestAPI.Models.Response;
using TestAPI.Models;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models.Request;

namespace TestAPI.Interface
{
    public class Item : IItem
    {
        public ResponseModels<MItem> GetItem(PagingRequest paging)
        {
            using (var context = new SanataContext())
            {
                ResponseModels<MItem> resp = new Models.Response.ResponseModels<MItem>(paging);
                var list = context.MItems.Take(resp.pageSize).Skip(resp.pageIndex).ToList();
                resp.totalCount = list.Count;
                resp.data = list;
                return resp;
            }
        }

        public MItem GetItemById(int id)
        {
            using (var context = new SanataContext())
            {
                return context.MItems.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public DataItem AddItem(ItemRequest items)
        {
            using (var context = new SanataContext())
            {
                var item = items.getItem();
                context.MItems.Add(item);
                context.SaveChanges();
                DataItem data = new DataItem();
                data.id = item.Id;
                return data;
            }
        }

        public string UpdateItem(MItem items)
        {
            using (var context = new SanataContext())
            {
                var item = context.MItems.Where(x => x.Id == items.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Name = items.Name;
                    item.SellingPrice = items.SellingPrice;
                    context.MItems.Update(item);
                    context.SaveChanges();

                }
                return "";
            }
        }

        public string DeleteItem(int id)
        {
            using (var context = new SanataContext())
            {

                var item = context.MItems.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    context.Database.ExecuteSqlRaw("delete from mSupplierItem where IdItem=" + id);
                    context.Database.ExecuteSqlRaw("delete from mItemLocation where IdItem=" + id);
                    context.MItems.Remove(item);
                    context.SaveChanges();

                }
                return "";
            }
        }
    }
}
