import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as albumsService from '../../services/albumsService.js';


const catalogTemplate = (songs = [], user) => html`
<section id="catalogPage">
    <h1>All Albums</h1>

    ${songs.map(x=>oneAlbum(x,Boolean(user)))};
    ${songs.length == 0
        ? html`<p>No Albums in Catalog!</p>`
        : nothing
        }
</section>
`;

const oneAlbum = (song, isLogged) => html`
<div class="card-box">
    <img src="${song.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${song.name}</p>
            <p class="artist">Artist: ${song.artist}</p>
            <p class="genre">Genre: ${song.genre}</p>
            <p class="price">Price: ${song.price}</p>
            <p class="date">Release Date: ${song.releaseDate}</p>
        </div>
        <div class="btn-group">
            ${isLogged
            ? html`<a href="/details/${song._id}" id="details">Details</a>`
            : nothing}
        </div>
    </div>
</div>
`;

export const renderCatalog = (ctx) => {
    albumsService.getAll()
        .then(songs => {
            ctx.render(catalogTemplate(songs,ctx.user));
        })

}