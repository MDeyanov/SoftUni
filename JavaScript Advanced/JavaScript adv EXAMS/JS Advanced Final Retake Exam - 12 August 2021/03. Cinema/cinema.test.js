const { expect } = require('chai');
const cinema = require('./cinema.js');

describe("Cinema tests", function () {
    //start
    describe("showMovies", function () {
        it("should return no movies if array is 0", function () {
            let expectedResult = 'There are currently no movies to show.';
            let arrResult = [];
            expect(cinema.showMovies(arrResult)).to.be.equal(expectedResult);
        });
        it("should return return the movies array", function () {
            let arrResult = ['darkKnight', 'gameOfthrones'];
            let result = arrResult.join(', ');
            expect(cinema.showMovies(arrResult)).to.be.equal(result);
        });
    });

    describe("ticketPrice", function () {
        it("should throw error if there is not a properyType", function () {
            let properyType = 'invalid'
            expect(() => cinema.ticketPrice(properyType)).to.throw();
        });
        it("should return price premiere", function () {
            let properyType = 'Premiere';
            let price = 12.00;
            expect(cinema.ticketPrice(properyType)).to.be.equal(price);
        });
        it("should return price - normal", function () {
            let properyType = 'Normal';
            let price = 7.50;
            expect(cinema.ticketPrice(properyType)).to.be.equal(price);
        });
        it("should return price discound", function () {
            let properyType = 'Discount';
            let price = 5.50;
            expect(cinema.ticketPrice(properyType)).to.be.equal(price);
        });

    });

    describe("swapSeatsInHall", function () {
        it("should return if first place less then 0", function () {
            let firstPlace = -1;
            let secondPlace = 5;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });

        it("should return if second place less then 0", function () {
            let firstPlace = 5;
            let secondPlace = -5;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });
        //ewaeawea
        it("should return if first place less equal 0", function () {
            let firstPlace = 0;
            let secondPlace = 5;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });

        it("should return if second place less equal 0", function () {
            let firstPlace = 5;
            let secondPlace = 0;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });
        //ewaeawwa
        it("should return if first place is NaN", function () {
            let firstPlace = '5';
            let secondPlace = 1;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });

        it("should return if second place is NaN", function () {
            let firstPlace = 2;
            let secondPlace = '5';
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });
        it("should return if first place more then 20", function () {
            let firstPlace = 25;
            let secondPlace = 5;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });
        it("should return if second place more then 20", function () {
            let firstPlace = 1;
            let secondPlace = 25;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });

        it("should return if first === second place", function () {
            let firstPlace = 5;
            let secondPlace = 5;
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(firstPlace, secondPlace)).to.be.equal(result);
        });
        // valid output return
        it("should return if all input is valid", function () {
            let result = "Successful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(1, 5)).to.be.equal(result);
        });
        it("should return if all input is valid 2", function () {
            let result = "Successful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(20, 5)).to.be.equal(result);
        });
        it("should return if all input is valid 3", function () {
            let result = "Successful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(5, 20)).to.be.equal(result);
        });
        it("should return if one of numbers dont exist", function () {
            let result = "Unsuccessful change of seats in the hall.";
            expect(cinema.swapSeatsInHall(5)).to.be.equal(result);
        });
    });

});
