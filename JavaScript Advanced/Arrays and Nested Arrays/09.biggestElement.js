function solve(matrix) {
    let biggest = -100000;
     for (let row = 0; row < matrix.length; row++) {
         for (let col = 0; col < matrix[row].length; col++) {
             let element = matrix[row][col];
             if (element>biggest) {
                 biggest=element;
             }         
         }       
     }
     return biggest;
}
 
console.log(solve([[20, 50, 10],
[8, 33, 145]]
));