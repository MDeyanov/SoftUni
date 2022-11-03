import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as dataService from '../../services/dataService.js';


const dashboardTemplate = (books = []) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="other-books-list">
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

export const renderDashboard = (ctx) => {
    dataService.getAll()
        .then(books => {
            ctx.render(dashboardTemplate(books));
        })

}