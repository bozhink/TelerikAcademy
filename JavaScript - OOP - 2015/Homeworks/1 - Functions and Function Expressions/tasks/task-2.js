/*
Task 2.

    Write a function that finds all the prime numbers in a range
        It should return the prime numbers in an array
        It must throw an Error if any of the range params is not convertible to Number
        It must throw an Error if any of the range params is missing


 */
function solve() {
	return function primes(l, r) {
		var i, result = [];
		function isPrime(n) {
			var j, r = true, nStop = Math.sqrt(n);
			for (j = 2; j <= nStop; j += 1) {
				if (n % j == 0) {
					r = false;
					break;
				}
			}
			return r;
		}

		if (l == null || r == null || isNaN(l) || isNaN(r)) {
			throw new Error('Invalid range parameter(s)');
		} else {
			l = +l;
			r = +r;
			if (l > r) {
				i = l;
				l = r;
				r = i;
			}
			l = l < 2 ? 2 : l;
			r = !(r % 2) ? r - 1 : r;
			if (l > r) {
				r = l;
			}
			for (i = l; i <= r; i += 1) {
				if (isPrime(i)) {
					result.push(i);
				}
			}
		}

		return result;
	}
}

module.exports = solve;
