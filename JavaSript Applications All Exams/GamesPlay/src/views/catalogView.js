import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as gamesService from '../../services/gamesService.js';


const catalogTemplate = (games = []) => html`
<section id="catalogPage">
    <h1>All Games</h1>

    ${games.map(x => oneGame(x))};
    ${games.length == 0
    ? html`<h3 class="no-articles">No articles yet</h3>`
    : nothing
}
</section>
`;

const oneGame = (game) => html`
<div class="allGames">
    <div class="allGames-info">
        <img src="${game.imageUrl}">
        <h6>${game.category}</h6>
        <h2>${game.title}</h2>
        <a href="/details/${game._id}" class="details-button">Details</a>
    </div>

</div>
`;

export const renderCatalog = (ctx) => {
    gamesService.getAll()
        .then(games => {
            ctx.render(catalogTemplate(games));
        })

}