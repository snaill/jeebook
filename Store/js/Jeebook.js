/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

;(function($){
	$.jeebook = {
		getDirectories : function(path){
			var o = {};
			$.ajax({
				url 	: "ashx/GetDirectories.ashx",
				type	: "GET",
				async	: false,
				data 	: {path:path},
				dataType : 'json',
				success : function(data){
					o = data;
				},
				error	: function(xhr){
					alert('error');
				}
			});
			return o;
		}
	};
})(jQuery);