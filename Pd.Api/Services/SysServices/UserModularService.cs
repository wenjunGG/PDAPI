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
    public class UserModularService : RepositoryBase<SysUserModular>, IUserModularService
    {
        public UserModularService(IDatabaseFactory databaseFactory, IUserInfo userInfo) : base(databaseFactory, userInfo)
        {
        }
    }
}
