/*
 * Write a function that finds the youngest male person
 *   in a given array of people and prints his full name
 *   Use only array methods and no regular loops (for, while)
 *   Use Array#find
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

function youngestPerson(people) {
	var youngestMale, males = people.filter(function(element){
		return !element.gender;
	});
	youngestMale = males.reduce(function(youngest, male) {
		return youngest.age > male.age ? male : youngest;
	}, males[0]);
	console.log(youngestMale.firstname + ' ' + youngestMale.lastname);
	return youngestMale;
}

var N = 10, people = [];

people = Array.apply(null, {length: N}).map(Function.call, randomPerson);

console.log(people);

// console.log(
	youngestPerson(people)
// );


