/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

;(function($){
	$.jeebook = {
		getCategorys : function(path, opts){
			var o = {};
			opts = $.extend({
				async	: false,
				success : function(data){
					o = data;
				},
				error	: function(xhr){
					alert('error');
				}
			}, opts || {});
			
			var url = 'api/category/' + path;
			$.ajax({
				url 	: url,
				type	: "GET",
				async	: opts.async,
				dataType : 'json',
				success : opts.success,
				error	: opts.error
			});
			return o;
		},
		
		getBooks : function(path, opts){
			var o = {};
			opts = $.extend({
				async	: false,
				success : function(data){
					o = data;
				},
				error	: function(xhr){
					alert('error');
				}
			}, opts || {});
			
			var url = 'api/book/' + path;
			$.ajax({
				url 	: url,
				type	: "GET",
				async	: opts.async,
				dataType : 'json',
				success : opts.success,
				error	: opts.error
			});
			return o;
		}
	};
})(jQuery);