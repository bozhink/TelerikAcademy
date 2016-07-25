/* globals $ */

/* 

Create a function that takes an id or DOM selector and:
  

*/

function solve() {
    'use strict';
    function toggle(event) {
        var content, button;
        if (event.target.className === 'button') {
            for (content = button = event.target; content != null && content.className !== 'content'; content = content.nextElementSibling) {}

            if (content.style.display === '') {
                button.innerHTML = 'show';
                content.style.display = 'none';
            } else if (content.style.display === 'none') {
                button.innerHTML = 'hide';
                content.style.display = '';
            }
        }
    }
    
	return function (selector) {
		var id, i, len, myElement,
            buttons, root;

		if (selector == null || typeof (selector) !== 'string') {
			throw new Error('Invalid selector.');
		}

		myElement = selector;
		if (!(myElement instanceof HTMLElement)) {
			id = (selector[0] === "#") ? selector.substr(1) : selector;
			myElement = document.getElementById(id);
			if (myElement == null) {
				throw new Error('No such an element ' + selector);
			}
		}

        buttons = document.querySelectorAll('.button');
        for (i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
        }

        root = document.getElementById('root');
        if (root != null) {
            root.addEventListener('click', toggle, false);
        }
    };
}

module.exports = solve;