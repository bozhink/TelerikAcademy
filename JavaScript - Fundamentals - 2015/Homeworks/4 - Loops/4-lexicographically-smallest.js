/*
 * Problem 4. Lexicographically smallest
 * Write a script that finds the lexicographically smallest
 *   and largest property in document, window and navigator objects.
 */

function minMaxProperty (object) {
	var min, max, property;
	for (property in object) {
		min = !min ? property : ((property < min) ? property : min);
		max = !max ? property : ((property > max) ? property : max);
	}
	console.log('min = ' + min + '; max = ' + max);
}

console.log('document');
minMaxProperty(document);

console.log('window');
minMaxProperty (window);

console.log('navigator');
minMaxProperty(navigator);
