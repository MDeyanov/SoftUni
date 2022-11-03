function solve(arr) {
    let result = [];
    let counter = 0;
    for (const el of arr) {
        if (el == 'add') {
            counter++;
            result.push(counter);
        } else {
            counter++;
            result.pop();
        }
    }
    if (result.length === 0) {
        return console.log('Empty');
    }
    for (const element of result) {
        console.log(element)
    }
}

solve(['remove', 
'remove', 
'remove']
);