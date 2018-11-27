using AnketMerkezi.Business.Services.Base.Abstract;
using AnketMerkezi.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AnketMerkezi.Business.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : AnketMerkezi.Data.ORM.Entities.BaseEntity
    {
        protected DatabaseContext db;
        protected DbSet<TEntity> dbcontext;
        public BaseService()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CE1GVBQ\SQLEXPRESS;Database=AnketMerkeziDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            db = new DatabaseContext(optionsBuilder.Options);
            dbcontext = db.Set<TEntity>();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public virtual List<TEntity> GetAll() => dbcontext.Where(x => x.IsDeleted == false).ToList();

        public virtual List<TEntity> GetAllWithPassives() => dbcontext.Where(x => x.IsDeleted == false).ToList();

        public virtual List<TEntity> GetAllWithQuery(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => x.IsDeleted == false).Where(lambda).ToList();

        public virtual List<TEntity> GetListWithGroupBy(Expression<Func<TEntity, bool>> lambda) => dbcontext.GroupBy(lambda).Select(group => group.Last()).ToList();

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity != null)
            {
                entity.AddDate = DateTime.Now;
                entity.IsDeleted = false;
                dbcontext.Add(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = dbcontext.Find(entity.ID);
                entity.AddDate = _entity.AddDate;
                entity.IsDeleted = _entity.IsDeleted;
                db.Entry(_entity).CurrentValues.SetValues(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual bool Delete(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                entity.IsDeleted = true;
                SaveChanges();
                return true;
            }
            else
                return false;
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => !x.IsDeleted).FirstOrDefault(lambda);

        public virtual TEntity GetbyIdWithQuery(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                return entity;
            }
            else
                return null;
        }

        public virtual bool AnyWithQuery(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => !x.IsDeleted).Any(lambda);

        public virtual int Count(Expression<Func<TEntity, bool>> lambda) => dbcontext.Where(x => x.IsDeleted == false).Count(lambda);

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(db);
        }
    }
}
