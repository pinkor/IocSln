using Ioc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Data
{
    /// <summary>
    /// 泛型仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity  //类型参数和接口名称之间没有任何符号，where关键字和类型参数之间，有一个空格。
    {
        /// <summary>
        /// 泛型方法，通过id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// 泛型方法--添加实体
        /// </summary>
        /// <param name="model"></param>
        void Insert(T model);

        /// <summary>
        /// 泛型方法，更新实体
        /// </summary>
        /// <param name="model"></param>
        void Update(T model);

        /// <summary>
        /// 泛型方法--删除实体
        /// </summary>
        /// <param name="model"></param>
        void Delete(T model);

        /// <summary>
        /// 只读Table
        /// </summary>
        IQueryable<T> Table { get; }
    }
}
