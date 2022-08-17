using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class NullUpdater<T> : IUpdater<T>
    {
        public bool Update(T ItemToUpdate)
        {
            throw new Exception("This update operation is not supported");
        }
    }
}
