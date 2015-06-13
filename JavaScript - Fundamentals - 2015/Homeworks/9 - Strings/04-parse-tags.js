/*
 * Problem 4. Parse tags
 * You are given a text. Write a function that changes the text in all regions:
<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)

Example: We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>.
 We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

The expected result:
We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.

Note: Regions can be nested.
 */

function upCase(char) {
	return char.toUpperCase();
}

function lowCase(char) {
	return char.toLowerCase();
}

function mixCase(char) {
	if (Math.random() < 0.5) {
		return char.toUpperCase();
	} else {
		return char.toLowerCase();
	}
}

function normalCase(char) {
	return char;
}

function parseTags(text) {
	var i, j, len, ch, ch1, charCase, prevCharCase = [], result, stack = [];
	text = String(text);
	result = '';

	charCase = normalCase;
	prevCharCase.push(charCase);
	for (i = 0, len = text.length; i < len; i += 1) {
		ch = text[i];

		switch (ch) {
			case '<':
				result += ch;

				stack.push('');
				j = stack.length - 1;
				for (i += 1; i < len && text[i] !== '>'; i += 1) {
					ch1 = text[i].toLowerCase();
					result += ch1;
					stack[j] += ch1;
				}
				if ((ch1 = text[i].toLowerCase()) === '>') {
					result += ch1;
				}
				// Now we have the tag name in the stack[j]

				switch (stack[j]) {
					case 'mixcase':
						charCase = mixCase;
						break;
					case 'upcase':
						charCase = upCase;
						break;
					case 'lowcase':
						charCase = lowCase;
						break;
					case '/mixcase':
					case '/upcase':
					case '/lowcase':
						// console.log(charCase);
						prevCharCase.pop();
						charCase = prevCharCase.pop();
						// console.log(charCase);
						break;
					default:
						charCase = normalCase;
				}
				prevCharCase.push(charCase);
				break;
			default:
				result += charCase(ch);
		}
	}

	return result.replace(/<\/?(mixcase|upcase|lowcase)>/g, '');
}



var text = 'We <em>are</em> <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>.\
 We <mixcase>don\'t</mixcase> have <lowcase>anything<upcase>yellow submarine</upcase> FDGSdfg</lowcase> else TR.'

console.log(text);
console.log();
console.log(parseTags(text));


