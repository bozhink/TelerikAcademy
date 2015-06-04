/*
 * Problem 3. The biggest of Three
 * Write a script that finds the biggest of three numbers.
 * Use nested if statements.
 */

var aa, bb, cc;

function biggestOfThree(x, y, z) {
    var a = +x, b = +y, c = +z, result;
    if (a > b) {
        if (a > c) {
            result = a;
        } else { // a <= c
            result = c;
        }
    } else { // b >= a
        if (b > c) {
            result = b;
        } else { // a <= b <= c
            result = c;
        }
    }
    return result;
}

console.log('a\tb\tc\tbiggest');
aa = 5; bb = 2; cc = 2;
console.log(aa+'\t'+bb+'\t'+cc+'\t'+biggestOfThree(aa,bb,cc));
aa = -2; bb = -2; cc = 1;
console.log(aa+'\t'+bb+'\t'+cc+'\t'+biggestOfThree(aa,bb,cc));
aa = -2; bb = 4; cc = 3;
console.log(aa+'\t'+bb+'\t'+cc+'\t'+biggestOfThree(aa,bb,cc));
aa = 0; bb = -2.5; cc = 5;
console.log(aa+'\t'+bb+'\t'+cc+'\t'+biggestOfThree(aa,bb,cc));
aa = -0.1; bb = -0.5; cc = -1.1;
console.log(aa+'\t'+bb+'\t'+cc+'\t'+biggestOfThree(aa,bb,cc));

