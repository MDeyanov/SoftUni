import { html,nothing } from '../../node_modules/lit-html/lit-html.js';
import * as albumsService from '../../services/albumsService.js';
const oneAlbum = (song,isLogged) => html`
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
        ${isLogged
            ? html`<a href="/details/${song._id}" id="details">Details</a>`
            : nothing}
    </div>
</div>
`;

const searchTemplate = (searchHandler,songs,user) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button class="button-list" @click=${searchHandler}>Search</button>
    </div>

    <h2>Results:</h2>

    <!--Show after click Search button-->
    <div class="search-result">
        <!--If have matches-->
        ${songs.map(x => oneAlbum(x,Boolean(user)))};
        ${songs.length == 0
        ? html`<p class="no-result">No result.</p>`
        : nothing
    }
        <!--If there are no matches-->
    </div>
</section>
`;



export const searchView = (ctx) => {
    const searchHandler = (e) => {
        let searchElement = document.getElementById('search-input');
        albumsService.search(searchElement.value)
            .then(songs => {
                ctx.render(searchTemplate(searchHandler,songs,ctx.user));
            });
    };
    ctx.render(searchTemplate(searchHandler,[]));
};
