/*
 * Problem 2. Quoted text
 * Create a string variable with quoted text in it.
 * For example: `'How you doin'?', Joey said'.
 */

var quotedString = "'How you doin'?', Joey said";
console.log('"\'How you doin\'?\', Joey said"' + '\t-->\t' + quotedString);

quotedString = '\'How you doin\'?\', Joey said';
console.log('\'\\\'How you doin\\\'?\\\', Joey said\'' + '\t-->\t' + quotedString);

quotedString = '"How you doin\'?", Joey said';
console.log('\'"How you doin\\\'?", Joey said\'' + '\t-->\t' + quotedString);

quotedString = "\"How you doin\'?\", Joey said";
console.log('"\\\"How you doin\\\'?\\\", Joey said"' + '\t-->\t' + quotedString);
