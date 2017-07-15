using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.ISysServices
{
    public interface IUserInfo
    {
        Guid UserId { get; }
        Guid EnterpriseId { get; }
    }
}
