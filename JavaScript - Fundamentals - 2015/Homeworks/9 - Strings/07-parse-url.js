/*
 * Problem 7. Parse URL
 * Write a script that parses an URL address given in the format:
 *   [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
 * Return the elements in a JSON object.
Example:

URL	result
http://telerikacademy.com/Courses/Courses/Details/239	{ protocol: http, 
server: telerikacademy.com 
resource: /Courses/Courses/Details/239
 */

function parseUrl(text) {
	var prot, serv, res, result = {};
	text = String(text);

	prot = text.match(/^\w+(?=:\/\/)/);
	serv = text.substring(text.indexOf('://')+3).match(/[^\/]+(?=\/)/);
	res =  text.substring(text.indexOf('://')+3).match(/\/.*$/);

	result = {
		'protocol': prot[0],
		'server': serv[0],
		'resource': res[0]
	};

	return result;
}

var text = 'https://telerikacademy.com/Courses/Courses/Details/239';

console.log(text);
console.log(parseUrl(text));
