import {html} from '../../node_modules/lit-html/lit-html.js';

const guestUserNavigation = () => html`
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
`;
const loggedUserNavigation = () => html`
<div id="user">
    <a href="/create">Create Game</a>
    <a href="/logout">Logout</a>
</div>

`;

const navigationTemplate = (user) => html`
    <!-- Navigation -->
    <h1><a class="home" href="/home">GamesPlay</a></h1>
    <nav>
        <a href="/catalogue">All games</a>
        ${user
        ? loggedUserNavigation()
        : guestUserNavigation()
        }
    </nav>
`;

export const renderNavigation = ({ user }) => {


    return navigationTemplate(user);
}

