function solve() {
   let authorInput = document.getElementById('creator');
   let titleInput = document.getElementById('title');
   let categoryInput = document.getElementById('category');
   let contentInput = document.getElementById('content');
   let createButton = document.querySelector('form>button');

   //functionality when createButton is pressed
   createButton.addEventListener('click', (e) => {
      e.preventDefault();
      //create elements to add in posts
      let articleEl = document.createElement('article');
      // elements to be in articleEl
      let h1Element = document.createElement('h1');
      h1Element.textContent = titleInput.value;
      let pElementCategory = document.createElement('p');
      pElementCategory.textContent = 'Category:';
      let strongElCategory = document.createElement('strong');
      strongElCategory.textContent = categoryInput.value;
      pElementCategory.appendChild(strongElCategory);
      let pElementCreator = document.createElement('p');
      pElementCreator.textContent = 'Creator:';
      let strongElCreator = document.createElement('strong');
      strongElCreator.textContent = authorInput.value;
      pElementCreator.appendChild(strongElCreator);
      let pElementContent = document.createElement('p');
      pElementContent.textContent = contentInput.value;

      //buttons for articleEl
      let divElement = document.createElement('div');
      divElement.classList.add('buttons');
      let deleteButton = document.createElement('button');
      deleteButton.classList.add('btndelete');
      deleteButton.textContent = 'Delete';
      let archiveButton = document.createElement('button');
      archiveButton.classList.add('btnarchive');
      archiveButton.textContent = 'Archive';
      divElement.appendChild(deleteButton);
      divElement.appendChild(archiveButton);
      // appent all in articleEl

      articleEl.appendChild(h1Element);
      articleEl.appendChild(pElementCategory);
      articleEl.appendChild(pElementCreator);
      articleEl.appendChild(pElementContent);
      articleEl.appendChild(divElement);
      authorInput.value = '';
      titleInput.value = '';
      categoryInput.value = '';
      contentInput.value = '';
      //adding articleEl
      let findingCurrent = document.querySelector('.site-content>main>section');
      findingCurrent.appendChild(articleEl);

      deleteButton.addEventListener('click', (e) => {
         e.target.parentNode.parentNode.remove();
      });

      archiveButton.addEventListener('click', (e) => {
         let position = document.querySelector('.archive-section>ol');
         let liElementCreate = document.createElement('li');
         let text = e.target.parentNode.parentNode.children[0].textContent;
         liElementCreate.textContent = text;
         position.appendChild(liElementCreate);
         e.target.parentNode.parentNode.remove();

         const toSort = Array.from(position.children);
         toSort.sort((a, b) => {
            return a.textContent.localeCompare(b.textContent);
         });

         toSort.forEach(el => position.appendChild(el));
      });
   });
};
