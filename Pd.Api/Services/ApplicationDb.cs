using Models.SysModels;
using Services.SysServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationDb : SysApplicationDb
    {
        //指定连接字符串
        public ApplicationDb()
            : base("DefaultConnection")
        {

            this.Database.Initialize(false);
        }

        public DbSet<SysUser> SysUser { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
