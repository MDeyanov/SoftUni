function calc() {
    const firstElement = document.getElementById("num1");
    const secondElement = document.getElementById("num2");
    const sumElement = document.getElementById("sum");
    sumElement.value = Number(firstElement.value) + Number(secondElement.value);
}
