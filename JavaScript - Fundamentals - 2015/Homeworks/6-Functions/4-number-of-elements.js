/*
 * Problem 4. Number of elements
 * Write a function to count the number of div elements on the web page
 */

function numberOfElements(elementName) {
	var elements = document.getElementsByTagName('' + elementName);
	return elements.length;
}

console.log(numberOfElements('div'));

