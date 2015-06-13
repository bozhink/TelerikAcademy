/*
 * Problem 2. Correct brackets
 * Write a JavaScript function to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
 */

function correctBrackets(text) {
	var i, len, ch, result = '', stack = [];
	text = String(text);

	for (i = 0, len = text.length; i < len; i += 1) {
		ch = text[i];
		switch (ch) {
			case ')':
				if (stack[stack.length - 1] === '(') {
					stack.pop();
					result += ch;
				} else { // stack[stack.length - 1] === ')'
					stack.push('(');
					result += '(';
				}
				break;
			case '(':
				stack.push(ch);
			default:
				result += ch;
		}
	}

	return result;
}

var text = '((a+b)/5-d) dflkgj;sdf hg;sdhfkg()()()()))))((())) )(a+b))';

console.log(text);
console.log();
console.log(correctBrackets(text));
