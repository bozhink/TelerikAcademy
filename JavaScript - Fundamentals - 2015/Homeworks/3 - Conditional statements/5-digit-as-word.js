/*
 * Problem 5. Digit as word
 * Write a script that asks for a digit (0-9),
 *   and depending on the input, shows the digit
 *   as a word (in English).
 * Print “not a digit” in case of invalid input.
 * Use a switch statement.
 */

var x;

function digitAsWord(digit) {
	var word = 'not a digit';
	if (!isNaN(digit)) {
		switch (+digit) {
			case 0: word = 'zero'; break;
			case 1: word = 'one'; break;
			case 2: word = 'two'; break;
			case 3: word = 'three'; break;
			case 4: word = 'four'; break;
			case 5: word = 'five'; break;
			case 6: word = 'six'; break;
			case 7: word = 'seven'; break;
			case 8: word = 'eight'; break;
			case 9: word = 'nine'; break;
			//default: word = 'not a digit'; // useless due to initialization
		}
	}
	return word;
}

console.log('digit\tresult');
x = 2;
console.log(x + '\t' + digitAsWord(x));
x = 1;
console.log(x + '\t' + digitAsWord(x));
x = 0;
console.log(x + '\t' + digitAsWord(x));
x = 5;
console.log(x + '\t' + digitAsWord(x));
x = -0.1;
console.log(x + '\t' + digitAsWord(x));
x = 'hi';
console.log(x + '\t' + digitAsWord(x));
x = 9;
console.log(x + '\t' + digitAsWord(x));
x = 10;
console.log(x + '\t' + digitAsWord(x));
