import * as api from './api.js';
import * as request from './requester.js';


export const getAll = () => request.get(`${api.games}?sortBy=_createdOn%20desc`);

export const getAllSorted = () => request.get(`${api.games}?sortBy=_createdOn%20desc&distinct=category`);

export const getOne = (id) => request.get(`${api.games}/${id}`);

// export const getOwn = (userId) => request.get(`${api.games}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);

export const create = (game) => request.post(api.games, game);

export const update = (id, game) => request.put(`${api.games}/${id}`, game);

export const del = (id) => request.del(`${api.games}/${id}`);

// export const search = (searchText) => {
//     const query = encodeURIComponent(`name LIKE "${searchText}"`)
//     return request.get(`${api.games}?where=${query}`);
// }


