class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture": 200, "photo": 50, "item": 250 };
        this.listOfArticles = [];
        this.guests = [];
    }
    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }
        if (this.listOfArticles.some(x => x.name == articleName) && this.listOfArticles.some(x => x.model == articleModel.toLowerCase())) {
            let currItem = this.listOfArticles.find(x => x.name == articleName && this.listOfArticles.find(x => x.model == articleModel.toLowerCase()));
            currItem.quantity += quantity;
        }else{
            this.listOfArticles.push({
                model: articleModel.toLowerCase(),
                name: articleName,
                quantity: quantity
            });
        }
        
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`

    }
    inviteGuest(guestName, personality) {
        let pts = 0;
        if (personality == "Vip") {
            pts = 500;
        } else if (personality == "Middle") {
            pts = 250;
        } else {
            pts = 50;
        }
        if (this.guests.some(x => x.name == guestName)) {
            throw new Error(`${guestName} has already been invited.`)
        }
        this.guests.push({
            name: guestName,
            points: pts,
            purchaseArticle: 0
        });
        return `You have successfully invited ${guestName}!`
    }
    buyArticle(articleModel, articleName, guestName) {
        let currArticle = this.listOfArticles.find(x => x.name == articleName && x.model == articleModel.toLowerCase());
        let guest = this.guests.find(x => x.name == guestName);
        if (currArticle == undefined) {
            throw new Error("This article is not found.");
        }
        if (currArticle.quantity == 0) {
            return `The ${articleName} is not available.`
        }
        if (guest == undefined) {
            return "This guest is not invited.";
        }
        let articlePoints = this.possibleArticles[articleModel.toLowerCase()];
        if (guest.points < articlePoints) {
            // pod vypros
            return "You need to more points to purchase the article.";
        } else {
            guest.points -= articlePoints;
            currArticle.quantity--;
            guest.purchaseArticle++;
            return `${guestName} successfully purchased the article worth ${articlePoints} points.`
        }
    }
    showGalleryInfo(criteria) {
        if (criteria == 'article') {
            let result = "Articles information:\n"
            for (const article of this.listOfArticles) {
                result += `${article.model} - ${article.name} - ${article.quantity}\n`;
            }
            return result.trim();

        } else {
            let result = "Guests information:\n"
            for (const guest of this.guests) {
                result += `${guest.name} - ${guest.purchaseArticle}\n`;
            }
            return result.trim();
        }
    }
}
const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));

