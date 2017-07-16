using IServices.ISysServices;
using Models.Motion;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SysServices
{
    public class RequestCoeffService : RepositoryBase<RequestCoeff>, IRequestCoeffService
    {
        public RequestCoeffService(IDatabaseFactory databaseFactory, IUserInfo userInfo) : base(databaseFactory, userInfo)
        {
        }
    }
}
