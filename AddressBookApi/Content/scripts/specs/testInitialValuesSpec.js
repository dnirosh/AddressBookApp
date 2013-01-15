describe("AddressBook test suite", function () {
    var timerCallback;

    beforeEach(function () {
        timerCallback = jasmine.createSpy('timerCallback');
        jasmine.Clock.useMock();
    });

    it(" ItChecksInitialNameAndAddress ", function () {
        setTimeout(function () {
            timerCallback();
        }, 1);

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(5);

        var NameValue = $('#Name1').val();
        var AddressValue = $('#Address1').val();

        expect(NameValue).toBe('Dileepa');
        expect(AddressValue).toBe('Earth');
    });

    it(" ItAddsNewContactToList ", function () {
        setTimeout(function () {
            timerCallback();
        }, 1);

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(1);

        $('#Nameundefined').val('Freelancer');
        $('#Addressundefined').val('NoBugsLand');

        $('btnAdd').click(ko_view_model.addAddressBookEntry);
        //$('#addressBookForm').submit(ko_view_model.addAddressBookEntry);

        //to do: check the db for added contact
        expect('Dileepa').toBe('Dileepa');
    });


});