import { html,nothing } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';

const privateButtons = (bookId) => html`
<a class="button" href="/details/${bookId}/edit">Edit</a>
<a class="button" href="/details/${bookId}/delete">Delete</a>
`;


const detailsTemplate = (book, isLogged,myLikes) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${isLogged  
                ?privateButtons(book._id)
                :html`
                    ${myLikes>0
                     ? nothing
                     :html`<a class="button" href="#">Like</a>`}`}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            
            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: 0</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p> ${book.description}</p>
    </div>
</section>
`;

export function renderDetails(ctx) {

    const user = ctx.params.user;
    const bookId = ctx.params.bookId;
    dataService.addLike(bookId);
    let myLikes;
    if (user) {
        myLikes = dataService.specificUser(bookId,user._id);
    }

    dataService.getOne(ctx.params.bookId)
        .then(book => {
            let isLogged = Boolean(ctx.user) && book._ownerId == ctx.user._id;
            let isNotOwner = Boolean(ctx.user) && book._ownerId != ctx.user._id;

            ctx.render(detailsTemplate(book, isLogged,isNotOwner,myLikes));
        });
}