import { html } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';


const editTemplate = (pet, onSubmit) => html`
 <section  id="editPage">
            <form @submit=${onSubmit} class="editForm">
                <img src="./images/editpage-dog.jpg">
                <div>
                    <h2>Edit PetPal</h2>
                    <div class="name">
                        <label for="name">Name:</label>
                        <input name="name" id="name" type="text" value="${pet.name}">
                    </div>
                    <div class="breed">
                        <label for="breed">Breed:</label>
                        <input name="breed" id="breed" type="text" value="${pet.breed}">
                    </div>
                    <div class="Age">
                        <label for="age">Age:</label>
                        <input name="age" id="age" type="text" value="${pet.age}">
                    </div>
                    <div class="weight">
                        <label for="weight">Weight:</label>
                        <input name="weight" id="weight" type="text" value="${pet.weight}">
                    </div>
                    <div class="image">
                        <label for="image">Image:</label>
                        <input name="image" id="image" type="text" value="${pet.image}">
                    </div>
                    <button class="btn" type="submit">Edit Pet</button>
                </div>
            </form>
        </section>
`;

export const renderEdit = (ctx) => {
    let petId = ctx.params.petId;

    const onSubmit = (e) => {
        e.preventDefault();


        let pet = Object.fromEntries(new FormData(e.currentTarget));
        if (Object.values(pet).some(x => !x)) {
            alert('You must fill all the fields')
            return;
        }

        dataService.update(petId, pet)
            .then(() => ctx.page.redirect(`/details/${petId}`));
    }
    dataService.getOne(petId)
        .then(pet => {
            if (pet._ownerId != ctx.user._id) {
                ctx.page.redirect('/home')
                return;
            }
            ctx.render(editTemplate(pet, onSubmit));
        });
};