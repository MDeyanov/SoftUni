import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as dataService from '../../services/dataService.js';


const dashboardTemplate = (posts = []) => html`
<section id="dashboard-page">
<h1 class="title">All Posts</h1>
<div class="all-posts">
        ${posts.map(x => onePost(x))};
        ${posts.length == 0
        ? html`<div>
            <h1 class="title no-posts-title">No posts yet!</h1>
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

export const renderDashboard = (ctx) => {
    dataService.getAllPosts()
        .then(posts => {
            ctx.render(dashboardTemplate(posts));
        })

}

