using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using OracleDatabaseGateway;

namespace AssignmentTests
{
    [TestClass]
    class Tests1
    {

        [TestMethod]
        public void TestAddNewItemIntoDatabase()
        {

            ItemDTO item = new ItemDTO(1, "Pen", 20, "Employee1", DateTime.Now, "Item In Stock");
            DatabaseGatewayFacade DBG = new DatabaseGatewayFacade();

            Assert.AreEqual(1, DBG.InsertItemIntoStock(item));

        }

        public void TestAddNewItemQuantityToItemDatabase()
        {

            ItemDTO item = new ItemDTO(1, "", 20, "Employee1", DateTime.Now, "");
            DatabaseGatewayFacade DBG = new DatabaseGatewayFacade();

            Assert.AreEqual(1, DBG.InsertQuantityIntoItem(item));

        }

        public void TestAddTransactionLogIntoDatabase()
        {

            ItemDTO item = new ItemDTO(3, "", 20, "Employee1", DateTime.Now, "");
            DatabaseGatewayFacade DBG = new DatabaseGatewayFacade();

            Assert.AreEqual(1, DBG.GetTransactionLog());

        }
    }
}
