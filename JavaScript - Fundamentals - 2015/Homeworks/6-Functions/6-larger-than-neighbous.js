/*
 * Problem 6. Larger than neighbours
 * Write a function that checks if the element at given
 *  position in given array of integers is bigger than
 *  its two neighbours (when such exist).
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


function test() {
	var i, len, N, position, result, arr = [];

	len = 10; // length of test array
	N = 10; // Maximal number in the array
	position = (len*Math.random()) | 0; // number to be searched

	// Populate the array arr with random numbers
	for (i = 0; i < len; i += 1) {
		arr[i] = (N*Math.random()) | 0;
	}

	console.log('array: [' + arr.join(', ') + ']');
	switch (largerThanNeighbours(arr, position)) {
		case 1:
			result = 'yes';
			break;
		case 0:
			result = 'no';
			break;
		case -1:
			result = 'there is no enough neighbours';
			break;
		default:
			result = 'invalid parameters';
	}
	console.log('position = ' + position + '; is larger = ' + result);
}


test();
