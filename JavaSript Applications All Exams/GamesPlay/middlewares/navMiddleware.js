import {render} from '../node_modules/lit-html/lit-html.js';

import { renderNavigation } from '../src/views/navigationView.js';

const navigationElement = document.querySelector('header.navigation');

export function navMiddleware(ctx,next) {

    render(renderNavigation(ctx), navigationElement);
    next();
}