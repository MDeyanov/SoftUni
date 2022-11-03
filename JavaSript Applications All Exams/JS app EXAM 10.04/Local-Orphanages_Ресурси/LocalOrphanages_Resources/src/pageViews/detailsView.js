import { html,nothing } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';
let idPost;
let ctxPage;
let count;

const privateButtons = (postId) => html`
    <!-- Only for registered user and creator of the pets-->
    <a href="/details/${postId}/edit" class="edit-btn btn">Edit</a>
    <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>     
`;
const donationButton=(donate) => html`
<a @click =${donate}href="#" id ="donate" class="donate-btn btn">Donate</a>
`


const detailsTemplate = (post, isLogged,onDelete,isLoggedButNotOnwner,count,donate) => html`
<section id="details-page">
    <h1 class="title">Post Details</h1>
    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src=${post.imageUrl} alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: ${count} </p>

                <!--Edit and Delete are only for creator-->
                <div class="btns">
                    ${isLogged 
                    ? privateButtons(post._id, onDelete)
                    :nothing}
                    ${isLoggedButNotOnwner
                    ?donationButton(donate)
                    :nothing}     
                </div>
            </div>
        </div>
    </div>
</section>
`;

function onDelete(){
    const choice = confirm('Are you sure you want to delete.')
    if(choice){
        dataService.del(idPost);
        ctxPage.redirect("/");
    }
}
function donate(){
    dataService.donate({postId:idPost})
    .then(donation=>{
        ctxPage.redirect(`/details/${idPost}`)
    })
    let donationBtn = document.getElementById('donate');
    donationBtn.style.display  = 'none';
    
    
}
export function renderDetails(ctx) {
    idPost=ctx.params.postId;
    ctxPage = ctx.page;
    let donations = dataService.totalDonations(idPost)
    .then(donation=>{
        count=donation;
    })
    dataService.getOnePost(ctx.params.postId)
        .then(post => {
            let isLogged = Boolean(ctx.user) && post._ownerId == ctx.user._id;
            let isLoggedButNotOnwner = Boolean(ctx.user) && post._ownerId != ctx.user._id;
            
            ctx.render(detailsTemplate(post, isLogged,onDelete,isLoggedButNotOnwner,count,donate));
        });

       
}