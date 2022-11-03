function extract(content) {
    let contentEl = document.getElementById('content');
    let pattern = /\(([^(]+)\)/g;
    let matches = contentEl.textContent.matchAll(pattern);
    let result = [];
    
    for (const match of matches) {
        console.log(match[1]);
        result.push(match[1]);
    }

    return result.join('; ');
}