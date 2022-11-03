function generateReport() {
    let inputElements = Array.from(document.getElementsByTagName('input'));
    const resultArr = [];
    let tableRows = Array.from(document.getElementsByTagName('tr'));

    const checkedCols = [];

    for (let i = 0; i < tableRows.length; i++) {
        const row = tableRows[i];
        let obj = {};

        for (let y = 0; y < row.children.length; y++) {
            const element = row.children[y];

            if (i == 0) {

                if (element.children[0].checked) {
                    checkedCols.push(y);
                }
                continue;
            }

            if (checkedCols.includes(y)) {
                let propName = inputElements[y].name;
                obj[propName] = element.textContent;
            }

        }
        if (i !== 0) {
            resultArr.push(obj);
        }
    }

    document.getElementById('output').value = JSON.stringify(resultArr);

}