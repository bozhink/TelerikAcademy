/*
 * Problem 1. Odd or Even
 * Write an expression that checks if given integer is odd or even.
 */

var i, n;

function isOdd(n) {
	return !(n % 2 === 0);
}

console.log(' n\tOdd?');
for (i=0; i<20; i+=1) {
	n = (Math.random()*100) | 0 - 50;
	console.log(n + '\t' + isOdd(n));
}
