using Ioc.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetUsers();

        /// <summary>
        /// 通过Id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(long id);

        /// <summary>
        /// 新增User
        /// </summary>
        /// <param name="model"></param>
        void InsertUser(User model);

        /// <summary>
        /// 更新User
        /// </summary>
        /// <param name="model"></param>
        void UpdateUser(User model);

        /// <summary>
        /// 删除User
        /// </summary>
        /// <param name="model"></param>
        void DeleteUser(User model);

    }
}
