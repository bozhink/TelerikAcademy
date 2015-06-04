/*
 * Problem 3. Min/Max of sequence
 * Write a script that finds the max and min number from a sequence of numbers.
 */

var numbers = [], i, len, min, max;

for ( i = 0; i < 10; i+=1) {
	numbers.push((Math.random()*100) | 0 );
}

len = numbers.length;

for ( i = 0; i < len; i+=1 ) {
	console.log(numbers[i]);
}

min = numbers[0];
max = numbers[0];

for (i = 1; i < len; i+=1) {
	if (min > numbers[i]) {
		min = numbers[i];
	}
	if (max < numbers[i]) {
		max = numbers[i];
	}
}

console.log('min = ' + min);
console.log('max = ' + max);

