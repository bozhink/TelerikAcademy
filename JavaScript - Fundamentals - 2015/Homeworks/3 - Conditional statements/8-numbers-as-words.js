/*
 * Problem 8. Number as words
 * Write a script that converts a number in the range [0…999]
 *   to words, corresponding to its English pronunciation.
 */

var n;

function oneDigitAsWord(digit1) {
	var word = 'not a number';
	if (!isNaN(digit1) ? (''+digit1).length === 1 : false) {
		switch (+digit1) {
			case 0: word = 'Zero'; break;
			case 1: word = 'One'; break;
			case 2: word = 'Two'; break;
			case 3: word = 'Three'; break;
			case 4: word = 'Four'; break;
			case 5: word = 'Five'; break;
			case 6: word = 'Six'; break;
			case 7: word = 'Seven'; break;
			case 8: word = 'Eight'; break;
			case 9: word = 'Nine'; break;
			default: word = 'not a number';
		}
	}
	return word;
}

function twoDigitsAsWord(digit1, digit2) {
	// two-digit number must be <digit1>[<digit2>]
	var word = 'not a number';
	if (!isNaN(digit1) ? (''+digit1).length === 1 : false) {
		if (isNaN(digit2) ? true : (''+digit2).length != 1) { // 1-digit number
			word = oneDigitAsWord(digit1);
		} else { // digit2 is number and its length is equal to 1
			switch (+digit1) {
				case 0:
					word = (+digit2) ? oneDigitAsWord(digit2) : '';
					break;
				case 1:
					switch (+digit2) {
						case 0: word = 'Ten'; break;
						case 1: word = 'Eleven'; break;
						case 2: word = 'Twelve'; break;
						case 3: word = 'Thirteen'; break;
						case 4: word = 'Fourteen'; break;
						case 5: word = 'Fifteen'; break;
						case 6: word = 'Sixteen'; break;
						case 7: word = 'Seventeen'; break;
						case 8: word = 'Eighteen'; break;
						case 9: word = 'Nineteen'; break;
						default: word = 'not a number';
					}
					break;
				case 2:
					word = 'Twenty' + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 3:
					word = "Thirty" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 4:
					word = "Forty" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 5:
					word = "Fifty" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 6:
					word = "Sixty" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 7:
					word = "Seventy" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 8:
					word = "Eighty" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
				case 9:
					word = "Ninety" + ((+digit2) ? ' ' + oneDigitAsWord(digit2).toLowerCase() : '');
					break;
			}
		}
	}
	return word;
}

function numberAsWord(number) {
	var words = 'not a Number',
	    digit1, digit2, digit3,
	    strnumber = (''+number), len = strnumber.length;
	if (!isNaN(number)) {
		if (len > 3 || (+number < 0)) {
			words = 'number must be in range [0…999]';
		} else {
			digit1 = strnumber[0];
			digit2 = strnumber[1];
			digit3 = strnumber[2];
			if (len < 2) {
				words = oneDigitAsWord(digit1);
			} else if (len < 3) {
				words = twoDigitsAsWord(digit1, digit2);
			} else if (!isNaN(digit1) && !isNaN(digit2) && !isNaN(digit3)) {
				switch (+digit1) {
					case 0:
						words = twoDigitsAsWord(digit2, digit3);
						break;
					default:
						words = oneDigitAsWord(digit1) +' hundred' +
						  ((digit2+digit3 == 0) ? '' : ' and '+twoDigitsAsWord(digit2, digit3).toLowerCase());
				}
			}
		}
	}
	return words;
}

console.log('numbers\tnumber as words');
n = 0;
console.log(n + '\t' + numberAsWord(n));
n = 9;
console.log(n + '\t' + numberAsWord(n));
n = 10;
console.log(n + '\t' + numberAsWord(n));
n = 12;
console.log(n + '\t' + numberAsWord(n));
n = 19;
console.log(n + '\t' + numberAsWord(n));
n = 25;
console.log(n + '\t' + numberAsWord(n));
n = 98;
console.log(n + '\t' + numberAsWord(n));
n = 98;
console.log(n + '\t' + numberAsWord(n));
n = 273;
console.log(n + '\t' + numberAsWord(n));
n = 400;
console.log(n + '\t' + numberAsWord(n));
n = 501;
console.log(n + '\t' + numberAsWord(n));
n = 617;
console.log(n + '\t' + numberAsWord(n));
n = 711;
console.log(n + '\t' + numberAsWord(n));
n = 999;
console.log(n + '\t' + numberAsWord(n));
n = 1999;
console.log(n + '\t' + numberAsWord(n));
