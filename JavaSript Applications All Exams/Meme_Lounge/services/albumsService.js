import { jsonRequester } from "../helper/jsonRequester.js";


let baseUrl = 'http://localhost:3030/data/albums';

async function getAll() {
    let result = await jsonRequester(baseUrl);
    return result;
}
async function getAllAlbums() {
    let result = await jsonRequester(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}

async function getMyAlbums(userId) {
    let result = await jsonRequester(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

async function get(id) {
    let result = await jsonRequester(`${baseUrl}/${id}`);
    return result;
}

async function create(item) {
    let result = await jsonRequester(`${baseUrl}`, 'Post', item, true);
    return result;
}

async function update(item,id){
    let result = await jsonRequester(`${baseUrl}/${id}`, 'Put', item, true);
    return result;
}

async function deleteItem(id){
    let result = await jsonRequester(`${baseUrl}/${id}`, 'Delete', undefined, true);
    return result;
}

export default{
    getAll,
    get,
    create,
    update,
    deleteItem,
    getAllMemes,
    getMyMemes
}
