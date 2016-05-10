function solve(){
  return function(){
      $.fn.listview = function (data) {
          var i, len,
              templateHtmlString,
              handlebarsCompiledTemplate,
              htmlfragment,
              that = this,
              $this = $(that),
              $dataTemplateId = $this.attr('data-template');
          if (data != null) {
              try {
                  len = data.length;
                  templateHtmlString = $('#' + $dataTemplateId).html();
                  if (templateHtmlString != null && templateHtmlString.length > 0) {
                      handlebarsCompiledTemplate = handlebars.compile(templateHtmlString);

                      htmlfragment = '';
                      for (i = 0; i < len; i += 1) {
                          htmlfragment += handlebarsCompiledTemplate(data[i]);
                      }

                      $this.html(htmlfragment);
                  }
              } catch (e) {
                  // throw new Error('"data" should be an array.');
                  console.log('"data" should be an array.');
              }
          }

          return that;
      };
  };
}

module.exports = solve;