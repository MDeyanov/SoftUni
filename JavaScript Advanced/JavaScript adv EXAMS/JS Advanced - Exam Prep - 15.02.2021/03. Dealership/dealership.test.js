const { expect } = require('chai');
const dealership = require('./dealership.js');
describe("dealership", function () {
    describe("newCarCost", function () {

        it("Should return discount price for a4 b8", function () {
            let expectedResult = 5000;
            expect(dealership.newCarCost('Audi A4 B8', 20000)).to.be.equal(expectedResult);
        });
        it("Should return discount price for a6 4k", function () {
            let expectedResult = 5000;
            expect(dealership.newCarCost('Audi A6 4K', 25000)).to.be.equal(expectedResult);
        });
        it("Should return discount price for a8 d5", function () {
            let expectedResult = 5000;
            expect(dealership.newCarCost('Audi A8 D5', 30000)).to.be.equal(expectedResult);
        });
        it("Should return discount price for tt 8j", function () {
            let expectedResult = 5000;
            expect(dealership.newCarCost('Audi TT 8J', 19000)).to.be.equal(expectedResult);
        });

        it("Should return newCarPrice", function () {
            let expectedResult = 200000;
            expect(dealership.newCarCost('Audi Rs 6', 200000)).to.be.equal(expectedResult);
        });
    });

    describe("carEquipment", function () {

        it("Should return the array", function () {
            let extrasArray = ['sedalki', 'elStakla', 'sportenVolan'];
            let indexArray = [1, 2];
            expect(dealership.carEquipment(extrasArray, indexArray)).to.be.eql(['elStakla', 'sportenVolan']);
            let extrasArray1 = ['sedalki', 'elStakla', 'sportenVolan'];
            let indexArray1 = [0, 1, 2];
            expect(dealership.carEquipment(extrasArray1, indexArray1)).to.be.eql(['sedalki', 'elStakla', 'sportenVolan']);
        });
    });

    describe("euroCategory", function () {

        it("Should with 5% discount", function () {
            let total = 14250;
            let result = `We have added 5% discount to the final price: ${total}.`;
            expect(dealership.euroCategory(4)).to.be.equal(result);
        });
        it("Should with 5% discount 1", function () {
            let total = 14250;
            let result = `We have added 5% discount to the final price: ${total}.`;
            expect(dealership.euroCategory(10)).to.be.equal(result);
        });

        it("Should without 5% discount", function () {
            let result = 'Your euro category is low, so there is no discount from the final price!';
            expect(dealership.euroCategory(2)).to.be.equal(result);
        });
    });
});
