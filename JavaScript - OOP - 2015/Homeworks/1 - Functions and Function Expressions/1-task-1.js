/*
Task 1.

    Write a function that sums an array of numbers:
        Numbers must be always of type Number
        Returns null if the array is empty
        Throws Error if the parameter is not passed (undefined)
        Throws if any of the elements is not convertible to Number

 */
function solve() {
	return function sum(arr) {
		if (arr == null) {
			throw new Error('Empty input');
		} else if (!Array.isArray(arr)) {
			throw new Error('Not an array');
		} else if (arr.length < 1) {
			return null;
		} else {
			for (var i=0, len = arr.length; i < len; i += 1) {
				if (isNaN(arr[i])) {
					throw new Error('Not a number');
				}
			}
			return arr.reduce(function(s,n){
				return s - (-n);
			}, 0);
		}
	}
}


console.log(solve()(["1", "2"]));
