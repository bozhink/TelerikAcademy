/*
 * Problem 3. Maximal sequence
 * Write a script that finds the maximal sequence
 *  of equal elements in an array.
Example:
input							result
2, 1, 1, 2, 3, 3, 2, 2, 2, 1 	2, 2, 2
 */

var i, N = 10, len, arr = [], outarr = [], maxSeqArray = [];

function sequences(array) {
	var i, j, sequenceNumber, sequenceLength, result = [], len = array.length;

	sequenceNumber = 0;
	for (i = 0; i < len; /* Do not increment here */) {
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
		 * Increment the sequence number
		 */
		sequenceNumber += 1;

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

/*for (i = 0; i < N; i += 1) {
	arr[i] = (Math.random() * 10) | 0;
}*/

arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

// console.log(arr.join(', '));

outarr = sequences(arr);

// console.log(outarr);

maxSeqArray = maxSequence(outarr);

// console.log(maxSeqArray);

console.log('input\t|\tresult');
for (i = 0, len = maxSeqArray.length; i < len; i += 1) {
	console.log(arr.join(', ') + '\t|\t' + maxSeqArray[i].sequence.join(', '));
}
