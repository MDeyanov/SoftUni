function solve(arr) {
    let result = 0;
    for (let row = 0; row < arr.length-1; row++) {
        for (let col = 0; col < arr[row].length; col++) {
            let curElement = arr[row][col];
            let otherElementRow = arr[row + 1][col]
            let otherElementCol = arr[row][col+1]
            if (curElement == otherElementRow) {
                result++;
            }
            if (curElement == otherElementCol) {
                result++;
            }
        }
    }
    for (let row = arr.length-1; row < arr.length; row++) {
        for (let col = 0; col < arr[row].length; col++) {
            let curElement = arr[row][col];
            let otherElementCol = arr[row][col+1]
            if (curElement == otherElementCol) {
                result++;
            }
        }    
    }
    return result;
}
console.log(solve(
[['2', '2', '5', '7', '4'],
['4', '0', '5', '3', '4'],
['2', '5', '5', '4', '2']]
));
