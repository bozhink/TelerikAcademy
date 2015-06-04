/*
 * Problem 6. Quadratic equation
 * Write a script that reads the coefficients a, b and c of a quadratic
 *   equation ax2 + bx + c = 0 and solves it (prints its real roots).
 * Calculates and prints its real roots.
 */

var aa, bb, cc;

function quadraticEquation(a, b, c) {
	var result = 'no real roots', // string-valued result
	    D, // Discriminant
	    x1, x2; // roots
	if (!isNaN(a) && !isNaN(b) && !isNaN(c)) {
		D = b*b - 4*a*c;
		if (D > 0) {
			D = Math.sqrt(D);
			x1 = 0.5 * (-b - D) / a;
			x2 = 0.5 * (-b + D) / a;
			result = 'x1=' + x1 + '; x2=' + x2;
		} else if (D === 0) {
			x1 = -0.5 * b / a;
			result = 'x1=x2=' + x1;
		} else {
			result = 'no real roots'; // useless due to initialization
		}
	}
	return result;
}

console.log('a\tb\tc\troots');
aa = 2; bb = 5; cc = -3;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + quadraticEquation(aa,bb,cc));
aa = -1; bb = 3; cc = 0;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + quadraticEquation(aa,bb,cc));
aa = -0.5; bb = 4; cc = -8;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + quadraticEquation(aa,bb,cc));
aa = 5; bb = 2; cc = 8;
console.log(aa + '\t' + bb + '\t' + cc + '\t' + quadraticEquation(aa,bb,cc));
