using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Entities.User
{
    public class UserProfile : BaseEntity
    {
        /// <summary>
        /// 姓氏
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// 名字
        /// </summary>
        public string LastName { set; get; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 导航属性--User
        /// </summary>
        public virtual User User { set; get; }
    }
}
