/*
 * Problem 1. English digit
 * Write a function that returns the last digit of given integer as an English word.
Examples:
input 	output
512 	two
1024 	four
12309 	nine
 */

var n;

function englishDigit(number) {
	var result = NaN, s = '' + number;
	if (!isNaN(number)) {
		switch(s[s.length-1]) {
			case '0':
				result = 'zero';
				break;
			case '1':
				result = 'one';
				break;
			case '2':
				result = 'two';
				break;
			case '3':
				result = 'three';
				break;
			case '4':
				result = 'four';
				break;
			case '5':
				result = 'five';
				break;
			case '6':
				result = 'six';
				break
			case '7':
				result = 'seven';
				break;
			case '8':
				result = 'eight';
				break;
			case '9':
				result = 'nine';
				break;
			default:
				result = NaN;
		}
	}

	return result;
}

console.log('input\toutput');

n = 512;
console.log(n + '\t' + englishDigit(n));

n = 1024;
console.log(n + '\t' + englishDigit(n));

n = 12309;
console.log(n + '\t' + englishDigit(n));
