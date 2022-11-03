window.addEventListener('load', solve);

function solve() {
    //ADD BUTTON
    let btnAdd = document.querySelector('#add');
    // INPUTS
    let modelInput = document.querySelector('#model');
    let yearInput = document.querySelector('#year');
    let descriptionInput = document.querySelector('#description');
    let priceInput = document.querySelector('#price');

    btnAdd.addEventListener('click', (e) => {
        e.preventDefault();
        if (!modelInput.value == ''
            && yearInput.value >= 0
            && !descriptionInput.value == ''
            && priceInput.value >= 0
            && !yearInput.value == ''
            && !priceInput.value == '') {

            let furnitureList = document.getElementById('furniture-list');

            //createElements TR first part
            let elementTrInfo = document.createElement('tr');
            elementTrInfo.classList.add('info');
            // inside of Element info adding 3 TD elements
            let tdModelElement = document.createElement('td');
            tdModelElement.textContent = modelInput.value;
            let tdPrice = document.createElement('td');
            tdPrice.textContent = Number(priceInput.value).toFixed(2);
            //2 buttons - third td element
            let tdButtons = document.createElement('td');
            let btnMoreInfo = document.createElement('button');
            btnMoreInfo.textContent = 'More Info';
            btnMoreInfo.classList.add('moreBtn');
            let btnBuy = document.createElement('button');
            btnBuy.textContent = 'Buy it';
            btnBuy.classList.add('buyBtn');

            tdButtons.appendChild(btnMoreInfo);
            tdButtons.appendChild(btnBuy);
            elementTrInfo.appendChild(tdModelElement);
            elementTrInfo.appendChild(tdPrice);
            elementTrInfo.appendChild(tdButtons);

            furnitureList.appendChild(elementTrInfo);

            //Create tr secondPart hide
            let elementTrHide = document.createElement('tr');
            elementTrHide.classList.add('hide');
            //inside of element 'hide' 2 td elements
            let tdYear = document.createElement('td');
            tdYear.textContent = 'Year:' +' '+ yearInput.value;
            let tdDescription = document.createElement('td');
            tdDescription.colSpan = '3';
            tdDescription.textContent = 'Description:' +' '+ descriptionInput.value;

            elementTrHide.appendChild(tdYear);
            elementTrHide.appendChild(tdDescription);
            furnitureList.appendChild(elementTrHide);

            modelInput.value = '';
            yearInput.value = '';
            descriptionInput.value = '';
            priceInput.value = '';

            btnMoreInfo.addEventListener('click', (e) => {
                if (btnMoreInfo.textContent == 'More Info') {
                    btnMoreInfo.textContent = 'Less Info'
                    let hide = document.querySelector('.hide');
                    hide.style.display = 'contents';
                } else if (btnMoreInfo.textContent == 'Less Info') {
                    btnMoreInfo.textContent = 'More Info'
                    let hide = document.querySelector('.hide');
                    hide.style.display = 'none';
                }
            });

            btnBuy.addEventListener('click', (e) => {
                let totalPrice = document.querySelector('.total-price');
                let price = btnBuy.parentElement.previousSibling.textContent;
                let priceAsNum = Number(price);
                let elToRemove = btnBuy.parentElement.parentElement;
                elToRemove.remove();
                totalPrice.textContent = priceAsNum.toFixed(2);
            });
        }
    });
}
