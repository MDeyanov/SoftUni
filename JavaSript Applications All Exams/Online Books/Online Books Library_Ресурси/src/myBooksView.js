import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as dataService from '../../services/dataService.js';


const myBooksTemplate = (books = []) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="my-books-list">
        ${books.map(x => oneBook(x))};
        ${books.length == 0
        ? html`<p class="no-books">No books in database!</p>`
        : nothing
        }
    </ul>

</section>
`;

const oneBook = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl}></p>
    <a class="button" href="/details/${book._id}">Details</a>
</li>
`;

export const renderMybooks = (ctx) => {
    let user = ctx.params.userId;
    dataService.getOwn(user)
        .then(books => {
            ctx.render(myBooksTemplate(books));
        })

}

