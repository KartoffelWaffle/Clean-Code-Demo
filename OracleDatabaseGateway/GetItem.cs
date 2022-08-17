using DTO;
using DTO.Builder;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDatabaseGateway
{
    class GetItem : OracleDatabaseRetriever<IDTO>
    {
        private string ItemName;

        public GetItem(string ItemName)
        {
            this.ItemName = ItemName;
        }

        protected override string SQLStatement()
        {
            return "SELECT ITEM_ID, ITEM_NAME, ITEM_QUANTITY, ITEM_DATE_CREATED FROM STOCK WHERE ITEM_NAME = :ItemName";
        }

        protected override IDTO ExecuteRetrieval(OracleCommand Command)
        {
            ItemDTO ItemDTO = null;

            try
            {
                Command.Prepare();
                Command.Parameters.Add(":ItemName", ItemName);
                OracleDataReader DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                {
                    ItemDTO =
                        new ItemDTO_Builder()
                        .WithID(DataReader.GetInt32(0))
                        .WithName(DataReader.GetString(1))
                        .WithQuantity(DataReader.GetInt32(2))
                        .WithDateCreated(DataReader.GetDateTime(3))
                        .WithState(DataReader.GetInt32(2))
                        .Build();
                }

                DataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Item Retreival failed" + e.Message);
            }

            return ItemDTO;
        }
    }
}
