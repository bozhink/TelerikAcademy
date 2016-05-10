/*
 * Problem 3. Occurrences of word
 * Write a function that finds all the occurrences of word in a text.
 * The search can be case sensitive or case insensitive.
 * Use function overloading.
 */


function occWord(text, key) {
	var i, result, words, word, len,
		wordCount = {};
	words = text.split(/[^\w-]/);
	for (i = 0, len = words.length; i < len; i += 1) {
		word = words[i];
		if(!wordCount[word]) {
			wordCount[word] = 0;
		}
		wordCount[word] += 1;
	}
	for (word in wordCount) {
		if (word == key) {
			result = wordCount[word];
			break;
		}
	}
	return result;
}

function occurencesOfWord(text, key, lettercase) {
	var result,
		arr = [].slice.apply(arguments),
		arrlen = arr.length;
	switch (arr.length) {
		case 0:
		case 1:
			// result = undefined;
			break;
		case 2:
			result = occWord(text, key);
			break;
		default:
			if (lettercase === 'ignore') {
				result = occWord(text.toLowerCase(), key.toLowerCase());
			} else {
				result = occWord(text, key);
			}
	}
	return result;
}


var text = 'Bacon ipsum dolor amet ball tip jerky flank, boudin pork ground round spare ribs pig filet mignon sirloin frankfurter tri-tip fatback drumstick. Pork alcatra capicola ribeye. Kielbasa pork ball tip chicken, prosciutto alcatra jerky short loin shankle bresaola frankfurter. Cupim brisket andouille short ribs, ribeye tri-tip beef porchetta kielbasa ham hock filet mignon. Tenderloin strip steak landjaeger, tri-tip ground round beef brisket doner shankle. Ham hock ham ribeye ground round kevin chuck meatloaf hamburger. Turkey landjaeger rump bresaola tenderloin, venison chuck tri-tip pancetta boudin flank hamburger jerky doner filet mignon. Turkey porchetta venison turducken prosciutto picanha beef ribs beef alcatra. Beef doner filet mignon tongue shoulder. Strip steak t-bone ribeye bresaola boudin. Ball tip salami tail kevin kielbasa cow. Drumstick sirloin meatball bresaola, alcatra hamburger rump jowl capicola pork belly ground round.';

console.log(occurencesOfWord(text, 'pork'));
console.log(occurencesOfWord(text, 'pork', 'sldkjf;lskdhfg;hd'));
console.log(occurencesOfWord(text, 'pork', 'ignore'));
