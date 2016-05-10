/*
 * Problem 2. Remove elements
 * Write a function that removes all elements with a given value.
 * Attach it to the array type.
 * Read about prototype and how to attach methods.
 *  var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
 *  arr.remove(1); //arr = [2,4,3,4,111,3,2,'1'];
 */

Array.prototype.remove = function(value) {
	var idx;
	for (idx = this.indexOf(value); idx > -1; idx = this.indexOf(value)) {
		this.splice(idx, 1);
	}
	return this;
};

function test() {
	var i, len, N, value, result, arr = [];

	len = 10; // length of test array
	N = 10; // Maximal number in the array
	value = (len*Math.random()) | 0; // number to be searched

	// Populate the array arr with random numbers
	for (i = 0; i < len; i += 1) {
		arr[i] = (N*Math.random()) | 0;
	}

	console.log('array: [' + arr.join(', ') + ']');
	console.log(value);
	console.log('array: [' + arr.remove(value).join(', ') + ']');

	console.log();


	arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
	value = 1;
	console.log('array: [' + arr.join(', ') + ']');
	console.log(value);
	console.log('array: [' + arr.remove(value).join(', ') + ']');
}


test();