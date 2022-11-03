import page from './node_modules/page/page.mjs';
import navigationPage from './src/navigationView/navigationPage.js';
import {LitRenderer} from './rendering/litRenderer.js';
import authService from './services/authService.js';
import albumsService from './services/albumsService.js';
import loginPage from './src/loginView/loginPage.js';
import homePage from './src/homeView/homePage.js';
import registerPage from './src/registerView/registerPage.js';
import catalogPage from './src/catalogView/catalogPage.js';
import createPage from './src/createView/createPage.js';

let navHeaderElement = document.querySelector('.header-navigation');
let mainContentElement = document.getElementById('main-content');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navHeaderElement);
let mainRenderHandler = renderer.createRenderHandler(mainContentElement);

navigationPage.initialize(page, navRenderHandler, authService);
homePage.initialize(page, mainRenderHandler, authService);
loginPage.initialize(page, mainRenderHandler, authService);
registerPage.initialize(page,mainRenderHandler,authService);
catalogPage.initialize(page,mainRenderHandler, albumsService);
createPage.initialize(page,mainRenderHandler,albumsService);

page('/index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(navigationPage.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register',registerPage.getView);
page('/catalog',catalogPage.getView);
page('/create',createPage.getView);
page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}