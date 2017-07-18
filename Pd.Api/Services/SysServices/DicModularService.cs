using IServices.ISysServices;
using Models.Activity;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SysServices
{
    public class DicModularService : RepositoryBase<DicModular>, IDicModularService
    {
        public DicModularService(IDatabaseFactory databaseFactory, IUserInfo userInfo) : base(databaseFactory, userInfo)
        {
        }
    }
}
