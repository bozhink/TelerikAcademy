/*
 * Problem 5. Third bit
 * Write a boolean expression for finding if the bit #3 (counting from 0) of a given integer.
 * The bits are counted from right to left, starting from bit #0.
 * The result of the expression should be either 1 or 0.
 */

var n, numberOfDigits = 16;

function getThirdBit(n) {
	var result = 0;
	if (!isNaN(n)) {
		result = (n & 8) >> 3; // 8 = 0b1000
	}
	return result;
}

function getBinaryRepresentation(input, numberOfDigits) {
	var binInput = input.toString(2),
	    binInputLen = binInput.length,
	    numberOfLeadingZeroes = numberOfDigits - binInputLen,
	    i;
	for (i = 0; i < numberOfLeadingZeroes; i+=1) {
		binInput = '0' + binInput;
	}
	return binInput.replace(/(\w{8,8})(?=\w)/g, '$1 ');
}

console.log("n\tbinary representation\tbit #3");
n = 5;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
n = 8;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
n = 0;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
n = 15;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
n = 5343;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
n = 62241;
console.log(n + '\t' + getBinaryRepresentation(n, numberOfDigits) + '\t' + getThirdBit(n));
