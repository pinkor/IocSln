using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Entities.User
{
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { set; get; }

        /// <summary>
        /// 导航属性--UserProfile
        /// </summary>
        public virtual UserProfile UserProfile { set; get; }
    }
}
