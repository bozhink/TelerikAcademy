/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters,
			    digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [], categories = [];
		
		function listBooks(bookToSearch) {
			var i, catIndex, len, result, nBooks = books.length, isPresent;
			if (nBooks < 1) {
				return [];
			}

			// Categories
			try {
				if (bookToSearch.category != null || bookToSearch.category.length > 0) {
					for (i = 0, len = categories.length, isPresent = false; i < len; i += 1){
						if (bookToSearch.category === categories[i].category) {
							isPresent = true;
							catIndex = i;
							break;
						}
					}
					if (!isPresent) {
						return [];
					}
					result = [];
					for (i = 0, len = books.length; i < len; i += 1) {
						if (books[i].category === categories[catIndex].category) {
							result.push(books[i]);
						}
					}
					return result;
				}
			} catch (e) {

			}

			try {
				if (bookToSearch.author != null || bookToSearch.author.length > 0) {
					for (i = 0, len = books.length, isPresent = false; i < len; i += 1){
						if (bookToSearch.author === books[i].author) {
							isPresent = true;
							break;
						}
					}
					if (!isPresent) {
						return [];
					}
					

				}
			} catch (e) {

			}

			if (nBooks === 1 && books.length === 1) {
				return books;
			}

			return books;
		}

		function addBook(book) {
			var i, title = book.title, len = title.length, isbn = book.isbn,
				nBooks = books.length;
			if (len < 2 || len > 100) {
				throw new Error();
			}
			if (book.author.length < 1) {
				throw new Error();
			}
			// Test for valid title and isbn
			for (i = 0; i < nBooks; i += 1) {
				if (title === books[i].title || isbn === books[i].isbn) {
					throw new Error();
				}
			}
			// ISBN length
			if (isbn.length < 10 || isbn.length > 13) {
				throw new Error();
			}

			book.ID = nBooks + 1;
			books.push(book);
			addCategory(book.category);
			return book;
		}

		function addCategory(category) {
			var i, nCat,
				len = category.length;
			if (len < 2 || len > 100) {
				throw new Error();
			}
			for (i = 0, nCat = categories.length; i < nCat; i += 1) {
				if (category === categories[i].category) {
					categories[i].nBooks += 1;
					return;
				}
			}

			categories.push({category: category, ID: nCat + 1, nBooks: 0});
			return category;
		}

		function listCategories() {
			var result = [], i, len;
			for (i = 0, len = categories.length; i < len; i += 1) {
				result.push(categories[i].category);
			}
			return result;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
