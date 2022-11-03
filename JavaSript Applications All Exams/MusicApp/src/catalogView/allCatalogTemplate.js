import { html,nothing } from '../../node_modules/lit-html/lit-html.js';


export let allCatalogTemplate = (albums = [],user) => html`
<section id="catalogPage">
            <h1>All Albums</h1>

            ${albums.length > 0
                ? albums.map(m => catalogTemplate(m,Boolean(user)))
                : html`<p>No Albums in Catalog!</p>`}
            
        </section>
 `;

let catalogTemplate = (album,isLogged) => html`
<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: ${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        <div class="btn-group">
            ${isLogged
            ? html`<a href="/details/${album._id}" id="details">Details</a>`
            : nothing}
        </div>
    </div>
</div>
`;

 