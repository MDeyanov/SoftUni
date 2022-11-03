import { html } from '../../node_modules/lit-html/lit-html.js';

import * as authService from '../../services/authService.js';

const loginTemplate = (onSubmit) => html`
<section id="login-page" class="login">
    <form id="login-form" @submit=${onSubmit} action="" method="">
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
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
        if (email === '' || password === '') {
            alert('All fields must be filled')
            return;
        }

        authService.login(email, password)
            .then(() => {
                ctx.page.redirect('/dashboard');
            });


    }
    ctx.render(loginTemplate(onSubmit));
}