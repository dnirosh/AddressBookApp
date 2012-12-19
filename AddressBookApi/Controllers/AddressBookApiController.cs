using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBookApi.Models;

namespace AddressBookApi.Controllers
{
    public class AddressBookApiController : ApiController
    {
        List<AddressBookEntry> addressBooks = new List<AddressBookEntry>();
        public AddressBookApiController()
        {
            addressBooks.Add(new AddressBookEntry { Id = 1, Name = "Dileepa", Address = "Earth" });

        }

        // GET api/addressbookapi
        public IEnumerable<AddressBookEntry> GetAddressBook()
        {
            return addressBooks;
        }

        // GET api/addressbookapi/5
        public AddressBookEntry GetAddressBook(int id)
        {
            var address = addressBooks.FirstOrDefault(a => a.Id == id);
            return address;
        }

        // POST api/addressbookapi
        public AddressBookEntry PostAddressBook([FromBody]AddressBookEntry addressBookEntry)
        {
            return addressBookEntry;
        }

        // PUT api/addressbookapi/5
        public void PutAddressBook(int id, [FromBody]string value)
        {

        }

        // DELETE api/addressbookapi/5
        public void DeleteAddressBook(int id)
        {
        }
    }
}
