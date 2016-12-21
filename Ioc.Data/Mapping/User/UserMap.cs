using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Data.Mapping.User
{
    /// <summary>
    /// 实体映射类，需要继承 EntityTypeConfiguration类
    /// </summary>
    public class UserMap : EntityTypeConfiguration<Ioc.Entities.User.User>
    {
        public UserMap()
        {
            // 表名
            ToTable("Users");

            // 主键
            HasKey(t => t.ID);

            // 属性
            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.PassWord).IsRequired();

            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP).IsRequired();
        }
    }
}
