/*
 * Problem 5. Youngest person
 * Write a function that finds the youngest person in a given array of people and prints his/hers full name
 * Each person has properties firstname, lastname and age.
Example:

var people = [
  { firstname : 'Gosho', lastname: 'Petrov', age: 32 }, 
  { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];
 */

function youngestPerson(people) {
	var result, i, len, age, minage, youngest = [], validpeople = [];

	// Fist find the minimal age
	if (isNaN(people[0].age)) {
		minage = 1000000;
	} else {
		minage = people[0].age;
		validpeople.push(people[0]);
	}
	for (i = 1, len = people.length; i < len; i += 1) {
		if (!isNaN(age = people[i].age)) {
			validpeople.push(people[i]);
			if (age < minage) {
				minage = age;
			}
		}
	}

	// Next: select all people with this minimal age
	for (i = 0, len = validpeople.length; i < len; i += 1) {
		if (validpeople[i].age === minage) {
			youngest.push(validpeople[i]);
		}
	}

	// Prepare result
	if (!!youngest) {
		result = youngest;
	}
	return result;
}

var i, len, res, people = [
	{ firstname : 'Gosho', lastname: 'Petrov', age: 32 },
	{ firstname : 'Pesho', lastname: 'Petrov', age: 32 },
	{ firstname : 'Bay', lastname: 'Ivan', age: 81},
	];

res = youngestPerson(people);

for (i = 0, len = res.length; i < len; i += 1) {
	console.log(res[i].firstname + ' ' + res[i].lastname);
}
