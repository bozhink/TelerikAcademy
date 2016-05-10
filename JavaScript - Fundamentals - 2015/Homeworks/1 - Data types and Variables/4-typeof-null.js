/*
 * Problem 4. Typeof null
 * Create null, undefined variables and try typeof on them.
 */

var x, y;

console.log('typeof x = ' + typeof(x));

y = null;
console.log('typeof y = ' + typeof(y));

x = y;
console.log('typeof x = ' + typeof(x));

y = undefined;
console.log('typeof y = ' + typeof(y));
console.log('typeof x = ' + typeof(x));
