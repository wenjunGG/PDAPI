using Models.Activity;
using Models.Motion;
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

        public DbSet<SysUser> SysUser { get; set; } //用户表
        public DbSet<SysUserModular> SysUserModular { get; set; } //用户表

        public DbSet<Back> Back { get; set; } //返回值类型表
        public DbSet<Coefficient> Coefficient { get; set; } //参数表
        public DbSet<DicPorts> DicPorts { get; set; } //参数请求表
        public DbSet<Ports> Ports { get; set; } //接口表 
        public DbSet<RequestCoeff> RequestCoeff { get; set; } //请求参数表
      
        public DbSet<DicModular> DicModular { get; set; } //模块字典表
        public DbSet<Modular> Modular { get; set; } //模块表


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
