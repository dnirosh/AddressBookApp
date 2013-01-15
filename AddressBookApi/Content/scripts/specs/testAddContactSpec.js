describe("AddressBook Add Entry test suite", function () {
    var timerCallback;

    beforeEach(function () {
        timerCallback = jasmine.createSpy('timerCallback');
        jasmine.Clock.useMock();
    });

    it(" ItAddsNewContactToList ", function () {
        setTimeout(function () {
            timerCallback();
        }, 5);

        //$('#Nameundefined').val('Freelancer');
        //$('#Addressundefined').val('NoBugsPlanet');

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(5);
        //$('#btnAdd').click(ko_view_model.addAddressBookEntry);
        //$('#addressBookForm').submit(ko_view_model.addAddressBookEntry);
        //ko_view_model.addAddressBookEntry();
        ko_view_model.testAdd(ko_view_model);

        //to do: check the db for added contact
        expect(ko_view_model.AddressBookEntriesArray()[1].Name).toBe('Freelancer');
        expect(ko_view_model.AddressBookEntriesArray()[1].Address).toBe('NoBugsPlanet');
    });


});