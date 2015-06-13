/*
 * Problem 12. Generate list
 * Write a function that creates a HTML <ul> using a template for every HTML <li>.
 * The source of the list should be an array of elements.
 * Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.

Example: HTML:

<div data-type="template" id="list-item">
 <strong>-{name}-</strong> <span>-{age}-</span>
</div>
JavaScript:

var people = [{name: 'Peter', age: 14},…];
var tmpl = document.getElementById('list-item').innerHtml;
var peopleList = generateList(people, template);
//peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'
 */

// https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions
function escapeRegExp(string){
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}

function generateList(people, template) {
	var i, len, prop, re, result, li;
	template = String(template);

	if (people != null) {
		result = '<ul>';
		for (i = 0, len = people.length; i < len; i += 1) {
			result += '<li>';

			li = template;
			for (prop in people[i]) {
				re = new RegExp(escapeRegExp('-{' + prop + '}-'), 'g');
				li = li.replace(re, people[i][prop]);
			}

			result += li + '</li>';
		}
		result += '</ul>';
	}

	return result;
}

var people = [{name: 'Peter', age: 14}, {name: 'Peter', age: 15}, {name: 'Peter', age: 16}];
var template = document.getElementById('list-item').innerHTML;
var peopleList = generateList(people, template);

console.log(template);
console.log(peopleList);

document.getElementById('list-item').innerHTML = peopleList;
