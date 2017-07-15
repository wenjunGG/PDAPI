using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SysServices
{
    public abstract class SysApplicationDb : DbContext
    {
        protected SysApplicationDb(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

         

        public virtual int Commit()
        {
            return base.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
