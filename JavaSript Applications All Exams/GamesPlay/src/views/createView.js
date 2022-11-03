import { html } from '../../node_modules/lit-html/lit-html.js';

import * as gamesService from '../../services/gamesService.js';

const createTemplate = (onSubmit) => html`
<section id="create-page" class="auth">
    <form @submit=${onSubmit} id="create">
        <div class="container">

            <h1>Create Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" placeholder="Enter game title...">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" placeholder="Enter game category...">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary"></textarea>
            <input class="btn submit" type="submit" value="Create Game">
        </div>
    </form>
</section>
`;

export const renderCreate = (ctx) => {
    const onSubmit = (e) => {
        e.preventDefault();

        let game = Object.fromEntries(new FormData(e.currentTarget));

        if (Object.values(game).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        gamesService.create(game)
            .then(() => {
                ctx.page.redirect('/home');
            });

    }
    ctx.render(createTemplate(onSubmit));
};
