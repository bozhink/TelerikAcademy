/*
 * Problem 9. Extract e-mails
 * Write a function for extracting all email addresses from given text.
 * All sub-strings that match the format @… should be recognized as emails.
 * Return the emails as array of strings.
 */

function extractEmails(text) {
	var result = String(text);
	result = result.match(/[\w\._]+@(?:[\w_]+\.)*[\w_]+\.[\w_]+/g);
	return result;
}

var text = 'sdsdfs@sdnbfskjnb sdsdfs@sdnbfskjnb.zxc jsdhf lksh90s79087.skdjfls@sdkjlfldjsf.sf;dlkfs';

console.log(text);
console.log(extractEmails(text));
