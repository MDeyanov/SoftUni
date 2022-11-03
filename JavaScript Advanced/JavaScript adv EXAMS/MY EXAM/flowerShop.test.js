const { expect } = require('chai');
let flowerShop = require('./flowerShop.js');

describe("flowerShop", function () {
    describe("calcPriceOfFlowers", function () {

        it("1 not string error ", function () {
            expect(() => flowerShop.calcPriceOfFlowers(12, 10, 10)).to.throw();
        });
        it("2 not number error ", function () {
            expect(() => flowerShop.calcPriceOfFlowers("flower", "ewaww", 10)).to.throw();
        });
        it("3 not number error", function () {
            expect(() => flowerShop.calcPriceOfFlowers("flower", 10, "ewa")).to.throw();
        });

        it("result price * quantity", function () {
            let result = 25;
            let flower = 'Rose';
            let result1 = `You need $${result.toFixed(2)} to buy ${flower}!`;
            expect(flowerShop.calcPriceOfFlowers('Rose', 5, 5)).to.be.equal(result1);
        });
    });
    describe("checkFlowersAvailable", function () {

        it("1 avaiable flower", function () {
            let arr = ['Rose'];
            let flower = 'Rose';
            let resultt = `The ${flower} are available!`;
            expect(flowerShop.checkFlowersAvailable(flower, arr)).to.be.equal(resultt);
        });
        it("2 sold flower", function () {
            let arr = ['gose'];
            let flower = 'Rose';
            let resultt = `The ${flower} are sold! You need to purchase more!`;
            expect(flowerShop.checkFlowersAvailable(flower, arr)).to.be.equal(resultt);
        });
        it("3", function () {
            let arr = ['Rose', 'Flower', 'power'];
            let flower = 'Flower';
            let resultt = `The ${flower} are available!`;
            expect(flowerShop.checkFlowersAvailable(flower, arr)).to.be.equal(resultt);
        });
    });
    describe("sellFlowers", function () {

        it("1 space <0", function () {
            let gardenArr = ['rose', 'pose'];
            let space = -1;
            expect(() => flowerShop.sellFlowers(gardenArr, space)).to.throw();

        });
        it("2 space > garden.length", function () {
            let gardenArr = ['rose', 'pose'];
            let space = 5;
            expect(() => flowerShop.sellFlowers(gardenArr, space)).to.throw();
        });
        it("3 space = garden,length", function () {
            let gardenArr = ['rose', 'pose'];
            let space = 2;
            expect(() => flowerShop.sellFlowers(gardenArr, space)).to.throw();
        });
        it("3 garden no array", function () {
            let gardenArr = 'rose';
            let space = 2;
            expect(() => flowerShop.sellFlowers(gardenArr, space)).to.throw();
        });
        it("valid", function () {
            let gardenArr = ['rose', 'pose'];
            let space = 1;
            let shop = [];
            let i = 0;
            while (gardenArr.length > i) {
                if (i != space) {
                    shop.push(gardenArr[i]);
                }
                i++
            }
            let result = shop.join(' / ');
            expect(flowerShop.sellFlowers(gardenArr,space)).to.be.equal(result);

        });
    });

});
