function solve(array, count) {
    for (let index = 1; index <= count; index++) {
        array.unshift(array.pop());
    }
    console.log(array.join(" "));
}

solve(
    ['1',
        '2',
        '3',
        '4'],
    2
);

solve(
    ['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);