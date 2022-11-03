import page from './node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';

import { navMiddleware } from './middlewares/navMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
    import { renderHome } from './src/views/homeView.js';
import { renderLogin } from './src/views/loginView.js';
import { renderLogout } from './src/views/logoutView.js';
import { renderRegister } from './src/views/registerView.js';
import { renderCatalog } from './src/views/catalogView.js';
import { renderAlbum } from './src/views/createView.js';
import { renderDetails } from './src/views/detailsView.js';
import { renderDeleteAlbum } from './src/views/deleteView.js';
import { renderEdit} from './src/views/editView.js';
import { searchView } from './src/views/searchView.js';

page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/', '/home');
page('/home', renderHome);
page('/login', renderLogin);
page('/logout', renderLogout);
page('/register', renderRegister);
page('/catalog', renderCatalog);
page('/create', renderAlbum);
page('/details/:albumId', renderDetails);
page('/details/:albumId/delete', renderDeleteAlbum);
page('/details/:albumId/edit', renderEdit);
page('/search', searchView);

page.start();