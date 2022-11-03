import * as api from './api.js'
import * as request from './requester.js';


export const getComments = (gameId) => request.get(`${api.comments}?where=gameId%3D%22${gameId}%22`);

export const postComment = () => request.post(`${api.comments}`);
