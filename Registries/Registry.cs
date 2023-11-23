using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal abstract class Registry<Model> where Model : class
    {
        protected ContextDataBase db = ContextDataBase.DB;
        protected DbSet<Model> dbSet = ContextDataBase.DB.Set<Model>();
        public void Add(Model entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }
        public void Update(Model entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
        public void Delete(Model entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }
        public Model Find(int id)
        {
            var entity = dbSet.Find(id);
            if (entity == null)
                throw new Exception($"Ошибка! Значения идентификатора = {id} для таблицы {dbSet.EntityType.ShortName} не существует");
            return entity;
        }
    }
}
