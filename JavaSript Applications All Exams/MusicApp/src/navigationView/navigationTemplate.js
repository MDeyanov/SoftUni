import {html} from '../../node_modules/lit-html/lit-html.js';

export const navTemplate = (nav) => html`
    <nav>
        <img src="./images/headphones.png">
        <a href="/home">Home</a>
        <ul>
            <!--All user-->
            <li><a href="/catalog">Catalog</a></li>
            <li><a href="/search">Search</a></li>
            ${nav.isLoggedIn
                    ? loggedControls(nav)
                    : guestControls()}                      
        </ul >
    </nav >
`;

let loggedControls = (nav) => html`
<!-- Logged users -->
        <li><a href="/create">Create Album</a></li>
        <li><a href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a></li> 
`;

let guestControls = () => html`
<!-- Guest users -->
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
`;

