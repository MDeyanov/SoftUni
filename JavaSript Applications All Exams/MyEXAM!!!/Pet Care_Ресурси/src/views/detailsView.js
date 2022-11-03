import { html,nothing } from '../../node_modules/lit-html/lit-html.js';

import * as dataService from '../../services/dataService.js';
let idPet;
let ctxPage;
let userId;
let count;
const privateButtons = (petId) => html`

    <!-- Only for registered user and creator of the pets-->
    <a href="/details/${petId}/edit" class="edit">Edit</a>
    <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
   
`;
const donationButton=(donate) => html`
<a @click =${donate}href="#" class="donate">Donate</a>
`


const detailsTemplate = (pet, isLogged,onDelete,isLoggedButNotOnwner,count,donate) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${pet.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${count*100}$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            <div class="actionBtn">
                ${isLogged 
                    ? privateButtons(pet._id,onDelete)
                    :nothing}
               ${isLoggedButNotOnwner
            ?donationButton(donate)
            :nothing}     
            </div>

        </div>
    </div>
</section>
`;

function onDelete(){
    const choice = confirm('Are you sure you want to delete.')
    if(choice){
        dataService.del(idPet);
        ctxPage.redirect("/home");
    }
}
function donate(){
    dataService.donate({petId:idPet})
    .then(donation=>{
        ctxPage.redirect(`/details/${idPet}`)
    })
    let donationBtn = document.querySelector('.donate');
    donationBtn.style.display ='none';
    
    
}
export function renderDetails(ctx) {
idPet=ctx.params.petId;
ctxPage = ctx.page;
let donations = dataService.totalDonations(idPet)
    .then(donation=>{
        count=donation;
    })
    dataService.getOne(ctx.params.petId)
        .then(pet => {
            let isLogged = Boolean(ctx.user) && pet._ownerId == ctx.user._id;
            let isLoggedButNotOnwner = Boolean(ctx.user) && pet._ownerId != ctx.user._id;
            
            ctx.render(detailsTemplate(pet, isLogged,onDelete,isLoggedButNotOnwner,count,donate));
        });

       
}