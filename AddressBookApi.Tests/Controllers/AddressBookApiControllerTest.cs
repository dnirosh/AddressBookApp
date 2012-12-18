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
            IEnumerable<AddressBook> AddressBookResult = testController.GetAddressBook();

            // Assert
            Assert.IsNotNull(AddressBookResult);
            int itemCount = 0;

            foreach (var addressBookEntry in AddressBookResult)
            {
                itemCount++;
                Assert.IsTrue(addressBookEntry.Id == 1);
                Assert.IsTrue(addressBookEntry.Name == "Dileepa");
                Assert.IsTrue(addressBookEntry.Address == "Earth");
            }

            Assert.IsTrue(itemCount == 1);

        }
    }
}
