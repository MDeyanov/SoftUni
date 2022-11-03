import { html } from '../../node_modules/lit-html/lit-html.js';
import * as authService from '../../services/authService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="auth">
            <form @submit=${onSubmit} id="register">
                <h1 class="title">Register</h1>

                <article class="input-group">
                    <label for="register-email">Email: </label>
                    <input type="email" id="register-email" name="email">
                </article>

                <article class="input-group">
                    <label for="register-password">Password: </label>
                    <input type="password" id="register-password" name="password">
                </article>

                <article class="input-group">
                    <label for="repeat-password">Repeat Password: </label>
                    <input type="password" id="repeat-password" name="repeatPassword">
                </article>

                <input type="submit" class="btn submit-btn" value="Register">
            </form>
        </section>
`;

export function renderRegister(ctx) {
    const onSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPass = formData.get('repeatPassword');

        if (email == '' || password == '' || repeatPass =='') {
            alert('All fields must be filled')
            return;
        }
        if (password != repeatPass) {
            alert('Password dont match')
            return;
        }

        authService.register(email, password)
            .then(() => {
                ctx.page.redirect('/');
            });


    }
    ctx.render(registerTemplate(onSubmit));
}