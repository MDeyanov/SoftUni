import { html } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';

const createTemplate = (onSubmit) => html`
<section id="create-page" class="create">
            <form id="create-form" @submit=${onSubmit} action="" method="">
                <fieldset>
                    <legend>Add new Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" placeholder="Title">
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description" id="description" placeholder="Description"></textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" placeholder="Image">
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            <select id="type" name="type">
                                <option value="Fiction">Fiction</option>
                                <option value="Romance">Romance</option>
                                <option value="Mistery">Mistery</option>
                                <option value="Classic">Clasic</option>
                                <option value="Other">Other</option>
                            </select>
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Add Book">
                </fieldset>
            </form>
        </section>
`;

export const renderCreate = (ctx) => {
    const onSubmit = (e) => {
        e.preventDefault();

        let book = Object.fromEntries(new FormData(e.currentTarget));

        if (Object.values(book).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        dataService.create(book)
            .then(() => {
                ctx.page.redirect('/dashboard');
            });
        // let formData = new FormData(e.currentTarget);

        // let name = formData.get('brand');
        // let artist = formData.get('model');
        // let description = formData.get('description');
        // let date = formData.get('year');
        // let imageUrl = formData.get('imgUrl');
        // let price = formData.get('price');
    }
    ctx.render(createTemplate(onSubmit));
};
