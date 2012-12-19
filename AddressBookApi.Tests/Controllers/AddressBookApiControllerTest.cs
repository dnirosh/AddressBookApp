using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookApi.Controllers;
using AddressBookApi.Models;
using System.Collections.Generic;

namespace AddressBookApi.Tests
{
    [TestClass]
    public class AddressBookApiControllerTest
    {
        [TestMethod]
        public void Get()
        {
            AddressBookApiController testController = new AddressBookApiController();
            IEnumerable<AddressBookEntry> AddressBookResult = testController.GetAddressBook();

            // Assert
            Assert.IsNotNull(AddressBookResult);
            int itemCount = 0;

            foreach (var AddressBook in AddressBookResult)
            {
                itemCount++;
                Assert.IsTrue(AddressBook.Id == 1);
                Assert.IsTrue(AddressBook.Name == "Dileepa");
                Assert.IsTrue(AddressBook.Address == "Earth");
            }

            Assert.IsTrue(itemCount == 1);

        }
    }
}
