/*
 * Problem 8. Replace tags
 * Write a JavaScript function that replaces in a HTML document
 *   given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
Example:

input	output
<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
 Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
 	<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */


function replaceUrl(text) {
	var result = String(text);
	result = result.replace(/<a\s+[^>]*href="([^>"]*?)"[^>]*>/g, '[URL=$1]');
	result = result.replace(/<\/a>/g, '[/URL]');
	return result;
}

var text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose <a href="http://academy.telerik.com">our site<a href="http://academy.telerik.com">our site</a></a> a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
console.log('"' + text + '"\n\n' + '"' + replaceUrl(text) + '"');
