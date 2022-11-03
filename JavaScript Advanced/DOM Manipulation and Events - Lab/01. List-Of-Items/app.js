function addItem() {
    let items = document.getElementById('items');
    let inputEl = document.getElementById('newItemText');

    let newElement = document.createElement('li');
    newElement.textContent = inputEl.value;
    items.appendChild(newElement);
    inputEl.value='';
}