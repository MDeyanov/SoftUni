const { expect } = require("chai");
const exp = require("constants");
const library = require('./library.js');

describe("Tests library", function () {

    describe("calcPriceOfBook tests", function () {

        it("should throw error if book name is not string", function () {
            expect(() => library.calcPriceOfBook(323, 1233)).to.throw();
        });

        it("should throw error when book year is string", function () {
            expect(() => library.calcPriceOfBook('witcher', "1233")).to.throw();
        });

        it("should give discound if year is <= 1980", function () {
            let bookName = 'witcher';
            let year = 1980;
            let total = 20 - (20 * 0.5);

            expect(library.calcPriceOfBook(bookName, year)).to.equal(`Price of ${bookName} is ${total.toFixed(2)}`);
        });

        it("should give price and name of the book", function () {
            let bookName = 'witcher';
            let year = 2000;
            let total = 20;
            expect(library.calcPriceOfBook(bookName, year)).to.equal(`Price of ${bookName} is ${total.toFixed(2)}`);
        });

    });

    describe("findBook tests", function () {

        it("should throw error if array is empty", function () {
            let arr = [];
            expect(() => library.findBook(arr)).to.throw();
        });

        it("should return that find the book", function () {
            let bookArr = ['witcher', 'game of thrones'];
            expect(library.findBook(bookArr, 'witcher')).to.be.equal("We found the book you want.");
        });

        it("should return that didnt find the book", function () {
            let bookArr = ['witcher', 'game of thrones'];
            expect(library.findBook(bookArr, 'train')).to.be.equal("The book you are looking for is not here!");
        });

    });

    describe("arrangeTheBooks tests", function () {

        it("should throw error when count is less then 0", function () {
            expect(() => library.arrangeTheBooks(-1)).to.throw();
        });

        it("should throw error when not intiger", function () {
            expect(() => library.arrangeTheBooks("20")).to.throw();
        });

        it("should return great job when space is more or equal to count book", function () {
            expect(library.arrangeTheBooks(5)).to.be.equal("Great job, the books are arranged.");
        });

        it("should return great job when space is more or equal to count book", function () {
            expect(library.arrangeTheBooks(40)).to.be.equal("Great job, the books are arranged.");
        });

        it("should return that space is not enought", function () {
            expect(library.arrangeTheBooks(500)).to.be.equal("Insufficient space, more shelves need to be purchased.");
        });

    });

});
