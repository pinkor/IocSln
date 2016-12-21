using Ioc.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Data.Mapping.User
{
    /// <summary>
    /// UserProfileMap实体映射类 ，需要继承 EntityTypeConfiguration类
    /// </summary>
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // 表名
            ToTable("UserProfiles");

            // 主键
            HasKey(t => t.ID);

            // 属性
            Property(t => t.FirstName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.LastName).HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.Address).HasColumnType("nvarchar");

            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP);

            // 关系 relationship           
            HasRequired(t => t.User).WithRequiredDependent(u => u.UserProfile);
        }
    }
}
