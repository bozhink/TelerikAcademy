/*
 * Problem 6. Point in Circle
 * Write an expression that checks if given point P(x, y)
 * is within a circle K({0,0}, 5). //{0,0} is the centre and 5 is the radius
 */

var P = { x: 0, y: 0 }, R = 5;

function isInCircle(point, circleRadius) {
	var distance = Math.sqrt(point.x*point.x + point.y*point.y);
	return distance <= circleRadius;
}

console.log('x\ty\tinside');

P.x = 0; P.y = 1;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = -5; P.y = 0;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = -4; P.y = 5;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 1.5; P.y = -3;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = -4; P.y = -3.5;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 100; P.y = -30;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 0; P.y = 0;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 0.2; P.y = -0.8;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 0.9; P.y = -4.93;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));

P.x = 2; P.y = 2.655;
console.log(P.x + '\t' + P.y + '\t' + isInCircle(P, R));
