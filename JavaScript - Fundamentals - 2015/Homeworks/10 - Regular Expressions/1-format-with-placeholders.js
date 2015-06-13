/*
 * Problem 1. Format with placeholders
 * Write a function that formats a string. The function should have placeholders, as shown in the example
 *  Add the function to the String.prototype
Example:

input	output
var options = {name: 'John'};
'Hello, there! Are you #{name}?'.format(options);	'Hello, there! Are you John'
var options = {name: 'John', age: 13};
'My name is #{name} and I am #{age}-years-old').format(options);	'My name is John and I am 13-years-old'
 */

// https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions
function escapeRegExp(string){
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}

String.prototype.format = function(options) {
	var prop, result, re;
	result = String(this);
	for (prop in options) {
		re = new RegExp(escapeRegExp('#{' + prop + '}'), 'g');
		result = result.replace(re, options[prop]);
	}
	return result;
}

var options;

options = {name: 'John'};
console.log('Hello, there! Are you #{name}?'.format(options));

options = {name: 'John', age: 13};
console.log('My name is #{name} and I am #{age}-years-old'.format(options));
