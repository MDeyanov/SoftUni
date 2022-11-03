function solve(arr, steps) {
    let result = [];
    for (let index = 0; index < arr.length; index += steps) {
        result.push(arr[index]);

    }
    return result;
}
console.log(solve(['dsa',
    'asd',
    'test',
    'tset'],
    2
));
console.log(solve(['1',
    '2',
    '3',
    '4',
    '5'],
    6
));