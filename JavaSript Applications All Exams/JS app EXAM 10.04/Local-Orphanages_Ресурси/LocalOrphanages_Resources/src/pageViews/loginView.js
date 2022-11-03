import { html } from '../../node_modules/lit-html/lit-html.js';

import * as authService from '../../services/authService.js';

const loginTemplate = (onSubmit) => html`
<section id="login-page" class="auth">
    <form @submit=${onSubmit} id="login">
        <h1 class="title">Login</h1>

        <article class="input-group">
            <label for="login-email">Email: </label>
            <input type="email" id="login-email" name="email">
        </article>

        <article class="input-group">
            <label for="password">Password: </label>
            <input type="password" id="password" name="password">
            </article>

            <input type="submit" class="btn submit-btn" value="Log In">
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