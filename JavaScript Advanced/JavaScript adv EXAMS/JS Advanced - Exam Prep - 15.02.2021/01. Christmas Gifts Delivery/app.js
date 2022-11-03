function solution() {
    let addButton = document.querySelector('.container div button');
    let inputEl = document.querySelector('.container div input');
    let toSort = [];
    let listOfGiftsSection = document.querySelector('.card:nth-child(2)>ul');
    // let sendGiftsSection = document.querySelector('.container:nth-child(3) ul');
    let sentGifts = document.querySelector('.card:nth-child(3)>ul');
    let discardGifts = document.querySelector('.card:nth-child(4)>ul');

    addButton.addEventListener('click', (e) => {
        // create 
        let liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = inputEl.value;
        //create buttons
        let sendButton = document.createElement('button');
        sendButton.setAttribute('id', 'sendButton');
        sendButton.textContent = 'Send';
        let discardButton = document.createElement('button');
        discardButton.setAttribute('id', 'discardButton');
        discardButton.textContent = 'Discard';
        //add buttons to liElement
        liElement.appendChild(sendButton);
        liElement.appendChild(discardButton);
        // add liElement and sort
        inputEl.value = '';
        toSort.push(liElement);
        toSort.sort((a, b) => {
            let criteriaA = a.textContent;
            let criteriaB = b.textContent;
            return criteriaA.localeCompare(criteriaB);
        })
            .forEach((li) => {listOfGiftsSection.appendChild(li)});

        sendButton.addEventListener('click', (e) => {
          e.preventDefault();
          let elToMove = e.target.parentNode;
          sentGifts.appendChild(elToMove);
          let index = toSort.indexOf(elToMove);
            toSort.splice(index, 1);
            while (elToMove.children.length > 0) {
                elToMove.removeChild(elToMove.lastElementChild);
            };
        });

        discardButton.addEventListener('click', (e)=>{
            e.preventDefault();
            let elToMove = e.target.parentNode;
            discardGifts.appendChild(elToMove);
            let index = toSort.indexOf(elToMove);
            toSort.splice(index, 1);
            while (elToMove.children.length > 0) {
                elToMove.removeChild(elToMove.lastElementChild);
            };
        })

    })
}