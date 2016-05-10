/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {
    return function (selector, count) {
        var i, $ul;
        
        if (selector == null || typeof (selector) !== 'string') {
			throw new Error('Invalid selector.');
		}
        
        if (count == null || isNaN(count) || 1 > (count = +count) ) {
            throw new Error('Invalid count.');
        }
        
        $ul = $('<ul />').addClass('items-list');
        for (i = 0; i < count; i += 1) {
            $('<li>List item #' + i + '</li>').addClass('list-item').appendTo($ul);
        }
        
        $(selector).append($ul);
    };
};

module.exports = solve;