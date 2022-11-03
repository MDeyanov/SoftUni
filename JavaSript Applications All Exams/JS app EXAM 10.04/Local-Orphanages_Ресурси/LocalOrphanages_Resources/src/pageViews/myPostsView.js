import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as dataService from '../../services/dataService.js';


const myPostsTemplate = (posts = []) => html`
<section id="my-posts-page">
<h1 class="title">My Posts</h1>

<div class="my-posts">
        ${posts.map(x => onePost(x))};
        ${posts.length == 0
        ? html`<div>
            <h1 class="title no-posts-title">You have no posts yet!</h1>
        </div>`
        : nothing
        }
    </div>
</section>
`;

const onePost = (post) => html`
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src=${post.imageUrl} alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>
`;

export const renderMyPosts = (ctx) => {
    let user = ctx.params.userId;
    dataService.getOwnPosts(user)
        .then(posts => {
            ctx.render(myPostsTemplate(posts));
        })

}