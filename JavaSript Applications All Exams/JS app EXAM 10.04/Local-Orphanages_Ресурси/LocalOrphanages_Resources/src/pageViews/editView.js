import { html } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';


const editTemplate = (post, onSubmit) => html`
 <section id="edit-page" class="auth">
            <form @submit=${onSubmit} id="edit">
                <h1 class="title">Edit Post</h1>

                <article class="input-group">
                    <label for="title">Post Title</label>
                    <input type="title" name="title" id="title" value="${post.title}">
                </article>

                <article class="input-group">
                    <label for="description">Description of the needs </label>
                    <input type="text" name="description" id="description" value="${post.description}">
                </article>

                <article class="input-group">
                    <label for="imageUrl"> Needed materials image </label>
                    <input type="text" name="imageUrl" id="imageUrl" value="${post.imageUrl}">
                </article>

                <article class="input-group">
                    <label for="address">Address of the orphanage</label>
                    <input type="text" name="address" id="address" value="${post.address}">
                </article>

                <article class="input-group">
                    <label for="phone">Phone number of orphanage employee</label>
                    <input type="text" name="phone" id="phone" value="${post.phone}">
                </article>

                <input type="submit" class="btn submit" value="Edit Post">
            </form>
        </section>
`;

export const renderEdit = (ctx) => {
    let postId = ctx.params.postId;

    const onSubmit = (e) => {
        e.preventDefault();


        let post = Object.fromEntries(new FormData(e.currentTarget));
        if (Object.values(post).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        dataService.update(postId, post)
            .then(() => ctx.page.redirect(`/details/${postId}`));
    }
    dataService.getOnePost(postId)
        .then(post => {
            if (post._ownerId != ctx.user._id) {
                ctx.page.redirect('/')
                return;
            }
            ctx.render(editTemplate(post, onSubmit));
        });
};