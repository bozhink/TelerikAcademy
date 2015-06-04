/*
 * Problem 4. Third digit
 * Write an expression that checks for given integer if its third digit (right-to-left) is 7.
 */

var n, rtlnth = 3, check = 7;

/*
 * nthSymbol = get n-th symbol of an input string
 * input = input string
 * rtlNth = right-to-left position of required symbol (non-zero-based)
 * checkValue = required value of the n-th symbol
 */
function nthSymbol(input, rtlNth, checkValue) {
	var inputString = '' + input,
	    inputLen = inputString.length,
	    rtlSym, // right-to-left nth symbol
	    nth = rtlNth | 0, // verify that rtlNth must be a number
	    result = false; // returned value;
	if (nth > 0 && inputLen >= nth) {
		rtlSym = inputString[inputLen - nth];
		result = rtlSym === ('' + checkValue)[0];
	}
	return result;
}

console.log("n\tThird digit 7?");
n = 5;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 701;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 1732;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 9703;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 877;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 777877;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));
n = 9999799;
console.log(n + '\t' + nthSymbol(n, rtlnth, check));