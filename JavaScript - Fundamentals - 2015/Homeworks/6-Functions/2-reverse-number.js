/*
 * Problem 2. Reverse number
 * Write a function that reverses the digits of given decimal number.
Example:
input 	output
256 	652
123.45 	54.321
 */

var n;

function reverseNumber(number) {
	var i, len, result = NaN, s = '' + number;

	if (!isNaN(number)) {
		result = '';
		for (i = 0, len = s.length; i < len; i += 1) {
			result += s[len - i - 1];
		}
		result = +result;
	}

	return result;
}

console.log('input\toutput');

n = 256;
console.log(n + '\t' + reverseNumber(n));

n = 123.45;
console.log(n + '\t' + reverseNumber(n));

n = '12309';
console.log(n + '\t' + reverseNumber(n));

n = '12309xyz';
console.log(n + '\t' + reverseNumber(n));
