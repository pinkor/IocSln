using Ioc.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Data
{
    /// <summary>
    /// 泛型仓储类，实现泛型仓储接口。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity  //约束在最后面。
    {
        private readonly IocDbContext _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// 
        /// </summary>
        public Repository(IocDbContext context)
        {
            this._context = context;
        }

        public IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        /// <summary>
        /// 实现泛型接口中的IQueryable<T>类型的 Table属性
        /// 标记为virtual是为了可以重写它
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }

        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
            //throw new NotImplementedException();
        }

        public void Insert(T model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("model");
                }
                else
                {
                    this.Entities.Add(model);
                    this._context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)//DbEntityValidationException从这个类中获取错误信息
            {
                var msg = string.Empty;
                foreach (var errorList in ex.EntityValidationErrors)
                {
                    foreach (var item in errorList.ValidationErrors)
                    {
                        msg += string.Format("Property:{0} Error:{1}", item.PropertyName, item.ErrorMessage) + Environment.NewLine;
                    }
                }
                var fail = new Exception(msg, ex);
                throw fail;
            }

            //throw new NotImplementedException();
        }

        public void Update(T model)
        {
            try
            {
                //model为空，抛空异常
                if (model == null)
                {
                    throw new ArgumentNullException("model");
                }
                else
                {
                    //直接保存了
                    this._context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                var msg = string.Empty;//记录错误信息
                foreach (var errorList in ex.EntityValidationErrors)
                {
                    foreach (var item in errorList.ValidationErrors)
                    {
                        msg += string.Format("Property:{0},Error:{1}", item.PropertyName, item.ErrorMessage) + Environment.NewLine;
                    }

                }
                //创建一个异常实例，把错误信息传递进去
                var fail = new Exception(msg, ex);
                throw fail;
            }
            //throw new NotImplementedException();
        }

        public void Delete(T model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(model);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
                // throw new NotImplementedException();
            }
        }
    }
}
