class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (let productInfo of products) {
            let [productName, productQuantity, productTotalPrice] = productInfo.split(' ');

            if (Number(productTotalPrice) <= this.budgetMoney) {
                if (!this.stockProducts.hasOwnProperty(productName)) {
                    this.stockProducts[productName] = 0;
                }
                this.stockProducts[productName] += Number(productQuantity);
                this.budgetMoney -= productTotalPrice;
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);

            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }
        this.menu[meal] = {"products": neededProducts, "price": price};

        if (Object.keys(this.menu).length === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else {
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {

        if (Object.keys(this.menu).length === 0) {
            return "Our menu is not ready yet, please come later...";
        }
        let data = [];
        for (let [mealName, mealData] of Object.entries(this.menu)) {
            data.push(`${mealName} - $ ${mealData.price}`);
        }
        return data.join('\n');
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        for (let prod of this.menu[meal].products) {
            let [prodName, quantity] = prod.split(' ');
            if (!this.stockProducts.hasOwnProperty(prodName) || this.stockProducts[prodName] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
            this.stockProducts[prodName] -= Number(quantity);
        }
        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}