function toggle() {
    let text = document.getElementById("extra");
    let moreLess = document.querySelector('span');

    if (text.style.display === "block") {
        text.style.display = 'none';
        moreLess.textContent = 'More';
    } else {
        text.style.display = 'block';
        moreLess.textContent = 'Less';
    }
}