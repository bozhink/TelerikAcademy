/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		

	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`

	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'

	*	all methods and properties must be attached to the prototype of the Person

	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {

	var Person = (function () {

		var _firstname, _lastname, _age, _fullName;

		function Person(firstname, lastname, age) {
			this.firstname = firstname;
			this.lastname = lastname;
			this.age = age;
		}

		Person.prototype = {
			get firstname() {
				return _firstname;
			},

			set firstname(value) {
				_firstname = _validateName(value);
				return this;
			},

			get lastname() {
				return _lastname;
			},

			set lastname(value) {
				_lastname = _validateName(value);
				return this;
			},

			get age() {
				return _age;
			},

			set age(value) {
				_age = _validateAge(value);
				return this;
			},

			get fullname() {
				return this.firstname + ' ' + this.lastname;
			},

			set fullname(value) {
				var names = value.match(/\S+/g), len = names.length;
				if (len < 2) {
					throw new Error('Invalid fullname');
				} else {
					this.firstname = names[0];
					this.lastname = names[1];
				}
				return this;
			},

			introduce: function() {
				return 'Hello! My name is ' + this.fullname +' and I am '+ this.age + '-years-old';
			},
		}

		function _validateName(nameString) {
			nameString = '' + nameString;
			var len = nameString.length, invalidCharacters;
			if (len > 2 && len < 21) {
				invalidCharacters = nameString.match(/[0-9&,;:=]/g);
				if (invalidCharacters == null || invalidCharacters.length == 0) {
					return nameString;
				}
			}
			throw new Error('Invalid name ' + nameString);
		}

		function _validateAge(age) {
			if (isNaN(age)) {
				throw new Error('Age is not a number ' + age);
			} else {
				age = +age;
				if (age >= 0 && age <= 150) {
					return age;
				} else {
					throw new Error('Age is out of range ' + age);
				}
			}
		}
		
		return Person;
	} ());

	return Person;
}
module.exports = solve;