import * as api from './api.js';
import * as request from './requester.js';


export const getAll = () => request.get(`${api.books}?sortBy=_createdOn%20desc`);

export const getOne = (id) => request.get(`${api.books}/${id}`);

export const getOwn = (userId) => request.get(`${api.books}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);


export const create = (book) => request.post(api.books, book);

export const update = (id, album) => request.put(`${api.books}/${id}`, album);

export const del = (id) => request.del(`${api.books}/${id}`);
// likes
export const specificUser = (bookId,userId) => request.get(`${api.likes}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);

export const likesCount = (bookId) => request.get(`${api.likes}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);

export const addLike = (bookId) => request.post(`${api.likes}/${bookId}`);

// export const search = (searchText) => {
//     const query = encodeURIComponent(`name LIKE "${searchText}"`)
//     return request.get(`${api.books}?where=${query}`);
// }


