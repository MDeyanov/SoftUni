function subtract() {
    let firstNum = document.getElementById("firstNumber");
    let secondNum = document.getElementById("secondNumber");
    let result = document.getElementById("result");

    let sum = Number(firstNum.value) - Number(secondNum.value);
    console.log(result.textContent = sum);
}