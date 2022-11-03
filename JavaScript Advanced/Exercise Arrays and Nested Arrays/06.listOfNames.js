function solve(arr) {
    let result = arr.sort((a, b) => a.localeCompare(b));
    let counter = 1;
    for (const el of result) {        
        console.log(`${counter}.${el}`);
        counter++;
    }
}
solve(["John", "Bob", "Christina", "Ema"]);