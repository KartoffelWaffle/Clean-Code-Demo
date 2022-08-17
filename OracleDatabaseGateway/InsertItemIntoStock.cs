using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace OracleDatabaseGateway
{
    class InsertItemIntoStock : OracleDatabaseInserter<ItemDTO>
    {
        protected override int ExecuteInsertion(OracleCommand Command, ItemDTO ItemToInsert)
        {
            Command.Prepare();
            Command.Parameters.Add(":ID", ItemToInsert.ID);
            Command.Parameters.Add(":name", ItemToInsert.Name);
            Command.Parameters.Add(":price", ItemToInsert.ItemPrice);
            Command.Parameters.Add(":quantity", ItemToInsert.Quantity);
            Command.Parameters.Add(":dateCreated", ItemToInsert.DateCreated);
            int NumRowsAffected = Command.ExecuteNonQuery();

            if (NumRowsAffected != 1)
            {
                throw new Exception("Could not insert item");
            }
            return NumRowsAffected;
        }

        protected override string SQLStatement()
        {
            return "INSERT INTO STOCK (ITEM_ID, ITEM_NAME, ITEM_PRICE, ITEM_QUANTITY, ITEM_DATE_CREATED) VALUES (:ID, :name, :price, :quantity, :dateCreated)";
        }
    }
}
