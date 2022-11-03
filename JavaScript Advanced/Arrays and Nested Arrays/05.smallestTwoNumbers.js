function solve(arr) {
    let sortedArr = arr.sort((a, b) => a - b);
    let result = sortedArr.slice(0, 2);
    console.log(result.join(" "));
}
solve([30, 15, 50, 5]);