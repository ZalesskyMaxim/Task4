using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Repository
{
    public class AbstractRepository : IDisposable
    {
        protected ManagersContext managersContext;
        public AbstractRepository()
        {
            managersContext = new ManagersContext();
        }
        public void Dispose()
        {
            managersContext.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
