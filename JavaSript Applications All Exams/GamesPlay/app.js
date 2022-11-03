import page from './node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderHome } from './src/views/homeView.js';
import { navMiddleware } from './middlewares/navMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { renderLogin } from './src/views/loginView.js';
import { renderLogout } from './src/views/logoutView.js';
import { renderRegister } from './src/views/registerView.js';
import { renderCatalog } from './src/views/catalogView.js';
import { renderCreate } from './src/views/createView.js';
import { renderDetails } from './src/views/detailsView.js';
import { renderEdit } from './src/views/editView.js';

page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/', '/home');
page('/home', renderHome);
page('/login', renderLogin);
page('/logout', renderLogout);
page('/register', renderRegister);
page('/catalogue', renderCatalog);
page('/create', renderCreate);
page('/details/:gameId', renderDetails);
page('/details/:gameId/edit', renderEdit);

page.start();