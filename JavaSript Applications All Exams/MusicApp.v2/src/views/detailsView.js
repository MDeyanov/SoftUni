import { html } from '../../node_modules/lit-html/lit-html.js';

import * as albumsService from '../../services/albumsService.js';

const privateButtons = (albumId) => html`

    <a href="/details/${albumId}/edit" class="edit">Edit</a>
    <a href="/details/${albumId}/delete" class="remove">Delete</a>
`;


const detailsTemplate = (album, isLogged) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${album.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre: ${album.genre}</h4>
                <h4>Price: ${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>Description: ${album.description}</p>

            </div>
            <div class="actionBtn">
                ${isLogged && privateButtons(album._id)}
            </div>
        </div>
    </div>
</section>
`;

export function renderDetails(ctx) {


    albumsService.getOne(ctx.params.albumId)
        .then(album => {
            let isLogged = Boolean(ctx.user) && album._ownerId == ctx.user._id;

            ctx.render(detailsTemplate(album, isLogged));
        });
}