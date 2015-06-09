/*
 * Problem 1. Reverse string
 * Write a JavaScript function that reverses a string and returns it.
Example:
input	output
sample	elpmas
 */

var text;

function reverseString(string) {
	return Array.prototype.map.call(string, function (x) {
		return x;
	}).reverse().join('');
}


console.log('input\toutput');
text = 'sample';
console.log(text + '\t' + reverseString(text));
