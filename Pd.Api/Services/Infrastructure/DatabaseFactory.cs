using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private ApplicationDb _dataContext;

        public ApplicationDb Get()
        {
            _dataContext = _dataContext ?? (_dataContext = new ApplicationDb());
            _dataContext.Database.Log = log => Trace.Write(log);

            return _dataContext;
        }
    }
}
