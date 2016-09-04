/*
 * Task 3. _ClickON_TheButton in JavaScript
 * Refactor the following examples to produce code with well-named identifiers in JavaScript
*/
function isFirefoxButtonEventHandler(event, arguments) {
    var thisWindow = window,
        thisBrowser = thisWindow.navigator.appCodeName,
        isMozilla = thisBrowser === 'Mozilla';
    if (isMozilla) {
        alert('Yes');
    } else {
        alert('No');
    }
}
