/*
 * Problem 3. Underage people
 * Write a function that prints all underaged persons of an array of person
 *   Use Array#filter and Array#forEach
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

function underagePeople(people, age) {
	var underage = people.filter(function(element){
		return element.age <= age;
	});
	underage.forEach(function(element){
		console.log(element);
	});
}


var N = 10, people = [];

people = Array.apply(null, {length: N}).map(Function.call, randomPerson);

console.log(people);

underagePeople(people, 18);
