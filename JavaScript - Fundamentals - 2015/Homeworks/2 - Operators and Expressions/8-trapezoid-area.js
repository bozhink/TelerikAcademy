/*
 * Problem 8. Trapezoid area
 * Write an expression that calculates trapezoid's area by given sides a and b and height h.
 */

var i, n;

function trapezoidArea(a, b, h) {
	return 0.5*(a+b)*h;
}

console.log('a\tb\th\tarea');
a = 5; b = 7; h = 12;
console.log(a + '\t' + b + '\t' + h + '\t' + trapezoidArea(a, b, h));

a = 2; b = 1; h = 33;
console.log(a + '\t' + b + '\t' + h + '\t' + trapezoidArea(a, b, h));

a = 8.5; b = 4.3; h = 2.7;
console.log(a + '\t' + b + '\t' + h + '\t' + trapezoidArea(a, b, h));

a = 100; b = 200; h = 300;
console.log(a + '\t' + b + '\t' + h + '\t' + trapezoidArea(a, b, h));

a = 0.222; b = 0.333; h = 0.555;
console.log(a + '\t' + b + '\t' + h + '\t' + trapezoidArea(a, b, h));
