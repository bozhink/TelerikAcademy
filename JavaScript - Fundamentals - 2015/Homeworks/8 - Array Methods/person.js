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
