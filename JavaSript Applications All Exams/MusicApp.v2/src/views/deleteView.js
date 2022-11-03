import * as albumsService from '../../services/albumsService.js';

export const renderDeleteAlbum = (ctx) => {
    const albumId = ctx.params.albumId;
    

    if (confirm('Are you sure you want to delete?')) {
        albumsService.getOne(albumId)
            .then(album => {
                
                if (album._ownerId != ctx.user._id) {
                    ctx.page.redirect('/catalog');
                    throw 'Album ownership failed!'
                }
                return albumsService.del(album._id)
            })
            .then(() => ctx.page.redirect('/catalog'));
    }
}