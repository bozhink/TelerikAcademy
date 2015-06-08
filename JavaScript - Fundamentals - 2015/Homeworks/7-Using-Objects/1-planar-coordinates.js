/*
 * Problem 1. Planar coordinates
 * Write functions for working with shapes in standard Planar coordinate system.
 *   Points are represented by coordinates P(X, Y)
 *   Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
 * Calculate the distance between two points.
 * Check if three segment lines can form a triangle.
 */

function distance() {
	var p1, p2, X, Y,
		args = [].slice.apply(arguments),
		len = args.length,
		result = 0;
	switch (len) {
		case 0: // no parameters
			break;
		case 1: // 1 parameter --> should be line
			p1 = args[0].P1;
			p2 = args[0].P2;
			if (p1 != null && p2 != null) {
				result = distance(p1, p2);
			}
			break;
		default:
			p1 = args[0];
			p2 = args[1];
			if (p1 != null && p2 != null) {
				X = p1.X - p2.X;
				Y = p1.Y - p2.Y;
				if (X != null && Y != null) {
					result = Math.sqrt(X*X + Y*Y);
				}
			}
	}
	return result;
}

function checkThreeSegments(L1, L2, L3) {
	var result,
		d1 = distance(L1),
		d2 = distance(L2),
		d3 = distance(L3);
	result = (d1 + d2 > d3) && (d2 + d3 > d1) && (d3 + d1 > d2);
	return result;
}

var P1 = {X: 0, Y: 0},
	P2 = {X: 1, Y: 1},
	P3 = {X: 1, Y: 0},
	L = {P1: P1, P2: P2},
	L1 = {P1: P1, P2: P3},
	L2 = {P1: P3, P2: P2};

console.log(distance());
console.log(distance(P1));
console.log(distance(P2));
console.log(distance(P1, P2));
console.log(distance(P1, P3));
console.log(distance(L));
console.log(distance(L1));
console.log(distance(L2));
console.log();
console.log(checkThreeSegments(L, L1, L2));
console.log(checkThreeSegments(L1, L, L2));
console.log(checkThreeSegments(L2, L1, L));
