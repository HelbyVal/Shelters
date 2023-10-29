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
        DbSet<Model> dbSet;
        public void Add(Model entity)
        {
            using (var db = new ContextDataBase())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }
        public void Update(Model entity)
        {
            using (var db = new ContextDataBase())
            {
                db.Update(entity);
                db.SaveChanges();
            }
        }
        public void Delete(Model entity)
        {
            using (var db = new ContextDataBase())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }
        public Model Find(int id)
        {
            using (var db = new ContextDataBase())
            {
                var entity = dbSet.Find(id);
                if (entity == null)
                    throw new Exception($"Ошибка! Значения идентификатора {id} для таблицы {dbSet.EntityType.ShortName} не существует");
                return entity;
            }
        }
    }
}
