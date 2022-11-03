import { html,nothing } from '../../node_modules/lit-html/lit-html.js';

import * as gamesService from '../../services/gamesService.js';
import { commentsView } from './commentsView.js';

const privateButtons = (gameId) => html`
    <a href="/details/${gameId}/edit" class="edit">Edit</a>
    <a href="/details/${gameId}/delete" class="remove">Delete</a>
`;


const detailsTemplate = (game, commentsSection) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src="${game.imageUrl}" />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">
            ${game.summary}
        </p>

        ${commentsSection}

     <div class="buttons">
         
        ${game.isOwner ? privateButtons(game._id)
        :nothing};
     </div>
  </div >
</section>
`;
 
export async function renderDetails(ctx) {
    const gameId = ctx.params.gameId;

    const [game,commentsSection] = await Promise.all([
        gamesService.getOne(gameId),
        commentsView(gameId)
    ]);

    if (ctx.user) {
        game.isOwner = ctx.user._id == game._ownerId;
    }

    ctx.render(detailsTemplate(game,commentsSection))

    // gamesService.getOne(ctx.params.gameId)
    //     .then(game => {
    //         let isLogged = Boolean(ctx.user) && game._ownerId == ctx.user._id;

    //         ctx.render(detailsTemplate(game, isLogged));
    //     });
}