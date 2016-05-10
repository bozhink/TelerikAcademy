/*
 * Problem 3. Rectangle area
 * Write an expression that calculates rectangle’s area by given width and height.
 */

var a, b;

function rectArea(width, height) {
	return width * height;
}

console.log('width\theight\tarea');
a = 3;
b = 4;
console.log(a + '\t' + b + '\t' + rectArea(a,b));
a = 2.5;
b = 3;
console.log(a + '\t' + b + '\t' + rectArea(a,b));
a = 5;
b = 5;
console.log(a + '\t' + b + '\t' + rectArea(a,b));
