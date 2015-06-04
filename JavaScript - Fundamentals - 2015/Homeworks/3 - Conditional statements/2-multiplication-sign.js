/*
 * Problem 2. Multiplication Sign
 * Write a script that shows the sign (+, - or 0)
 * of the product of three real numbers, without calculating it.
 * Use a sequence of if operators.
 */

var aa, bb, cc;

function multSign(x, y, z) {
    var a, b, c, sign = '0';
    a = +x;
    b = +y;
    c = +z;
    if (a === 0 || b === 0 || c === 0) {
        sign = '0';
    } else {
        if (a > 0) {
            if (b > 0) {
                if (c > 0) {
                    sign = '+';
                } else {
                    sign = '-';
                }
            } else {
                if (c > 0) {
                    sign = '-';
                } else {
                    sign = '+';
                }
            }
        } else {
            if (b > 0) {
                if (c > 0) {
                    sign = '-';
                } else {
                    sign = '+';
                }
            } else {
                if (c > 0) {
                    sign = '+';
                } else {
                    sign = '-';
                }
            }
        }
    }
    return sign;
}

console.log('a\tb\tc\tresult');
aa = 5; bb = 2; cc = 2;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + multSign(aa,bb,cc));
aa = -2; bb = -2; cc = 1;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + multSign(aa,bb,cc));
aa = -2; bb = 4; cc = 3;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + multSign(aa,bb,cc));
aa = 0; bb = -2.5; cc = 4;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + multSign(aa,bb,cc));
aa = -1; bb = -0.5; cc = 5.1;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + multSign(aa,bb,cc));


