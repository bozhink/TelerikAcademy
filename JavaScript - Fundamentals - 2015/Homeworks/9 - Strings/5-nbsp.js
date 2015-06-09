/*
 * Problem 5. nbsp
 * Write a function that replaces non breaking white-spaces in a text with &nbsp;
 * 'a                l'
 */

var text;

function toNbsp(text) {
	return text.replace(/ /g, '&nbsp;');
}

text = 'a     ds   ds dsds        l';
console.log(text);
console.log(toNbsp(text));
