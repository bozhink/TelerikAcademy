/*
 * Problem 4. Has property
 * Write a function that checks if a given object contains a given property.
var obj  = …;
var hasProp = hasProperty(obj, 'length');
 */

function hasProperty(object, property) {
	var result, prop;
	for (prop in object) {
		if (prop === property) {
			result = true;
		}
	}
	return !!result;
}


console.log(hasProperty(console, 'log'));
console.log(hasProperty(console, 'stdout'));
