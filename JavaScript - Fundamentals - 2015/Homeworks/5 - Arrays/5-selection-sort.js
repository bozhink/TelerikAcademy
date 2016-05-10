/*
 * Problem 5. Selection sort
 * Sorting an array means to arrange its elements in increasing order.
 * Write a script to sort an array.
 * Use the selection sort algorithm: Find the smallest element,
 *   move it at the first position, find the smallest from the
 *   rest, move it at the second position, etc.
 * Hint: Use a second array
 */

 var i, arr = [], arr1 = [], N = 15;

function selSort(array) {
	var i, j, iMin, temp, len = array.length, a = [];
	a = array.slice(0);
	for (j = 0; j < len - 1; j += 1) {
		iMin = j;
		for (i = j+1; i < len; i += 1) {
			iMin = (a[i] < a[iMin]) ? i : iMin;
		}

		if (iMin != j) {
			temp = a[j];
			a[j] = a[iMin];
			a[iMin] = temp;
		}
	}
	return a;
}

for (i = 0; i < N; i += 1) {
	arr[i] = (10*Math.random()) | 0;
}

console.log(arr.join(' '));

arr1 = selSort(arr);

console.log(arr1.join(' '));
