/*
 * Problem 9. Point in Circle and outside Rectangle
 * Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3)
 * and out of the rectangle R(top=1, left=-1, width=6, height=2).
 */

var circle = { x: 1, y: 1, radius: 3 },
    rectangle = { top: 1, left: -1, width: 6, height: 2 },
    P = { x: 0, y: 0 };

function isInCircle(point, circle) {
	var x = point.x - circle.x, y = point.y - circle.y;
	return Math.sqrt(x*x + y*y) <= circle.radius;
}

function isInRectangle(point, rectangle) {
	var result = false;
	if (point.y <= rectangle.top && point.y >= rectangle.top - rectangle.height &&
		point.x >= rectangle.left && point.x <= rectangle.left + rectangle.width) {
		result = true;
	}
	return result;
}

function isInCircleOutRectagle(point, circleRadius, rectangle) {
	var isIn = isInCircle(point, circleRadius) && !isInRectangle(point, rectangle);
	return isIn ? 'yes' : 'no';
}

console.log('x\ty\tinside K & outside of R');
P.x = 1; P.y = 4;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 3; P.y = 2;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 0; P.y = 1;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 4; P.y = 1;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 2; P.y = 0;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 4; P.y = 0;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 2.5; P.y = 1.5;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = 3.5; P.y = 1.5;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));
P.x = -100; P.y = -100;
console.log(P.x + '\t' + P.y + '\t' + isInCircleOutRectagle(P, circle, rectangle));


