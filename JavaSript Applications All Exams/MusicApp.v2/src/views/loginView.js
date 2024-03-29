import { html } from '../../node_modules/lit-html/lit-html.js';

import * as authService from '../../services/authService.js';

const loginTemplate = (onSubmit) => html`
<section id="loginPage">
    <form @submit=${onSubmit} id="login-form">
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </fieldset>
    </form>
</section> 
`;

export function renderLogin(ctx) {
    const onSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');
        if (email==='' || password === '') {
            alert('All fields must be filled')
            return;
        }

        authService.login(email, password)
            .then(() => {
                ctx.page.redirect('/home');
            });


    }
    ctx.render(loginTemplate(onSubmit));
}