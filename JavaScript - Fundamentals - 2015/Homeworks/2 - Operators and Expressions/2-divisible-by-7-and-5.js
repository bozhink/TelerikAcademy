/*
 * Problem 2. Divisible by 7 and 5
 * Write a boolean expression that checks for given integer
 * if it can be divided (without remainder) by 7 and 5 in the same time.
 */

var i, n;

function divisibleBy7And5(n) {
	return (n % 7  === 0) && (n % 5 === 0);
}

console.log(' n\tDivided by 7 and 5?');
for (i=0; i<20; i+=1) {
	n = (Math.random()*300) | 0;
	console.log(n + '\t' + divisibleBy7And5(n));
}
