import page from '../node_modules/page/page.mjs';
import { authMiddleware } from '../middlewares/authMiddleware.js';

import { navMiddleware } from '../middlewares/navMiddleware.js';
import { renderMiddleware } from '../middlewares/renderMiddleware.js';
import { renderHome } from './views/homeView.js';
import { renderLogin } from './views/loginView.js';
import { renderLogout } from './views/logoutView.js';
import { renderRegister } from './views/registerView.js';
import { renderDashboard } from './views/dashboardView.js';
import { renderCreate } from './views/createView.js';
import { renderDetails } from './views/detailsView.js';
import { renderEdit } from './views/editView.js';

page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/', '/home');
page('/home', renderHome);
page('/login', renderLogin);
page('/logout', renderLogout);
page('/register', renderRegister);
page('/dashboard', renderDashboard);
page('/create', renderCreate);
page('/details/:petId', renderDetails);
page('/details/:petId/edit', renderEdit);


page.start();
