window.addEventListener('load', solution);

function solution() {
  let fullNameInput = document.getElementById('fname');
  let emailInput = document.getElementById('email');
  let phoneNumberInput = document.getElementById('phone');
  let adresInput = document.getElementById('address');
  let postCodeInput = document.getElementById('code');
  //submitButton
  let submitButton = document.getElementById('submitBTN');

  submitButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (fullNameInput.value != '' && emailInput.value != '') {
      let infoPreview = document.getElementById('infoPreview');
      //create 5 li elements 
      let fullNameLi = document.createElement('li');
      fullNameLi.textContent = `Full Name: ${fullNameInput.value}`;
      let emailLi = document.createElement('li');
      emailLi.textContent = `Email: ${emailInput.value}`;
      let phoneLi = document.createElement('li');
      phoneLi.textContent = `Phone Number: ${phoneNumberInput.value}`;
      let addressLi = document.createElement('li');
      addressLi.textContent = `Address: ${adresInput.value}`;
      let postCodeLi = document.createElement('li');
      postCodeLi.textContent = `Postal Code: ${postCodeInput.value}`;
      // save array info
      let arrayOfInputs = [];
      arrayOfInputs.push(fullNameInput.value);
      arrayOfInputs.push(emailInput.value);
      arrayOfInputs.push(phoneNumberInput.value);
      arrayOfInputs.push(adresInput.value);
      arrayOfInputs.push(postCodeInput.value);
      // adding li in infoPreview
      infoPreview.appendChild(fullNameLi);
      infoPreview.appendChild(emailLi);
      infoPreview.appendChild(phoneLi);
      infoPreview.appendChild(addressLi);
      infoPreview.appendChild(postCodeLi);

      fullNameInput.value = '';
      emailInput.value = '';
      phoneNumberInput.value = '';
      adresInput.value = '';
      postCodeInput.value = '';
      submitButton.disabled = true;


      //edit and continue buttons 
      let editButton = document.getElementById('editBTN');
      let continueButton = document.getElementById('continueBTN');
      // enable buttons
      editButton.disabled = false;
      continueButton.disabled = false;

      // edit button functionality
      editButton.addEventListener('click', (e) => {
        fullNameInput.value = arrayOfInputs[0];
        emailInput.value = arrayOfInputs[1];
        phoneNumberInput.value = arrayOfInputs[2];
        adresInput.value = arrayOfInputs[3];
        postCodeInput.value = arrayOfInputs[4];

        infoPreview.innerHTML = '';
        submitButton.disabled = false;
        editButton.disabled = true;
        continueButton.disabled = true;
      });

      // continue button functionality
      continueButton.addEventListener('click', (e) => {
        let childrensToDel = document.getElementById('block');
        childrensToDel.innerHTML = '';
        let createH3 = document.createElement('h3');
        createH3.textContent = "Thank you for your reservation!";
        childrensToDel.appendChild(createH3);
      });
    };
  });
}
