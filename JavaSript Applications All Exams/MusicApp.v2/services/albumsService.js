import * as api from './api.js';
import * as request from './requester.js';


export const getAll = () => request.get(`${api.albums}?sortBy=_createdOn%20desc&distinct=name`);

export const getOne = (id) => request.get(`${api.albums}/${id}`);

export const getOwn = (userId) => request.get(`${api.albums}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);


export const create = (album) => request.post(api.albums, album);

export const update = (id, album) => request.put(`${api.albums}/${id}`, album);

export const del = (id) => request.del(`${api.albums}/${id}`);

export const search = (searchText) => {
    const query = encodeURIComponent(`name LIKE "${searchText}"`)
    return request.get(`${api.albums}?where=${query}`);
}


