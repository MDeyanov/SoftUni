function extractText() {
    const items = document.getElementById("items");
    const textArea = document.getElementById("result");
    textArea.textContent = items.textContent;
}