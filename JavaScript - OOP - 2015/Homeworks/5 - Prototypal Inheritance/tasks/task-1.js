/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors

  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`

  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits

  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
      * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>

  * property content of type string
    * sets the content of the element
    * works only if there are no children

  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)

  * property children
    * each child is a domElement or a string

  * property parent
    * parent is a domElement

  * method appendChild(domElement / string)
    * appends to the end of children list

  * method addAttribute(name, value)
    * throw Error if type is not valid

  * method removeAttribute(attribute)
    * throw Error if attribute does not exist in the domElement
*/


/* Example

var meta = Object.create(domElement)
    .init('meta')
    .addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
    .init('head')
    .appendChild(meta)

var div = Object.create(domElement)
    .init('div')
    .addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
    .init('body')
    .appendChild(div)
    .addAttribute('id', 'cuki')
    .addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
    .init('html')
    .appendChild(head)
    .appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {
    var domElement = (function () {

        var domElement = {
            _type: '',
            _parent: '',
            _content: '',
            _contentSetByChild: false,
            _attributes: [],
            _children: [],

            init: function (type) {
                var that = this;
                that.type = type;
                that._attributes = [];
                that._children = [];
                that.parent = Object;
                that.content = '';
                return that;
            },

            appendChild: function (child) {
                var that = this;
                if (typeof (child) === 'string') {
                    that._children.push({
                        innerHTML: child,
                    });
                } else {
                    that._children.push(child);
                    child.parent = that;
                }
                that._contentSetByChild = true;
                return that;
            },

            addAttribute: function (name, value) {
                var i, len, that = this, _a_ = that._attributes;
                if ((typeof (name) !== 'string') || !name ||
                        ((name.match(/[^A-Za-z0-9-]/g) || []).length > 0)) {
                    throw new Error('Invalid attribute name.');
                }

                for (i = 0, len = _a_.length; i < len; i += 1) {
                    if (name === _a_[i].name) {
                        _a_.splice(i, 1);
                        i -= 1;
                        len -= 1;
                    }
                }

                _a_.push({
                    name: name,
                    value: value
                });

                return that;
            },

            removeAttribute: function (name) {
                var i, len, index = -1, that = this, _a_ = that._attributes;
                if ((typeof (name) !== 'string') || !name ||
                        ((name.match(/[^A-Za-z0-9-]/g) || []).length > 0)) {
                    return this;
                }

                for (i = 0, len = _a_.length; i < len; i += 1) {
                    if (name === _a_[i].name) {
                        index = i;
                        break;
                    }
                }

                if (index < 0) {
                    throw new Error('There is no such attribute ' + name);
                }

                _a_.splice(index, 1);

                return that;
            },

            get innerHTML() {
                var i, len, that = this,
                    _a_ = that._attributes,
                    _c_ = that._children,
                    result = '<' + that._type;
                _a_.sort(function (a, b) {
                    if (a.name > b.name) {
                        return 1;
                    }
                    if (a.name < b.name) {
                        return -1;
                    }
                    return 0;
                });
                for (i = 0, len = _a_.length; i < len; i += 1) {
                    result += ' ' + _a_[i].name + '="' + _a_[i].value + '"';
                }
                result += ">";
                for (i = 0, len = _c_.length; i < len; i += 1) {
                        result += _c_[i].innerHTML;
                }

                result += "</" + that._type + '>';
                return result;
            },
        };

        Object.defineProperties(domElement, {
            type: {
                get: function () {
                    return this._type;
                },

                set: function (value) {
                    if ((typeof (value) !== 'string') || !value ||
                    ((value.match(/[^A-Za-z0-9]/g) || []).length > 0)) {
                        throw new Error('Invalid type.');
                    }

                    this._type = value;
                    return this;
                },
            },

            parent: {
                get: function () {
                    return this._parent;
                },
                set: function (value) {
                    this._parent = value;
                }
            },

            content: {
                get: function () {
                    return this._content;
                },
                set: function (value) {
                    var that = this;
                    if (!that._contentSetByChild) {
                        that._children.push({
                            innerHTML: value
                        });
                    }
                    return that;
                }
            },

            attributes: {
                get: function () {
                    return this._attributes.slice(0);
                }
            },

            children: {
                get: function () {
                    return this._children.slice(0);
                },
            },
        });

        return domElement;
    }());
    return domElement;
}

module.exports = solve;
