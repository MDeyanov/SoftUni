function solve(arr) {
    let newArr = [];
    for (const el of arr) {
        if (el < 0) {
            newArr.unshift(el);
        } else {
            newArr.push(el);
        }
    }
    console.log(newArr);
}
solve([7, -2, 8, 9]);