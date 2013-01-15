describe("Initial Values test suite", function () {
    var timerCallback;

    beforeEach(function () {
        timerCallback = jasmine.createSpy('timerCallback');
        jasmine.Clock.useMock();
    });

    it(" ItChecksInitialNameAndAddressInUI ", function () {
        setTimeout(function () {
            timerCallback();
        }, 5);

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(5);

        var NameValue = $('#Name1').val();
        var AddressValue = $('#Address1').val();

        expect(NameValue).toBe('Dileepa');
        expect(AddressValue).toBe('Earth');
    });

    it(" ItChecksInitialNameAndAddressInKnockoutList ", function () {
        setTimeout(function () {
            timerCallback();
        }, 1);

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(100);

        var NameValue = $('#Name1').val();
        var AddressValue = $('#Address1').val();

        expect(ko_view_model.AddressBookEntriesArray()[0].Name).toBe('Dileepa');
        expect(ko_view_model.AddressBookEntriesArray()[0].Address).toBe('Earth');
    });

    it(" ItAddsNewContactToList ", function () {
        setTimeout(function () {
            timerCallback();
        }, 5);

        //buy time till knockout values are rendered 
        jasmine.Clock.tick(5);

        ko_view_model.testAdd(ko_view_model);

        //test for added values 
        expect(ko_view_model.AddressBookEntriesArray()[1].Name).toBe('Freelancer');
        expect(ko_view_model.AddressBookEntriesArray()[1].Address).toBe('NoBugsPlanet');
    });
});