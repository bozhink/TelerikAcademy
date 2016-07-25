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
    var el, i, len, item, div;

    function isString(param) {
      return param.toString() === param;
    }

    function isNumber(param) {
      return !isNaN(parseFloat(param));
    }

    function isDOMElement(param) {
      return param instanceof HTMLElement;
    }

    if (!element) {
      throw 'Element or selsector is null.';
    }

    if (!isString(element) && !isDOMElement(element)) {
      throw 'Element should be string or valid DOM element.';
    }

    if (!contents || !Array.isArray(contents)) {
      throw 'Contents array is missing or invalid.';
    }

    for (i = 0, len = contents.length; i < len; i += 1) {
      item = contents[i];
      if (!isString(item) && !isNumber(item)) {
        throw 'Content ' + item.toString() + ' is not string nor number.';
      }
    }

    if (isDOMElement(element)) {
      el = element || null;
    } else {
      el = document.getElementById(element) || null;
    }

    if (!el) {
      throw 'Invalid selector or element';
    }

    if (!isDOMElement(el)) {
      throw 'Selected element is not a valid DOM element.';
    }

    el.innerHTML = '';
    for (i = 0, len = contents.length; i < len; i += 1) {
      item = contents[i];
      div = document.createElement('div');
      div.innerHTML = item;
      el.appendChild(div);
    }
  };
};