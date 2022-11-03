import * as api from './api.js';
import * as request from './requester.js';


export const getAllPosts = () => request.get(`${api.posts}?sortBy=_createdOn%20desc`);

export const getOnePost = (id) => request.get(`${api.posts}/${id}`);

export const getOwnPosts = (userId) => request.get(`${api.posts}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);


export const create = (post) => request.post(api.posts, post);

export const update = (id, post) => request.put(`${api.posts}/${id}`, post);

export const del = (id) => request.del(`${api.posts}/${id}`);

export const donate = (data)=>request.post(api.donation,data);

export const specificUser = (postId,userId)=>request.get(`${api.donation}?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);

export const totalDonations = (postId)=>request.get(`${api.donation}?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);




