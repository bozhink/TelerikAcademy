/*
 * Problem 5. Appearance count
 * Write a function that counts how many times given number appears in given array.
 * Write a test function to check if the function is working correctly.
 */

function appearanceCount(array, number) {
	var i, len, result;

	for (i = 0, result = 0, len = array.length; i < len; i += 1) {
		if (array[i] == number) {
			result += 1;
		}
	}

	return result;
}

function test() {
	var i, len, N, key, arr = [];

	len = 20; // length of test array
	N = 10; // Maximal number in the array
	key = 2; // number to be searched

	// Populate the array arr with random numbers
	for (i = 0; i < len; i += 1) {
		arr[i] = (N*Math.random()) | 0;
	}

	console.log('array: [' + arr.join(', ') + ']');
	console.log('key = ' + key + '; appearance count = ' + appearanceCount(arr, key));
}


test();
