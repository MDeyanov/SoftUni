import { html } from '../../node_modules/lit-html/lit-html.js';

export let notificationTemplate = (model) => html`
    <div id="errorBox" class="notification">
        <span>${model.message}</span>
    </div>
`;