/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
    function toggle() {
        var $content,
            $button = $(this),
            $next = $button.next(),
            isValid = false;

        while ($next) {
            if ($next.hasClass('content')) {
                $content = $next;
                for ($next = $next.next(); $next; $next = $next.next()) {
                    if ($next.hasClass('button')) {
                        isValid = true;
                        break;
                    }
                }

                break;
            } else {
                $next = $next.next();
            }
        }
        
        if (isValid) {
            if ($content.css('display') === 'none') {
                $button.text('hide');
                $content.css('display', '');
            } else {
                $button.text('show');
                $content.css('display', 'none');
            }
        }
    }

    return function (selector) {
        var $myElement,
            $buttons = $('.button');

        if (selector == null || (typeof (selector) !== 'string' /*&& selector.jquery != null*/ )) {
            throw new Error('Invalid selector.');
        }

        $myElement = $(selector);
        if ($myElement.length < 1 || $myElement == null) {
            throw new Error('No such an element ' + selector);
        }

        $buttons.text('hide');
        $buttons.parent().on('click', '.button', toggle);
    };
}

module.exports = solve;