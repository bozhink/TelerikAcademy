/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {
	return function (element, contents) {
		var id, i, len, type, myElement, htmlContent;

		// Check for missing parameters
		if (element == null || contents == null) {
			throw new Error('Input parameters are obligatiry.');
		}

		// Check for invalid parameters' type
		if (typeof(element) !== 'string' && !Array.isArray(contents)) {
			throw new Error('Id must be a string and contents must be an array');
		}

		// Check for validity of contents array
		for (i = 0, len = contents.length; i < len; i += 1) {
			type = typeof(contents[i]);
			if (type !== 'number' && type !== 'string') {
				throw new Error('Elements of contents must be numbers or strings' + ' '+  type + ' ' + contents[i]);
			}
		}

		myElement = element;
		if (!(myElement instanceof HTMLElement)) {
			id = (element[0] === "#") ? element.substr(1) : element;
			myElement = document.getElementById(id);
			if (myElement == null/* || !((myElement = element) instanceof HTMLCollection)*/) {
				throw new Error('No such an element ' + element);
			}
		}

		for (i = 0, len = contents.length, htmlContent = ''; i < len; i += 1) {
			htmlContent += '<div>' + contents[i] + '</div>';
		}

		// Overwrite all the previous content of the DOM element
		myElement.innerHTML = htmlContent;
	};
};