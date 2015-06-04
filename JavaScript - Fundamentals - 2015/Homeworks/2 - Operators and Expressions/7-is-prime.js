/*
 * Problem 7. Is prime
 * Write an expression that checks if given positive integer number n (n ≤ 100) is prime.
 */

var n;

function isPrime(n) {
	var i,
	    result = true,
	    sqrtN = Math.sqrt(Math.abs(n));
	if (((n | 0) != n) || (n*1 < 2)) { // if n is not an integer or n < 1
		result = false;
	} else {
		for (i = 2; i <= sqrtN; i+=1) {
			if (n % i === 0) {
				result = false;
				break;
			}
		}
	}
	return result;
}

console.log('n\tPrime?');
n = 1;
console.log(n + '\t' + isPrime(n));
n = 2;
console.log(n + '\t' + isPrime(n));
n = 3;
console.log(n + '\t' + isPrime(n));
n = 4;
console.log(n + '\t' + isPrime(n));
n = 9;
console.log(n + '\t' + isPrime(n));
n = 37;
console.log(n + '\t' + isPrime(n));
n = 97;
console.log(n + '\t' + isPrime(n));
n = 51;
console.log(n + '\t' + isPrime(n));
n = -3;
console.log(n + '\t' + isPrime(n));
n = 0;
console.log(n + '\t' + isPrime(n));
