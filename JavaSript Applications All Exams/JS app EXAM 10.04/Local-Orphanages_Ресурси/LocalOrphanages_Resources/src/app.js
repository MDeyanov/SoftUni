import page from '../node_modules/page/page.mjs';
import { authMiddleware } from '../middlewares/authMiddleware.js';
import { navMiddleware } from '../middlewares/navMiddleware.js';
import { renderMiddleware } from '../middlewares/renderMiddleware.js';
import { renderRegister } from './pageViews/registerView.js';
import { renderLogin } from './pageViews/loginView.js';
import { renderLogout } from './pageViews/logoutView.js';
import { renderDashboard } from './pageViews/dashboardView.js';
import { renderCreate } from './pageViews/createView.js';
import { renderDetails } from './pageViews/detailsView.js';
import { renderEdit } from './pageViews/editView.js';
import { renderMyPosts } from './pageViews/myPostsView.js';


page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/', '/dashboard');
page('/register', renderRegister);
page('/login', renderLogin);
page('/logout', renderLogout)
page('/create', renderCreate);
page('/dashboard', renderDashboard);
page('/details/:postId', renderDetails);
page('/details/:postId/edit', renderEdit);
page('/my-posts/:userId', renderMyPosts);

page.start();