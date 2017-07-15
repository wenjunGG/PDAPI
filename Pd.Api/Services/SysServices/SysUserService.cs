using IServices.ISysServices;
using Models.SysModels;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SysServices
{
    public class SysUserService : RepositoryBase<SysUser>, ISysUserService
    {

        public SysUserService(IDatabaseFactory databaseFactory, IUserInfo userInfo) : base(databaseFactory, userInfo)
        {
        }

    }
}
