class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.avaiableProducts = [];
        this.types = [];
    }

    loadingVegetables(vegetables) {
        for (const vegetable of vegetables) {
            let [type, quantity, price] = vegetable.split(' ');
            if (!this.types.includes(type)) {
                this.avaiableProducts.push({
                    type: type,
                    quantity: quantity,
                    price: price
                });
                this.types.push(type);
            } else {
                this.avaiableProducts[quantity] += Number(quantity);
                if (this.avaiableProducts[price] < Number(price)) {
                    this.avaiableProducts[price] = price;
                }
            }
        }

        return `Successfully added ${Object.keys(this.avaiableProducts)}`;
    }
}
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
