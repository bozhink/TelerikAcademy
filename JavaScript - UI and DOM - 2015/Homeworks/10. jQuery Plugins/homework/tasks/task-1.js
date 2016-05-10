function solve() {
    return function (selector) {
        var $selector = $(selector).hide(),
            $dropdownList = $('<div>')
                .addClass('dropdown-list')
                .append($selector),
            $currentSelection = $('<div>')
                .addClass('current')
                .attr('data-value', '')
                .text('Select value'),
            $optionsContainer = $('<div>')
                .addClass('options-container')
                .css({
                    'position': 'absolute',
                    'display': 'none'
                });

        $selector.find('option').each(function (i, element) {
            var $this = $(this);
            $('<div>')
                .addClass('dropdown-item')
                .attr({
                    'data-value': $this.val(),
                    'data-index': i
                })
                .text($this.text())
                .appendTo($optionsContainer);
        });

        $currentSelection.on('click', function () {
            $('.options-container').css('display', '');
        });

        $optionsContainer.on('click', function (event) {
            $selector.val($(event.target).attr('data-value'));
            $(this).css('display', 'none');
            $('.current').text($clicked.html());
        });

        $currentSelection.appendTo($dropdownList);
        $optionsContainer.appendTo($dropdownList);
        $dropdownList.appendTo('body');
    };
}

module.exports = solve;