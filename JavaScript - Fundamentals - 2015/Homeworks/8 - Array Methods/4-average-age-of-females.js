/*
 * Problem 4. Average age of females
 * Write a function that calculates the average age of all females, extracted from an array of persons
 *   Use Array#filter
 *   Use only array methods and no regular loops (for, while)
 */

function Person(firstname, lastname, age, gender) {
	this.firstname = firstname;
	this.lastname = lastname;
	this.age = age;
	this.gender = gender;
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

function randomPerson() {
	return new Person(randomNameMaker(), randomNameMaker(),
		randomAgeMaker(), randomGenderMaker());
}

function averageAgeOfFemales(people) {
	var age, females = people.filter(function(element){
		return element.gender;
	});
	age = females.reduce(function(a, female) {
		return a + female.age;
	}, 0);
	return age / females.length;
}

var N = 5, people = [];

people = Array.apply(null, {length: N}).map(Function.call, randomPerson);

console.log(people);

console.log(averageAgeOfFemales(people));
