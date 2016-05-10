## 4. Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.

* Uniform Resource Identifier (URI) is a string of characters used to identify the name of a resource
* A URL is a URI that, in addition to identifying a web resource, specifies the means of acting upon or obtaining the representation of it, i.e. specifying both its primary access mechanism and network location
* A URN is a URI that identifies a resource by name in a particular namespace. A URN can be used to talk about a resource without implying its location or how to access it.

### Syntax
A generic URI is of the form:

**`scheme:[//[user:password@]domain[:port]][/]path[?query][#fragment]`**

* The **scheme** consists of a sequence of characters beginning with a letter and followed by any combination of letters, digits, plus (+), period (.), or hyphen (-)
* The **hierarchical part**, which contains
    * An optional authority part, comprising:
        * Two slashes (//)
        * An optional authentication section of a user name and password, separated by a colon, followed by an at symbol (@)
        * A hostname such as a domain name or IP address; IPv6 addresses must be enclosed in brackets ([ ])
        * An optional port number, separated from the hostname by a colon
    * A **path**, which contains data, usually organized in hierarchical form, that appears as a sequence of segments separated by slashes.
* An optional **query**, separated from the preceding part by a question mark (?), containing a query string of non-hierarchical data. Its syntax is not well defined, but by convention is most often a sequence of attribute-value pairs separated by a delimiter.
* An optional **fragment**, separated from the preceding part by a hash (#).
