import { html } from '../../node_modules/lit-html/lit-html.js'

const guestUserNav = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`;
const logUserNav = (user) => html`
<div id="user">
    <a href="/my-posts/${user._id}">My Posts</a>
    <a href="/create">Create Post</a>
    <a href="/logout">Logout</a>
</div>
   

`;

const navigationTemplate = (user) => html`
<h1><a href="/">Orphelp</a></h1>
<nav>
    <a href="/dashboard">Dashboard</a>

    ${user
        ? logUserNav(user)
        : guestUserNav()}

</nav>
`;

export const renderNavigation = ({ user }) => {


    return navigationTemplate(user);
}


