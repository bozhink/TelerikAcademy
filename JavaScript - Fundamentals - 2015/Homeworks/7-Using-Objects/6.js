/*
 * Problem 6.
 * Write a function that groups an array of people by age, first or last name.
 * The function must return an associative array, with keys - the groups, and
 *   values - arrays with people in this groups
 * Use function overloading (i.e. just one function)
Example:

var people = {…};
var groupedByFname = group(people, 'firstname');
var groupedByAge= group(people, 'age');
 */

function group(people, key) {
	var i, idx, len, result = {}, arr = [].slice.apply(arguments);

	switch (arr.length) {
		case 0:
			break;
		case 1:
			key = 'age';
			// no break!
		default:
			len = people.length;
			switch (key) {
				case 'age':
					for (i = 0; i < len; i += 1) {
						if (!!people[i] && !!people[i].age) {
							idx = people[i].age;
							if (!result[idx]) {
								result[idx] = [];
							}
							result[idx].push(people[i]);
						}
					}
					break;
				case 'firstname':
					for (i = 0; i < len; i += 1) {
						if (!!people[i] && !!people[i].firstname) {
							idx = people[i].firstname;
							if (!result[idx]) {
								result[idx] = [];
							}
							result[idx].push(people[i]);
						}
					}
					break;
				case 'lastname':
					for (i = 0; i < len; i += 1) {
						if (!!people[i] && !!people[i].lastname) {
							idx = people[i].lastname;
							if (!result[idx]) {
								result[idx] = [];
							}
							result[idx].push(people[i]);
						}
					}
					break;
				default:
					result = null;
			}
	}

	return result;
}

var i, len, res, people = [
	{ firstname : 'Gosho', lastname: 'Petrov', age: 32 },
	{ firstname : 'Pesho', lastname: 'Petrov', age: 32 },
	{ firstname : 'Bay', lastname: 'Ivan', age: 81},
	];

res = group(people, 'age');
console.log(res);
console.log();

res = group(people, 'firstname');
console.log(res);
console.log();

res = group(people, 'lastname');
console.log(res);
console.log();
