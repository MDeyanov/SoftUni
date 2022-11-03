const { expect } = require('chai');
const numberOperations = require('./03. Number Operations_Resources.js');
describe("numberOperations", function() {
    describe("powNumber", function() {
        it("should return num1*num2", function() {
             let result = 25;
             expect(numberOperations.powNumber(5,5)).to.be.equal(result);
        });
     });
     describe("numberChecker", function() {
        it("should throw input is not a number", function() {
            expect(() => numberOperations.numberChecker('tralala')).to.throw();
        });

        it("should return number is lower then 100", function() {
             let result = 'The number is lower than 100!';
             expect(numberOperations.numberChecker(50)).to.be.equal(result);
        });

        it("should return number is equal 100", function() {
            let result = 'The number is greater or equal to 100!';
            expect(numberOperations.numberChecker(100)).to.be.equal(result);
       });

        it("should return number is greater then 100", function() {
            let result = 'The number is greater or equal to 100!';
            expect(numberOperations.numberChecker(500)).to.be.equal(result);
        });
     });
     describe("sumArrays", function() {
        it("should return new array", function() {
            let arr1 = [1,2,3,4,5];
            let arr2 = [1,2,3,4,5];
            let result = [];
            
            for (let index = 0; index < arr1.length; index++) {
                result.push(arr1[index]+arr2[index]);
            }
            expect(numberOperations.sumArrays(arr1,arr2)).to.be.eql([2,4,6,8,10]);
             
        });

        it("should return new array 1", function() {
            let arr1 = [1,2,3,4,5];
            let arr2 = [1,2,3,4,5,6,7,8];
            let result = [];
            
            for (let index = 0; index < arr1.length; index++) {
                result.push(arr1[index]+arr2[index]);
            }
            expect(numberOperations.sumArrays(arr1,arr2)).to.be.eql([2,4,6,8,10,6,7,8]);
             
        });
     });
     
});
