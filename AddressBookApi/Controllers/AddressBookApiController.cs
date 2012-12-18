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
        List<AddressBook> addressBooks = new List<AddressBook>();
        public AddressBookApiController()
        {
            addressBooks.Add(new AddressBook{ Id = 1, Name = "Dileepa" ,Address = "Earth" });

        }

        // GET api/addressbookapi
        public IEnumerable<AddressBook> GetAddressBook()
        {
            return addressBooks;
        }

        // GET api/addressbookapi/5
        public AddressBook GetAddressBook(int id)
        {
            var address = addressBooks.FirstOrDefault(a => a.Id == id);
            return address;
        }

        // POST api/addressbookapi
        public void PostAddressBook([FromBody]string value)
        {

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
