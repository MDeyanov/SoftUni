function solve(array) {
    let result = [];
    array.sort((a,b) => a-b);  
    while(array.length > 0){
        result.push(array.shift());
        result.push(array.pop());
    }
    console.log(result);
    return result;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);