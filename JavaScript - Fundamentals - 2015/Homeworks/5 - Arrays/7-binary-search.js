/*
 * Problem 7. Binary search
 * Write a script that finds the index of given element
 *   in a sorted array of integers by using the binary
 *   search algorithm.
 */

var L = [1, 3, 4, 6, 8, 9, 11],
	X = 4;

function binarySearch(array, key, left, right) {
	var i, imid, imin, imax,
		result = NaN,
		len = array.length;
	// continue searching while [imin,imax] is not empty
	for (imin = left, imax = right, imid = ((left + right) / 2) | 0; imax >= imin; imid = ((imin + imax) / 2) | 0) {
		// calculate the midpoint for roughly equal partition
		if(array[imid] === key) { // key found at index imid
			result = imid;
			break;
		} else if (array[imid] < key) { // change min index to search upper subarray
			imin = imid + 1;
		} else { // change max index to search lower subarray
			imax = imid - 1;
		}
	}
	return result;
}

console.log('array = ' + L.join(', '));
console.log('key = ' + X);
console.log('position = ' + binarySearch(L, X, 0, L.length-1));
