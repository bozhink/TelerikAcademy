/*
 * Problem 2. Numbers not divisible
 * Write a script that prints all the numbers from 1 to N,
 *   that are not divisible by 3 and 7 at the same time.
 */

var N = 50;

function notDivisibleBy3And7(n) {
	var i;
	for (i = 1; i <= n; i+=1) {
		if ( !(!(i % 3) && !(i % 7)) ) {
			console.log(i);
		}
	}
}

notDivisibleBy3And7(N);

