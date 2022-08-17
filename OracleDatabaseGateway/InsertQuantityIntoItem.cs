using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseGateway
{
    class InsertQuantityIntoItem : OracleDatabaseUpdater<ItemDTO>
    {
        protected override string SQLStatement()
        {
            return
                "UPDATE STOCK " +
                "SET ITEM_QUANTITY = :quantity " +
                "WHERE ITEM_ID = :Id";
        }

        protected override int ExecuteUpdate(OracleCommand command, ItemDTO itemToUpdate)
        {
            int numRowsAffected = 0;

            if (itemToUpdate != null)
            {
                try
                {
                    command.Prepare();
                    command.Parameters.Add(":quantity", itemToUpdate.Quantity);
                    command.Parameters.Add(":Id", itemToUpdate.ID);
                    numRowsAffected = command.ExecuteNonQuery();

                    if (numRowsAffected != 1)
                    {
                        throw new Exception("ERROR: Item not updated");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            return numRowsAffected;
        }
    }
}
