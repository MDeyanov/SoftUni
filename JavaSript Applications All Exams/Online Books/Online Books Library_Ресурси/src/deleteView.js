import * as dataService from '../../services/dataService.js';

export const renderDelete = (ctx) => {
    const bookId = ctx.params.bookId;
    

    if (confirm('Are you sure you want to delete?')) {
        dataService.getOne(bookId)
            .then(book => {
                
                // if (book._ownerId != ctx.user._id) {
                //     ctx.page.redirect('/catalog');
                //     throw 'Book ownership failed!'
                // }
                return dataService.del(book._id)
            })
            .then(() => ctx.page.redirect('/dashboard'));
    }
}