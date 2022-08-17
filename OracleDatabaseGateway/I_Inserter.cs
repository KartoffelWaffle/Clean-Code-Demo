using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    interface I_Inserter<T>
    {
        public bool Insert(T ItemToInsert);
    }
}
