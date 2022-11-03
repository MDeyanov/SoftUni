import { html } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';


const editTemplate = (book, onSubmit) => html`
<section id="edit-page" class="edit">
    <form id="edit-form" @submit=${onSubmit} action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" value=${book.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" value=${book.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" value="Fiction">
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>
`;

export const renderEdit = (ctx) => {
    let bookId = ctx.params.bookId;

    const onSubmit = (e) => {
        e.preventDefault();


        let book = Object.fromEntries(new FormData(e.currentTarget));
        if (Object.values(book).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        dataService.update(bookId, book)
            .then(() => ctx.page.redirect(`/details/${bookId}`));
    }
    dataService.getOne(bookId)
        .then(book => {
            if (book._ownerId != ctx.user._id) {
                ctx.page.redirect('/dashboard')
                return;
            }
            ctx.render(editTemplate(book, onSubmit));
        });
};