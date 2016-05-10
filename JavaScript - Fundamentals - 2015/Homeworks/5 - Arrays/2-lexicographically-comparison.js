/*
 * Problem 2. Lexicographically comparison
 * Write a script that compares two char arrays
 *  lexicographically (letter by letter).
 */

/*
 * This min looks cooler than Math.min:
 * min(x, y) = y ^ ((x ^ y) & -(x < y))
 */

var compare, str1, str2, arr1 = [], arr2 = [];

function lexCompare(array1, array2) {
	var i, len, result = 0,
		len1 = array1.length,
		len2 = array2.length;

	for (i = 0, len = len2 ^ ((len1 ^ len2) & -(len1 < len2)); i < len; i += 1) {
		if (array1[i] !== array2[i]) {
			result = array1[i] < array2[i] ? -(i+1) : (i+1); // i+1 because we connot distinct the case i=0: -0 === 0
			break;
		}
	}

	if ((len1 !== len2) && isNaN(result)) {
		result = len1 < len2 ? -(len1+1) : (len2+1); // +1 see above
	}

	return result; // result === 0 if arrays are equal
}

str1 = 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod';
str2 = 'tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam';
// str2 = str1;


arr1 = str1.split(/(?=.)/);
arr2 = str2.split(/(?=.)/);

compare = lexCompare(arr1, arr2);

console.log(
	'["' + arr1.join('') + '"]' +
	(compare === 0 ? ' is equal to ' : (compare < 0 ? ' follows ' : ' precedes ')) + 
	'["' + arr2.join('') + '"]'
);
