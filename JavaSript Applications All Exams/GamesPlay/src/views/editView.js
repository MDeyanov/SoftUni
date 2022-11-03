import { html } from '../../node_modules/lit-html/lit-html.js';

import * as gamesService from '../../services/gamesService.js';


const editTemplate = (game, onSubmit) => html`
<section id="edit-page" class="auth">
            <form @submit=${onSubmit} id="edit">
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" value="${game.title}">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" value="${game.category}">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" value="${game.maxLevel}">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" value="${game.imageUrl}">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary">${game.summary}</textarea>
                    <input class="btn submit" type="submit" value="Edit Game">

                </div>
            </form>
        </section>
`;

export const renderEdit = (ctx) => {
    let gameId = ctx.params.gameId;

    const onSubmit = (e) => {
        e.preventDefault();


        let game = Object.fromEntries(new FormData(e.currentTarget));
        if (Object.values(game).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        gamesService.update(gameId, game)
            .then(() => ctx.page.redirect(`/details/${gameId}`));
    }
    gamesService.getOne(gameId)
        .then(game => {
            if (game._ownerId != ctx.user._id) {
                ctx.page.redirect(`/details/${gameId}`)
                return;
            }
            ctx.render(editTemplate(game, onSubmit));
        });
};