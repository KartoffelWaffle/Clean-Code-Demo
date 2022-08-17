using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    interface IUpdater<T>
    {
        public bool Update(T ItemToUpdate);
    }
}
