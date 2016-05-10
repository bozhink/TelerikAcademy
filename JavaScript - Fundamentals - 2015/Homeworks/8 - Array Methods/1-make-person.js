/*
 * Problem 1. Make person
 * Write a function for creating persons.
 *   Each person must have firstname, lastname, age and gender (true is female, false is male)
 * Generate an array with ten person with different names, ages and genders
 */

var i, pp, N = 10, people = [];


function makePerson(firstname, lastname, age, gender) {
	return {
		firstname: firstname,
		lastname: lastname,
		age: isNaN(age) ? 0 : +age,
		gender: typeof(gender) === 'boolean' || gender.toLowerCase().charAt(0) === 'f' ? true : false
	}
}

function randomNameMaker(len) {
	var i, result, alphabet = 'qwertyuiopasdfghjklzxcvbnm';
	len = isNaN(len) ? 5 : len;
	result = alphabet.charAt((len*Math.random()) | 0).toUpperCase();
	for (i = 1; i < len; i += 1) {
		result += alphabet.charAt((len*Math.random()) | 0);
	}
	return result;
}

function randomAgeMaker(highestAge) {
	highestAge = isNaN(highestAge) ? 90 : highestAge;
	return (highestAge * Math.random()) | 0;
}

function randomGenderMaker() {
	return !!((2 * Math.random()) | 0);
}


for (i = 0; i < N; i += 1) {
	people[i] = makePerson(randomNameMaker(), randomNameMaker(), randomAgeMaker(), randomGenderMaker());
}

console.log(people);


pp = people.map(function (element) {
		return makePerson(randomNameMaker(), randomNameMaker(),
			randomAgeMaker(), randomGenderMaker());
	});

console.log(pp);
