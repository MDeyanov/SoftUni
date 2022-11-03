import { html } from '../node_modules/lit-html/lit-html.js';

const guestUserNavigation = () => html`
    <div id="guest">
        <a class="button" href="/login">Login</a>
        <a class="button" href="/register">Register</a>
    </div>
`;
const loggedUserNavigation = (user) => html`
    <div id="user">
            <span>Welcome, ${user.email}</span>
            <a class="button" href="/myBooks/${user._id}">My Books</a>
            <a class="button" href="/create">Add Book</a>
            <a class="button" href="/logout">Logout</a>
        </div>

`;

const navigationTemplate = (user) => html`
<!-- Navigation -->
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        ${user
        ? loggedUserNavigation(user)
        : guestUserNavigation()
        }   
    </section>
</nav>
`;

export const renderNavigation = ({ user }) => {


    return navigationTemplate(user);
}

