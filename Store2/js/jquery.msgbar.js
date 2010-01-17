;(function($){
	$.fn.msgbar = function(options) {
		return $(this).each(function(){
			if ( options == null || options.msg == null || options.msg == '' )
			{
				$(this).css('display', 'none');
				return;
			}
			
			var settings = $.extend({}, $.fn.msgbar.defaults, options);
			$(this).html('<span>' + settings.msg + '</span>');
			
			var span = $(this).children('span:eq(0)');
			var width = span.outerWidth() + settings.corner * 2;
			$(this).width(width < 200 ? 200 : width);
			
			$(this).css('background-color', settings.backColor );	
			$(this).css('padding', '5px 0 5px');	
			$(this).css('text-align', 'center');
			$(this).css('margin', '5px auto 5px');	
			$(this).css('font-weight', 'bold');	   			
			$(this).corner(settings.corner);
		});
	};
	
	$.fn.msgbar.defaults = {
		backColor : 'yellow', 
		corner : 5,
		msg : ''
	};

})(jQuery);