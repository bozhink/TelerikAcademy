/*
 * Problem 1. Exchange if greater
 * Write an if statement that takes two double
 * variables a and b and exchanges their values
 * if the first one is greater than the second.
 * As a result print the values a and b, separated by a space.
 */

function xchange(x, y) {
    var a, b, z;
    a = +x;
    b = +y;
    if (a > b) {
        z = a;
        a = b;
        b = z;
    }
    console.log(x + '\t' + y + '\t' + a + ' ' + b);
}

console.log('a\tb\tresult');
xchange(5, 2);
xchange(3, 4);
xchange(5.5, 4.5);

