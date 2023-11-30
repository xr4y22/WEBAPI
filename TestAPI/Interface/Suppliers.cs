using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestAPI.Models;
using TestAPI.Models.Request;
using TestAPI.Models.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAPI.Interface
{
    public class Suppliers : ISupplier
    {
        public ResponseModels<MSupplier> GetSupplier(PagingRequest paging)
        {
            using (var context = new SanataContext())
            {
                ResponseModels<MSupplier> resp = new Models.Response.ResponseModels<MSupplier>(paging);
               // resp.pageSize = paging.pageSize;
               // resp.pageIndex = paging.pageIndex;
                var list = context.MSuppliers.Take(resp.pageSize).Skip(resp.pageIndex).ToList();
                resp.totalCount = list.Count;
                resp.data = list;
                return  resp;
            }
        }

        public  MSupplier  GetSupplierById(int id)
        {
            using (var context = new SanataContext())
            {
                return  context.MSuppliers.Where(x=>x.Id == id).FirstOrDefault();
            }
        }

        public DataItem AddSupplier(SupplierRequest supplier)
        {
            using (var context = new SanataContext())
            {
                var item = supplier.getItem();
                context.MSuppliers.Add(item);
                context.SaveChanges();
                DataItem data = new DataItem();
                data.id = item.Id;
                return data;
            }
        }

        public string UpdateSupplier(MSupplier supplier)
        {
            using (var context = new SanataContext())
            {
                var item = context.MSuppliers.Where(x => x.Id == supplier.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Name = supplier.Name;
                    context.MSuppliers.Update(item);
                    context.SaveChanges();

                }
                return "";
            }
        }

        public string DeleteSupplier(int id)
        {
            using (var context = new SanataContext())
            {
               
                var item = context.MSuppliers.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    context.Database.ExecuteSqlRaw("delete from mSupplierItem where IdSupplier=" + id);
                    context.MSuppliers.Remove(item);
                    context.SaveChanges();

                }
                return "";
            }
        }

        public ResponseModels<DataItem> GetItemSupplier(int id)
        {
            using (var context = new SanataContext())
            {
                ResponseModels<DataItem> resp = new Models.Response.ResponseModels<DataItem>();
                var list = context.MSupplierItems.Where(x => x.IdSupplier == id).Take(resp.pageSize).Skip(resp.pageIndex).Select(c => new DataItem
                {

                    id = c.IdItem,
                    name = c.IdItemNavigation.Name,
                    price = c.Price

                }).ToList();

                resp.totalCount = list.Count();
                resp.data = list;
                return resp;
            }
        }
        public DataItem AddSupplierItem(SupplierItemRequest item,int id)
        {
            DataItem data = new DataItem();
            try
            {
                using (var context = new SanataContext())
                {
                    context.Database.ExecuteSqlRaw("insert into mSupplierItem values('" + id + "','" +  item.iditem + "'," +  item.price  +  ")");
                    data.id = item.iditem;
                 
                    return data;
                }
            }
            catch(Exception ex)
            {
                return data;
            }
           
        }

        public string UpdateSupplierItem(SupplierItemRequest item,int id)
        {
            DataItem data = new DataItem();
            try
            {
                using (var context = new SanataContext())
                {
                    context.Database.ExecuteSqlRaw("update mSupplierItem set Price=" + item.price + " where IdSupplier='" + id + "' and IdItem ='" + item.iditem + "'");
                   // data.id = item.IdItem;

                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }
 
    }
}
