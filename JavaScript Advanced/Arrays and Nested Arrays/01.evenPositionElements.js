function solve(arr) {
    let result = arr.filter((x, index) => index % 2 === 0);
    return result.join(" ");
}
console.log(solve(['20', '30', '40', '50', '60']));