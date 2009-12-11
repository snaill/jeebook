;(function($){
    $.fn.pathnavbar = function( options ) {
        var nb = $.fn.pathnavbar,
            path2html = function(p) {
                var s = p.split('/');
                var html = ' > ';
                var path = '';
                for (var i = 0; i < s.length; i ++ )
                {
                    if ( s[i] == '' )
                        continue;
                    path += '/' + s[i];
                    html += "<a href=" + path + ">" + s[i] + "</a> > ";
                }
                return html;
            };
        return this.each(function(){
            var settings = $.extend({}, nb.defaults, options);
            
            $(this).html(path2html(settings.path));
            
            $(this).find("a").click(function(){
                alert("test");
            });
        });
    };
    
    var nb = $.fn.pathnavbar;
    nb.defaults = {
        path : '/'
    };
})(jQuery);