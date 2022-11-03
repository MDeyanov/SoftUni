import { render } from '../node_modules/lit-html/lit-html.js';

import { renderNavigation } from '../src/navigationView.js';

const navigationElement = document.querySelector('header#site-header');

export function navMiddleware(ctx, next) {
    render(renderNavigation(ctx), navigationElement);
    next();
}