import * as api from './api.js';
import * as request from './requester.js';


export const getAll = () => request.get(`${api.pets}?sortBy=_createdOn%20desc&distinct=name`);

export const getOne = (id) => request.get(`${api.pets}/${id}`);

// export const getOwn = (userId) => request.get(`${api.pets}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);


export const create = (pet) => request.post(api.pets, pet);

export const update = (id, album) => request.put(`${api.pets}/${id}`, album);

export const del = (id) => request.del(`${api.pets}/${id}`);

export const donate = (data)=>request.post(api.donation,data);

export const specificDonation = (petId,userId)=>request.get(`${api.donation}?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);

export const totalDonations = (petId)=>request.get(`${api.donation}?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);



