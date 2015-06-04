/*
 * Problem 6. Most frequent number
 * Write a script that finds the most frequent number in an array. 
Example:
input 									result
4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 	4 (5 times)
 */

var i, arr = [], outarr = [];

function sequences(array) {
	var i, j, sequenceNumber, sequenceLength, result = [], len = array.length;
	for (i = 0, sequenceNumber = 0; i < len; sequenceNumber += 1) {
		sequenceLength = 1; // every array's element defines a sequence of length >= 1
		/*
		 * Get the length of current sequence of equal elements
		 */
		for (j = i + 1; j < len; j += 1) {
			if (array[j] === array[i]) {
				sequenceLength += 1;
			} else {
				break;
			}
		}
		/*
		 * Register parameters of current sequence
		 */
		result[sequenceNumber] = [];
		result[sequenceNumber]['index'] = i; // Starting position of the sequence in array
		result[sequenceNumber]['len'] = sequenceLength; // The length of current sequence
		result[sequenceNumber]['sequence'] = array.slice(i, i + sequenceLength); // Current sequence

		/*
		 * Skip in the ‘i’-loop next elements of the current sequence
		 */
		i += sequenceLength;
	}

	return result;
}

function maxSequence(sequences) {
	var i, maxLength, result = [], len = sequences.length;
	/*
	 * First: find the maximal length of sequence
	 */
	maxLength = sequences[0].len;
	for (i = 1; i < len; i += 1) {
		if (maxLength < sequences[i].len) {
			maxLength = sequences[i].len;
		}
	}
	/*
	 * Next: get the list of all sequences of length maxLength
	 */
	for (i = 0; i < len; i += 1) {
		if (sequences[i].len === maxLength) {
			result.push(sequences[i]);
		}
	}
	return result;
}

function frequencyDistribution(array) {
	var result = array.slice(0);
	result = maxSequence(sequences(result.sort()));
	return result;
}

arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
//arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, 1, 1];
for (i = 0; i < 15; i += 1) {
	arr[i] = (Math.random() * 10) | 0;
}

outarr = frequencyDistribution(arr);

console.log('input\t|\tresult');
for (i = 0, len = outarr.length; i < len; i += 1) {
	console.log(arr.join(', ') + '\t|\t' + outarr[i].sequence[0] + ' (' + outarr[i].len + ' times)');
}
