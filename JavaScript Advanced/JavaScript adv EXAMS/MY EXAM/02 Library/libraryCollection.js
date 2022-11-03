class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
        this.bookCheckerName = [];
    }
    addBook(bookName, bookAuthor) {
        if (this.capcity === 0) {
            throw new Error("Not enough space in the collection.");
        } else if (this.capacity === this.bookCheckerName.length) {
            throw new Error("Not enough space in the collection.");
        } else {
            this.bookCheckerName.push(bookName);
            this.books.push({
                'bookName': bookName,
                'bookAuthor': bookAuthor,
                'payed': false
            });
            return `The ${bookName}, with an author ${bookAuthor}, collect.`
        }
    }

    payBook(bookName) {
        if (!this.bookCheckerName.includes(bookName)) {
            throw new Error(`${bookName} is not in the collection.`)
        } else if (this.books.find(x => x.bookName == bookName && x.payed == true)) {
            throw new Error(`${bookName} has already been paid.`)
        } else {
            let index = this.books.findIndex(x => x.bookName == bookName);
            this.books[index].payed = true;
            return `${bookName} has been successfully paid.`
        }
    }
    removeBook(bookName) {
        if (!this.bookCheckerName.includes(bookName)) {
            throw new Error("The book, you're looking for, is not found.");
        } else if (this.books.find(x => x.bookName == bookName && x.payed == false)) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        } else {
            let index = this.books.findIndex(x => x.bookName == bookName);
            this.books.splice(index, 1);
            this.bookCheckerName.splice(index, 1);
            return `${bookName} remove from the collection.`
        }
    }
    getStatistics(bookAuthor) {
        if (bookAuthor === undefined) {
            let resultToReturn = [];
            resultToReturn.push(`The book collection has ${Number(this.capacity) - this.bookCheckerName.length} empty spots left.`);
            this.books.sort((a, b) => (a.bookName > b.bookName) ? 1 : (b.bookName > a.bookName) ? -1 : 0).forEach(x => {
                resultToReturn.push(`${x.bookName} == ${x.bookAuthor} - ${x.payed == true ? 'Has Paid' : 'Not Paid'}.`);
            })
            return resultToReturn.join('\n');
        } else if (!this.books.find(x => x.bookAuthor == bookAuthor)) {

            throw new Error(`${bookAuthor} is not in the collection.`)

        } else {
            let ahtorOnly = [];
            for (const book of this.books) {
                if (book.bookAuthor === bookAuthor) {
                    ahtorOnly.push(book);
                }
            }
            let resultToReturn = [];
            ahtorOnly.forEach(x=>{
                resultToReturn.push((`${x.bookName} == ${x.bookAuthor} - ${x.payed == true ? 'Has Paid' : 'Not Paid'}.`))});
            return resultToReturn.join('\n');

        }

    }
}
const library = new LibraryCollection(2)
console.log(library.addBook('In Search of Lost Time', 'Marcel Proust'));
console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.payBook('In Search of Lost Time'));
console.log(library.getStatistics('Marcel Proust'))
