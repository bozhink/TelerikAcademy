/*
 * Problem 6. Group people
 * Write a function that groups an array of persons
 *   by first letter of first name and returns the groups as a JavaScript Object
 *   Use Array#reduce
 *   Use only array methods and no regular loops (for, while)
Example:

    result = {
        'a': [{
            firstname: 'Asen',
            ...
        }, {
            firstname: 'Anakonda',
            ...
        }],
        'j': [{
            firstname: 'John',
            ...
        }]
    };
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

function groupPeople(people) {
    return people.reduce(function(result, person){
        var idx = person.firstname.charAt(0).toLowerCase();
        idx = idx == null ? 'null' : idx;
        if (result[idx] == null) {
            result[idx] = [];
        }
        result[idx].push(person);
        return result;
    }, {});
}

var N = 10, people = [];

people = Array.apply(null, {length: N}).map(Function.call, randomPerson);

console.log(people);
console.log();
console.log(groupPeople(people));

