import page from './node_modules/page/page.mjs';
import {authMiddleware} from './middlewares/authMiddleware.js';

import { navMiddleware } from './middlewares/navMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
import { renderLogin } from './src/loginView.js';
import { renderLogout } from './src/logoutView.js';
import { renderDashboard } from './src/dashboardView.js';
import { renderRegister } from './src/registerView.js';
import { renderCreate } from './src/createView.js';
import { renderDetails } from './src/detailsView.js';
import { renderDelete } from './src/deleteView.js';
import { renderEdit } from './src/editView.js';
import { renderMybooks } from './src/myBooksView.js';

page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/', '/dashboard');
page('/login', renderLogin);
page('/logout', renderLogout);
page('/dashboard', renderDashboard);
page('/register', renderRegister);
page('/create', renderCreate);
page('/details/:bookId', renderDetails);
page('/details/:bookId/edit', renderEdit);
page('/details/:bookId/delete', renderDelete);
page('/myBooks/:userId',renderMybooks);

page.start();