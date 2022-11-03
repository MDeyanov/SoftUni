const { expect } = require('chai');
const testNumbers = require('./testNumbers.js');
describe("testNumbers", function () {
    describe("sumNumbers", function () {
        it("should return undefined if first num type is not number", function () {
            expect(testNumbers.sumNumbers('kon', 1)).to.be.equal(undefined);
        });
        it("should return undefined if second num type is not number", function () {
            expect(testNumbers.sumNumbers(1, "2")).to.be.equal(undefined);
        });
        it("should return the sum of 2 numbers fixed to 2 after decimal", function () {
            let result = 3;
            expect(testNumbers.sumNumbers(1, 2)).to.be.equal(result.toFixed(2));
        });
        
    });
    describe("numberChecker", function () {
        it("should throw if input is NaN", function () {
            expect(() => testNumbers.numberChecker('ewa')).to.throw();
        });
        it("should return this num is even", function () {
            let result = 'The number is even!';
            expect(testNumbers.numberChecker(2)).to.be.equal(result);
        });
        it("should return this num is odd", function () {
            let result = 'The number is odd!';
            expect(testNumbers.numberChecker(1)).to.be.equal(result);
        });
    });
    describe("averageSumArray", function () {
        it("should return avarage array sum", function () {
            let arr = [10,20,30];
            let result =0;
            for (let index = 0; index < arr.length; index++) {
                 result+=arr[index];               
            }
            let sum = result/arr.length;
            expect(testNumbers.averageSumArray(arr)).to.be.equal(sum);
        });
    });

});
