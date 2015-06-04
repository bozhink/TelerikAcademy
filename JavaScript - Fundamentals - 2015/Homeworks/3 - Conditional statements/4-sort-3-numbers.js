/*
 * Problem 4. Sort 3 numbers
 * Sort 3 real values in descending order.
 * Use nested if statements.
 * Note: Don’t use arrays and the built-in
 *   sorting functionality.
 */
var aa, bb, cc;

function sort3Numbers (x, y, z) {
    var a = +x, b = +y, c = +z, swap;
    if (a < b) {
        swap = a;
        a = b;
        b = swap;
    }
    if (a <= c) {
        swap = a;
        a = c;
        c = swap;
        swap = c;
        c = b;
        b = swap;
    } else if (b < c) { // c < a
        swap = c;
        c = b;
        b = swap;
    }
    console.log(x + '\t' + y + '\t' + z + '\t' + a + ' ' + b + ' ' + c);
}


console.log('a\tb\tc\tresult');
aa = 5; bb = 1; cc = 2;
sort3Numbers(aa, bb, cc);
aa = -2; bb = -2; cc = 1;
sort3Numbers(aa, bb, cc);
aa = -2; bb = 4; cc = 3;
sort3Numbers(aa, bb, cc);
aa = 0; bb = -2.5; cc = 5;
sort3Numbers(aa, bb, cc);
aa = -1.1; bb = -0.5; cc = -0.1;
sort3Numbers(aa, bb, cc);
aa = 10; bb = 20; cc = 30;
sort3Numbers(aa, bb, cc);
aa = 1; bb = 1; cc = 1;
sort3Numbers(aa, bb, cc);
