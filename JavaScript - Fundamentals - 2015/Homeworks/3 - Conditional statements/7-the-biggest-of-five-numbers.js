/*
 * Problem 7. The biggest of five numbers
 * Write a script that finds the greatest of given 5 variables.
 * Use nested if statements.
 */

var a, b, c, d, e;

/* The right way */
function biggestOfFive0(a, b, c, d, e) {
	var result = undefined; // explicitly set to undefined for clarity
	if (!isNaN(a) && !isNaN(b) && !isNaN(c) && !isNaN(d) && !isNaN(e)) {
		result = a;
		if (result < b) {
			result = b;
		}
		if (result < c) {
			result = c;
		}
		if (result < d) {
			result = d;
		}
		if (result < e) {
			result = e;
		}
	}
	return result;
}

function biggestOfFive(a, b, c, d, e) {
	var result = undefined; // explicitly set to undefined for clarity
	if (!isNaN(a) && !isNaN(b) && !isNaN(c) && !isNaN(d) && !isNaN(e)) {
		if (a > b) {
			if (a > c) {
				if (a > d) {
					if (a > e) { // a > b, a > c, a > d, a > e
						result = a;
					} else { // a > b, a > c, a > d, a <= e
						result = e;
					}
				}  else { // a > b, a > c, a <= d
					if (d > e) {
						result = d;
					} else {
						result = e;
					}
				}
			} else { // a > b, a <= c
				if (c > d) {
					if (c > e) {
						result = c;
					} else {
						result = e;
					}
				} else {
					if (d > e) {
						result = d;
					} else {
						result = e;
					}
				}
			}
		} else { // a <= b
			if (b > c) {
				if (b > d) {
					if (b > e) {
						result = b;
					} else {
						result = e;
					}
				} else {
					if (d > e) {
						result = d;
					} else {
						result = e;
					}
				}
			} else {
				if (c > d) {
					if (c > e) {
						result = c;
					} else {
						result = e;
					}
				} else {
					if (d > e) {
						result = d;
					} else {
						result = e;
					}
				}
			}
		}
	}
	return result;
}

console.log('a\tb\tc\td\te\tresult');
a = 5; b = 2; c = 2; d = 4; e = 1;
console.log(a+'\t'+b+'\t'+c+'\t'+d+'\t'+e+'\t'+biggestOfFive(a, b, c, d, e));
a = -2; b = -22; c = 1; d = 0; e = 0;
console.log(a+'\t'+b+'\t'+c+'\t'+d+'\t'+e+'\t'+biggestOfFive(a, b, c, d, e));
a = -2; b = 4; c = 3; d = 2; e = 0;
console.log(a+'\t'+b+'\t'+c+'\t'+d+'\t'+e+'\t'+biggestOfFive(a, b, c, d, e));
a = 0; b = -2.5; c = 0; d = 5; e = 5;
console.log(a+'\t'+b+'\t'+c+'\t'+d+'\t'+e+'\t'+biggestOfFive(a, b, c, d, e));
a = -3; b = -0.5; c = -1.1; d = -2; e = -0.1;
console.log(a+'\t'+b+'\t'+c+'\t'+d+'\t'+e+'\t'+biggestOfFive(a, b, c, d, e));
