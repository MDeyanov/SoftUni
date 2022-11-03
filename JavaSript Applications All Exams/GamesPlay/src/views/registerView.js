import { html } from '../../node_modules/lit-html/lit-html.js';
import * as authService from '../../services/authService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="content auth">
    <form id="register" @submit=${onSubmit}>
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </div>
    </form>
</section>
`;

export function renderRegister(ctx) {
    const onSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPass = formData.get('confirm-password');

        if (email == '' || password == '') {
            alert('All fields must be filled')
            return;
        }
        if (password != repeatPass) {
            alert('Password dont match')
            return;
        }

        authService.register(email, password)
            .then(() => {
                ctx.page.redirect('/home');
            });


    }
    ctx.render(registerTemplate(onSubmit));
}