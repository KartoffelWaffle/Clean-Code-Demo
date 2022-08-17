using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class NullRetriever<T> : IRetriever<T>
    { 

        public T Retrieve()
        {
            throw new Exception("This retriever operation is not supported");
        }
    }

}
