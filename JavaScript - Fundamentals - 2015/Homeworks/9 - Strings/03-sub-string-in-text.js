/*
 * Problem 3. Sub-string in text
 * Write a JavaScript function that finds how many times a substring
 *   is contained in a given text (perform case insensitive search).
Example:

The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else.
 inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The result is: 9
 */

// https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions
function escapeRegExp(string){
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}

function countMatches(text, key) {
	var re = new RegExp(escapeRegExp(key), 'g');
	return text.match(re).length;
}

var key = 'in',
	text = 'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.';

console.log('The text is as follows: ' + text);
console.log('The result is: ' + countMatches(text, key));
