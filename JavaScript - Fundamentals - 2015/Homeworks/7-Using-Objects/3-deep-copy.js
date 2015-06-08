/*
 * Problem 3. Deep copy
 * Write a function that makes a deep copy of an object.
 * The function should work for both primitive and reference types.
 */

function deepCopy(object) {
	var prop, result = {};
	for (prop in object) {
		if (typeof object[prop] === "object") {
			result[prop] = object[prop];
			deepCopy(object[prop]);
		} else {
			result[prop] = object[prop];
		}
	}
	return result;
}

var console1 = deepCopy(console);

console.log(console);
console.log(console1);
