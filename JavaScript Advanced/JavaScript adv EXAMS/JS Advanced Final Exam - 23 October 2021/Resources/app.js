window.addEventListener('load', solve);

function solve() {
    let genreInput = document.querySelector('#genre');
    let songNameInput = document.querySelector('#name');
    let authorSongInput = document.querySelector('#author');
    let creationDateInput = document.querySelector('#date');

    let addButton = document.querySelector('#add-btn');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        if (genreInput.value.length > 0
            && songNameInput.value.length > 0
            && authorSongInput.value.length > 0
            && creationDateInput.value.length > 0) {
            //
            let allHitsDiv = document.querySelector('.all-hits-container');
            let hitsInfo = document.createElement('div');
            hitsInfo.classList.add('hits-info');
            //img
            let img = document.createElement('img');
            img.src = "./static/img/img.png";
            //h2Elements (Genre,SongName, AuthorName)
            let h2GenreElement = document.createElement('h2');
            h2GenreElement.textContent = `Genre: ${genreInput.value}`;
            let h2NameElement = document.createElement('h2');
            h2NameElement.textContent = `Name: ${songNameInput.value}`;
            let h2AuthorElement = document.createElement('h2');
            h2AuthorElement.textContent = `Author: ${authorSongInput.value}`;
            //h3Element (Date)
            let h3DateElement = document.createElement('h3');
            h3DateElement.textContent = `Date: ${creationDateInput.value}`;
            //Buttons (save,like delete)
            let saveButton = document.createElement('button');
            saveButton.classList.add("save-btn");
            saveButton.textContent = 'Save song';
            let likeButton = document.createElement('button');
            likeButton.classList.add("like-btn");
            likeButton.textContent = "Like song";
            let delButton = document.createElement('button');
            delButton.classList.add("delete-btn");
            delButton.textContent = "Delete";
            //adding Childs in hitsInfo
            hitsInfo.appendChild(img);
            hitsInfo.appendChild(h2GenreElement);
            hitsInfo.appendChild(h2NameElement);
            hitsInfo.appendChild(h2AuthorElement);
            hitsInfo.appendChild(h3DateElement);
            //btns append
            hitsInfo.appendChild(saveButton);
            hitsInfo.appendChild(likeButton);
            hitsInfo.appendChild(delButton);
            allHitsDiv.appendChild(hitsInfo);
            // clearInputs
            genreInput.value = '';
            songNameInput.value = '';
            authorSongInput.value = '';
            creationDateInput.value = '';

            likeButton.addEventListener('click', (e) => {
                let totalLikes = document.querySelector('.likes>p');
                let likes = totalLikes.textContent.split(' ');
                let likesCounter = likes.pop();
                likesCounter++;
                likes.push(likesCounter);
                totalLikes.textContent = likes.join(' ');
                likeButton.disabled = true;
            });

            saveButton.addEventListener('click', (e)=>{
                let saveContainer = document.querySelector('.saved-container');
                e.target.nextSibling.remove();
                e.target.remove();
                saveContainer.appendChild(hitsInfo);

            })

            delButton.addEventListener('click', (e) => {
                e.target.parentNode.remove();
            })
        }
    });

}