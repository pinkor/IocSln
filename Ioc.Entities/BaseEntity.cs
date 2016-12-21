using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// ID编号
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddedDate { set; get; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public DateTime ModifiedDate { set; get; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { set; get; }
    }
}
