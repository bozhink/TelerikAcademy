/*
 * Problem 7. First larger than neighbours
 * Write a function that returns the index of the first element
 *  in array that is larger than its neighbours or -1, if there’s no such element.
 * Use the function from the previous exercise.
 */

function largerThanNeighbours(array, position) {
	var result = NaN, // 0 = false, 1 = true, -1 = there is no two neighbours, NaN = position is NaN
		len = array.length,
		p = +position;
	if (!isNaN(p)) {
		if (p < 1 || p > len - 2) {
			result = -1;
		} else {
			if (array[p] > array[p-1] && array[p] > array[p+1]) {
				result = 1;
			} else {
				result = 0;
			}
		}
	}
	return result;
}

function firstLargerThanNeightbours(array) {
	var i, len, result = -1;
	for (i = 0, len = array.length; i < len; i += 1) {
		if (largerThanNeighbours(array, i) === 1) {
			result = i;
			break;
		}
	}

	return result;
}


function test() {
	var i, len, N, result, arr = [];

	len = 10; // length of test array
	N = 10; // Maximal number in the array

	// Populate the array arr with random numbers
	for (i = 0; i < len; i += 1) {
		arr[i] = (N*Math.random()) | 0;
	}

	console.log('array: [' + arr.join(', ') + ']');
	
	result = firstLargerThanNeightbours(arr);

	result = result > -1 ? result : 'there is no such element';
	console.log('position = ' + result + (isNaN(result) ? '' : '; value = ' + arr[result]));
}


test();
