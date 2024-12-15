
using Domain.Context;
using InventoryManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : BaseModel, new()
    {
        protected InventoryManagDbContext Context;
        public Repository(InventoryManagDbContext context)
        {
            Context = context;
        }

        public virtual IEntity Get(long Id)
        {
            IEntity result = Context.Set<IEntity>().AsNoTracking().Where(entity => entity.Id == Id).FirstOrDefault();
            return result;
        }

        public virtual IQueryable<IEntity> GetAll()
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
            return dbQuery.AsNoTracking();
        }


        public IQueryable<IEntity> Find(Expression<Func<IEntity, bool>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.AsNoTracking().Include<IEntity, object>(navigationProperty);
            }

            return dbQuery.Where(predicate);
        }

        public IEntity SingleOrDefault(Expression<Func<IEntity, bool>> predicate)
        {
            IQueryable<IEntity> dbQuery = Context.Set<IEntity>();

            return dbQuery.AsNoTracking().SingleOrDefault(predicate);
        }

        public IEntity Add(IEntity entity)
        {
            if (entity.CreationUser == default(string))
            {
                entity.CreationUser = "System";
            }
            entity.CreationDate =  DateTime.Now.ToString();
            Context.Set<IEntity>().Add(entity);

            SaveChanges();
            Context.Entry(entity).GetDatabaseValues();
            return entity;
        }

        public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities)
        {
            foreach (IEntity entity in entities)
            {
                //if (entity is ICloudEntity)
                //    (entity as ICloudEntity).CompanyId = User.CRG_COM_ID;

                //if (UtilitiesDAL.DatabaseType == "OracleDB")
                //{
                //    if (entity is IId)
                //        (entity as IId).Id = GetSequance(entity.TableName);
                //}

                entity.CreationDate =  DateTime.Now.ToString();
                //entity.CreatedBy = User.USERNAME;
            }

            Context.Set<IEntity>().AddRange(entities);
            SaveChanges();
            return entities;

        }
        public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities, Expression<Action<IEnumerable<IEntity>>> postAction)
        {
            postAction.Compile().Invoke(entities);

            foreach (IEntity entity in entities)
            {
                entity.CreationDate =  DateTime.Now.ToString();
                entity.Id = Context.Set<IEntity>().Count() > 0 ? Context.Set<IEntity>().Max(z => z.Id) + 1 : 1;
                IEntity result = Context.Set<IEntity>().Add(entity).Entity;
                SaveChanges();

            }

            return entities;
        }
        public IEntity Remove(IEntity entity)
        {
            Context.Set<IEntity>().Remove(entity);
            SaveChanges();
            return entity;
        }


        public IEntity RemoveByid(IEntity entity)
        {
            Context.Set<IEntity>().Remove(entity);
            SaveChanges();
            return entity;
        }

        public IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities)
        {
            Context.Set<IEntity>().RemoveRange(entities);
            SaveChanges();
            return entities;
        }

        public IEntity Update(IEntity entity)
        {
            // entity.ModificationDate =  DateTime.Now.ToString();
            Context.Set<IEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }
        public IEntity Update(IEntity entity, bool disableAttach = false)
        {
            if (disableAttach)
            {
                Context.Set<IEntity>().Attach(entity);
            }

            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }

        public IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> entities)
        {
            foreach (IEntity entity in entities)
            {
                entity.ModificationDate =  DateTime.Now.ToString();
                
            }
            //Context.Entry(entities).State = EntityState.Deleted;
            Context.Set<IEntity>().UpdateRange(entities);
            SaveChanges();
            return entities;
        }

        public int GetSequance(string tableName)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
