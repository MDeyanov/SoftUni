function solve() {
    //inputs
    let firstNameInput = document.getElementById('fname');
    let lastNameInput = document.getElementById('lname');
    let emailInput = document.getElementById('email');
    let birthInput = document.getElementById('birth');
    let positionInput = document.getElementById('position');
    let salaryInput = document.getElementById('salary');
    //button
    let buttonAddWorkers = document.getElementById('add-worker');
    let tBody = document.getElementById('tbody');
    let sum = document.getElementById('sum');
    let price = 0;

    buttonAddWorkers.addEventListener('click', (e) => {
        e.preventDefault();
        if (firstNameInput.value != ''
            && lastNameInput.value != ''
            && emailInput.value != ''
            && birthInput.value != ''
            && positionInput.value != ''
            && salaryInput.value != '') {
            // make tr el
            let trElement = document.createElement('tr');
            // tdEl create
            let tdFirstName = document.createElement('td');
            tdFirstName.textContent = firstNameInput.value;
            let tdLastName = document.createElement('td');
            tdLastName.textContent = lastNameInput.value;
            let tdEmail = document.createElement('td');
            tdEmail.textContent = emailInput.value;
            let tdBirth = document.createElement('td');
            tdBirth.textContent = birthInput.value;
            let tdPosition = document.createElement('td');
            tdPosition.textContent = positionInput.value;
            let tdSalary = document.createElement('td');
            tdSalary.textContent = salaryInput.value;
            //create buttons td
            let tdButtons = document.createElement('td');
            let firedButton = document.createElement('button');
            firedButton.classList.add('fired');
            firedButton.textContent = 'Fired';
            let edintButton = document.createElement('button');
            edintButton.classList.add('edit');
            edintButton.textContent = 'Edit';
            tdButtons.appendChild(firedButton);
            tdButtons.appendChild(edintButton);
            // add td elements to tr element
            trElement.appendChild(tdFirstName);
            trElement.appendChild(tdLastName);
            trElement.appendChild(tdEmail);
            trElement.appendChild(tdBirth);
            trElement.appendChild(tdPosition);
            trElement.appendChild(tdSalary);
            trElement.appendChild(tdButtons);
            // add tr to tbody
            tBody.appendChild(trElement);
            //adding salary to budget
            price += Number(salaryInput.value);
            sum.textContent = price.toFixed(2);
            firstNameInput.value = '';
            lastNameInput.value = '';
            emailInput.value = '';
            birthInput.value = '';
            positionInput.value = '';
            salaryInput.value = '';
            // edit Button functionality
            edintButton.addEventListener('click', (e) => {
                e.preventDefault();
                let fName = e.target.parentNode.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.textContent;
                let lName = e.target.parentNode.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.textContent;
                let email = e.target.parentNode.previousSibling.previousSibling.previousSibling.previousSibling.textContent;
                let birth = e.target.parentNode.previousSibling.previousSibling.previousSibling.textContent;
                let position = e.target.parentNode.previousSibling.previousSibling.textContent;
                let salary = e.target.parentNode.previousSibling.textContent;
                firstNameInput.value = fName;
                lastNameInput.value = lName;
                emailInput.value = email;
                birthInput.value = birth;
                positionInput.value = position;
                salaryInput.value = salary;
                price -= Number(salary);
                sum.textContent = price.toFixed(2);
                e.target.parentNode.parentNode.remove();
            })

            firedButton.addEventListener('click', (e) => {
                e.preventDefault();
                let money = e.target.parentNode.previousSibling.textContent;
                price -= Number(money);
                sum.textContent = price.toFixed(2);
                e.target.parentNode.parentNode.remove();

            })
        }
    })
}
solve()