using Ioc.Data;
using Ioc.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Service
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<UserProfile> userProfileRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userProfileRepository"></param>
        public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetUsers()
        {
            return this.userRepository.Table;
            //throw new NotImplementedException();//接口方法的默认实现，是抛异常
        }

        /// <summary>
        /// 通过Id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(long id)
        {
            return userRepository.GetById(id);
            //throw new NotImplementedException();
        }

        public void InsertUser(User model)
        {
            userRepository.Insert(model);
            //throw new NotImplementedException();
        }

        public void UpdateUser(User model)
        {
            userRepository.Update(model);
            //throw new NotImplementedException();
        }

        public void DeleteUser(User model)
        {
            userRepository.Delete(model);//删除用户
            userProfileRepository.Delete(model.UserProfile);//删除用户详情
                                                            //throw new NotImplementedException();
        }
    }
}
