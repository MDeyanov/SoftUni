import{html} from '../../node_modules/lit-html/lit-html.js'

const guestUserNavigation = () => html`
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
`;
const loggedUserNavigation = () => html`
    <li><a href="/create">Create Postcard</a></li>
    <li><a href="/logout">Logout</a></li>

`;

const navigationTemplate = (user) => html`
<nav>
    <section class="logo">
        <img src="./images/logo.png" alt="logo">
    </section>
    <ul>
        <!--Users and Guest-->
        <li><a href="/home">Home</a></li>
        <li><a href="/dashboard">Dashboard</a></li>
        ${user
        ? loggedUserNavigation()
        : guestUserNavigation()}
    </ul>
</nav>
`;

export const renderNavigation = ({ user }) => {


    return navigationTemplate(user);
}

