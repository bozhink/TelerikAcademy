/*
 * Problem 10. Find palindromes
 * Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */

text = 'Bacon ipsum dolor amet tenet tennet strip steak turducken corned "ABBA", "lamal", "exe"beef short loin shankle, cow capicola frankfurter bresaola ham tail. Short ribs bacon tenderloin kielbasa, venison swine beef hamburger tongue sirloin picanha leberkas turkey ham hock. Turkey salami landjaeger cow, porchetta tongue venison chicken pig capicola brisket hamburger pastrami. Pork loin spare ribs shank doner chuck ground round cow turducken alcatra filet mignon bacon meatball. Tail hamburger shankle, landjaeger picanha kevin meatball. Cow short ribs short loin prosciutto filet mignon turducken. Ground round pork chop brisket doner ribeye, cupim drumstick frankfurter picanha biltong strip steak cow. Ham hock tongue meatball meatloaf jerky. Frankfurter bacon beef ribs flank landjaeger. Ham kielbasa strip steak kevin tri-tip. Short loin pastrami biltong t-bone ground round cupim brisket porchetta. Rump filet mignon turkey pork cow bacon boudin short loin ribeye porchetta pancetta. Rump sirloin corned beef shank biltong, pig turkey porchetta. Tenderloin sausage short loin swine turducken cow picanha short ribs jerky t-bone tail frankfurter venison. Swine sirloin capicola flank pork loin porchetta shoulder salami short loin hamburger cupim cow. Shoulder cow capicola sausage sirloin. Beef pork belly frankfurter ham hock meatball turkey. Corned beef andouille chuck, leberkas pancetta short loin doner. Capicola prosciutto rump chicken pork loin pig meatball flank turkey. Brisket ribeye porchetta doner hamburger, pork belly tail frankfurter flank filet mignon. Brisket chicken shankle leberkas, pig turkey pork chop swine shoulder salami meatball alcatra hamburger landjaeger. Pig bresaola hamburger pancetta boudin filet mignon corned beef pork tenderloin frankfurter strip steak pork chop drumstick. Tenderloin jowl ground round doner, sirloin venison hamburger turducken pork belly rump. Sausage venison bresaola tri-tip, swine spare ribs kevin beef ribs flank porchetta. Tongue filet mignon bacon short ribs alcatra. Pork loin ham drumstick picanha tenderloin, bresaola shankle leberkas rump landjaeger ground round fatback.';

Array.prototype.getUnique = function(){
	var i, l, u = {}, a = [];
	for(i = 0, l = this.length; i < l; i += 1){
		if(u.hasOwnProperty(this[i])) {
			continue;
		}
		a.push(this[i]);
		u[this[i]] = 1;
	}
	return a;
}

function findPalindromes(text) {
	var i, j, l, len, len2, word, isPalindrom, arr = [], result = [];
	arr = text.split(/\W+/g).sort().getUnique();

	for (i = 0, l = arr.length; i < l; i += 1) {
		word = arr[i];
		len = word.length;
		if (len > 1) { // palindromes must contain 2 or more chars
			isPalindrom = true;
			for (j = 0, len2 = (len / 2) | 0 + 1; j < len2; j += 1) {
				if (word[j] !== word[len - j - 1]) {
					isPalindrom = false;
					break;
				}
			}
			if (isPalindrom) {
				result.push(word);
			}
		}
	}
	return result;
}



console.log(findPalindromes(text));



