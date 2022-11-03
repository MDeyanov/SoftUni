class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error("The budget cannot be a negative number");
        } else {
            this._budget = value;
        }
    }

    shopping(product) {
        let [type, price] = product;
        if (this.budget < price) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(type);
        this.budget -= price;
        return `You have successfully bought ${type}!`
    }


    recipes(recipe) {
        let { recipeName, productsList } = recipe;
        for (let product of productsList) {
            if (this.products.includes(product) === false) {
                throw new Error("We do not have this product");
            }
        }

        this.dishes.push(recipe);
        return `${recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish) {
        if (this.dishes.find(obj => obj.recipeName === dish) === undefined) {
            throw new Error("We do not have this dish");
        }

        if (this.guests.hasOwnProperty(name) === true) {
            throw new Error("This guest has already been invited");
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`

    }

    showAttendance() {
        let result = [];
        let guestsArray = Object.entries(this.guests);
        for (let guest of guestsArray) {
            let [guestName, guestDish] = guest;

            let index = this.dishes.findIndex(dish => dish.recipeName === guestDish);
            let currentProductsArray = this.dishes[index].productsList;

            result.push(`${guestName} will eat ${guestDish}, which consists of ${currentProductsArray.join(', ')}`);
        }
        return result.join('\n');
    }
}
let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());

