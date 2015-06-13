/*
 * Problem 2. HTML binding
 * Write a function that puts the value of an object into the content/attributes of HTML tags.
 * Add the function to the String.prototype
Example 1:

input

	var str = '<div data-bind-content="name"></div>';
	str.bind(str, {name: 'Steven'});
output

	<div data-bind-content="name">Steven</div>
Example 2:

input

	var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
	str.bind(str, {name: 'Elena', link: 'http://telerikacademy.com'});
output

	<a data-bind-content="name" data-bind-href="link" data-bind-class="name" href="http://telerikacademy.com" class="Elena">Elena</а>
 */


// https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions
function escapeRegExp(string){
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}

String.prototype.bind = function(text, object) {
	var i, ii, result, attribute, attributes, content, element,
		dataBindTags, dataBindTagsLen,
		dataBindAttributes, dataBindAttributesLen;
	result = String(this) || text;

	// select all tags containing data-bind- attributes
	dataBindTags = result.match(/<([^>\s]+)[^>]+data\-bind\-[^>]+>.*?<\/\1>/g);
	for (i = 0, dataBindTagsLen = dataBindTags.length; i < dataBindTagsLen; i += 1) {
		element = dataBindTags[i];

		content = attributes = '';

		dataBindAttributes = dataBindTags[i].match(/\sdata-bind-[^=]+="[^<>"]*"/g);
		for (ii = 0, dataBindAttributesLen = dataBindAttributes.length; ii < dataBindAttributesLen; ii += 1) {
			attribute = dataBindAttributes[ii].replace(/\sdata-bind-/, '').split(/[="\s]+/g);
			// console.log(attribute); // [ 'content', 'name', '' ]
			switch (attribute[0]) {
				case 'content':
					if (object[attribute[1]] != null) {
						content = object[attribute[1]];
					}
					break;
				default:
					if (object[attribute[1]] != null) {
						attributes += " " + attribute[0] + '="' + object[attribute[1]] + '"';
					}
			}
		}

		// <a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>
		element = element.replace(/(?=>)/, attributes); // append new attributes
		element = element.replace(/>.*?(?=<\/)/, '>' + content); // add new content

		result = result.replace(new RegExp(escapeRegExp(dataBindTags[i]), 'g'), element);
	}
	return result;
}


var object = {name: 'Elena', link: 'http://telerikacademy.com'},
	bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a><div ></div><div data-bind-content="name"></div>';

console.log(bindingString);
console.log();
console.log(object);
console.log();
console.log(bindingString.bind(bindingString, object));
console.log();
console.log(''.bind(bindingString, object));
console.log();
console.log(bindingString.bind('', object));
