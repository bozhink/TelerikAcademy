/*
 * Problem 11. String format
 * Write a function that formats a string using placeholders.
 * The function should work with up to 30 placeholders and all types.
Examples:

var str = stringFormat('Hello {0}!', 'Peter'); 
//str = 'Hello Peter!';

var frmt = '{0}, {1}, {0} text {2}';
var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
//str = '1, Pesho, 1 text Gosho'
 */

// https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions
function escapeRegExp(string){
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}

function stringFormat(pattern) {
	var argc, i, re, arr, idx, len, result, argv = [].slice.apply(arguments);
	argc = argv.length;
	switch (argc) {
		case 0:
			break;
		case 1:
			result = pattern;
			break;
		default:
			result = pattern;
			arr = pattern.match(/\{\d+\}/g);
			for (i = 0, len = arr.length; i < len; i += 1) {
				idx = (+arr[i].match(/\d+/)[0]) + 1;
				if (idx > 31) {
					continue;
				}
				if (argv[idx] != null) {
					re = new RegExp(escapeRegExp(arr[i]), 'g');
					result = result.replace(re, argv[idx]);
				}
			}
	}
	return result;
}

console.log(stringFormat());
console.log(stringFormat('Hello {0}!'));
console.log(stringFormat('Hello {0}!', 'Peter'));
console.log(stringFormat('{0}, {1}, {0} text {2}', 1, 'Pesho', 'Gosho'));
console.log(stringFormat('{0}, {1}, {0} text {2} {3}', 1, 'Pesho', 'Gosho'));
