using CRM_InternetServicesShop.BL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_InternetServicesShop.BL.Controller
{
    public class EntityController<T>
        where T: class
    {
        private readonly DbSet<T> table;
        private readonly ShopDbContext db;
        public EntityController(ShopDbContext dbContext)
        {
            table = dbContext.Set<T>();
            db = dbContext;
            table.Load();
        }

        public IEnumerable<T> GetData() => table.Local.ToBindingList();

        public T Find(object id) => table.Find(id);

        public void Update() => db.SaveChanges();

        public void AddRecord(T entity)
        {
            table.Add(entity);
            db.SaveChanges();
        }
        public void RemoveRecord(T entity)
        {
            table.Remove(entity);
            db.SaveChanges();
        }
    }
}
