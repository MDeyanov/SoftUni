import { html } from '../../node_modules/lit-html/lit-html.js';
import * as authService from '../../services/authService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="register">
    <form id="register-form" @submit=${onSubmit} action="" method="">
        <fieldset>
            <legend>Register Form</legend>
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
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>
`;

export function renderRegister(ctx) {
    const onSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPass = formData.get('confirm-pass');

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
                ctx.page.redirect('/dashboard');
            });


    }
    ctx.render(registerTemplate(onSubmit));
}