/*
 * Problem 4. Maximal increasing sequence
 * Write a script that finds the maximal increasing sequence in an array.
Example:
input 					result
3, 2, 3, 4, 2, 2, 4 	2, 3, 4
 */


var i, N = 10, len, arr = [], outarr = [], maxSeqArray = [];

function sequences(array) {
	var i, j, sequenceNumber, sequenceLength, result = [], len = array.length;

	for (i = 0, sequenceNumber = 0; i < len; sequenceNumber += 1) {
		sequenceLength = 1; // every array's element defines a sequence of length >= 1
		/*
		 * Get the length of current sequence of equal elements
		 */
		for (j = i + 1; j < len; j += 1) { // j = i+1, i+2, i+3, ...
			if ((+array[j]) === (+array[i]) + j-i) { // j-i = 1, 2, 3, ...
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

arr = [3, 2, 3, 4, 2, 2, 4];

outarr = sequences(arr);

maxSeqArray = maxSequence(outarr);

console.log('input\t|\tresult');
for (i = 0, len = maxSeqArray.length; i < len; i += 1) {
	console.log(arr.join(', ') + '\t|\t' + maxSeqArray[i].sequence.join(', '));
}
