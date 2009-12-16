/*
 * jQuery.PathNavbar 1.0
 * Copyright(c) 2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */
 
 /*
	/jeebook/trunk/Store/libs/jQuery.PathNavbar
	minCount : 3
	<ul>
		<li>
			<span> > </span>
			<span>Store</span>
			<ul>
				<li>jeebook</li>
				<li>trunk</li>
			</ul>
		</li>
		<li>
			<span> > </span>
			<span>libs</span>
		</li>
		<li>
			<span> > </span>
			<span>jQuery.PathNavbar</span>
		</li>		
	</ul>
  */
  
;(function($){
    $.fn.pathnavbar = function( options ) {
        var pnb = $.fn.pathnavbar,
            path2html = function(p, cnt) {
				if ( p.indexOf('/') == 0 )
					p = p.substr(1);
					
                var s = p.split('/');
                var html = new StringBuilder();
				var index = 0;
				if ( s.length > cnt )
					index = s.length - cnt;

				html.append('<ul>');	
                for (var i = index; i < s.length; i ++ )
                {
					html.append('<li><span class="drop">');
					html.append(' > ');
					html.append('</span><span>' + s[i] + '</span>');
					if ( i == index )
					{
						html.append('<ul>');	
						for ( var j = 0; j < index; j ++ )
						{
							html.append('<li>' + s[j] + '</li>');
						}
						html.append('</ul>');
					}
                    html.append('</li>');
                }
				html.append('</ul>');
                return html.toString();
            },
			getPath = function(o) {
				var nodes = o.prevAll().find('span[class!="drop"]');
				var path = new StringBuilder('/');
				for ( var i = nodes.length - 1; i >= 0; i -- )
				{
					path.append($(nodes[i]).html() + '/');
				}
				path.append(o.find('span[class!="drop"]').html() + '/');
				return path.toString();
			};
        return this.each(function(){
            var settings = $.extend({}, pnb.defaults, options);
			
            $(this).html(path2html(settings.path, settings.minCount));
            
			$(this).click(function(){
                alert("this");
            });
			
            $(this).find('ul li span[class="drop"]').click(function(){
                alert(">");
            });
			            
			$(this).find('ul li span[class!="drop"]').click(function(){
				$(this).parent().nextAll().remove();
				
                if ( settings.callback != null )
					settings.callback(getPath($(this).parent()));
            });
        });
    };
    
    var pnb = $.fn.pathnavbar;
    pnb.defaults = {
        path : '/',
		minCount : 5
    };
})(jQuery);