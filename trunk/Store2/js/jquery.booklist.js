;(function($){
	$.fn.booklist = function(options) {
		return $(this).each(function(){
			var settings = $.extend({}, $.fn.booklist.defaults, options);
			
			var html = new StringBuilder();
			html.append('<p><span>' + settings.title + '</span></p>');
			html.append('<table class="booklist">');
			html.append('<thead><tr>');
			for ( var j = 0; j < settings.cols.length; j ++ )
				html.append('<th>' + settings.cols[j].name + '</th>');
			html.append('</tr></thead>');
			
			html.append('<tbody>');
			for ( var i = 0; i < settings.records.length; i ++ )
			{
				html.append('<tr>');
				for ( var j = 0; j < settings.cols.length; j ++ )
				{
					html.append('<td>' + settings.records[i][settings.cols[j].value] + '</td>');
				}
				html.append('</tr>');
			}
			html.append('</tbody>');
			html.append('</table>');
			$(this).html(html.toString());

			$(this).find('tr').hover(function(){
				$(this).addClass('over');
			},
			function(){
				$(this).removeClass('over');
			});
			$(this).find('tr:even').addClass('alt');
		});
	};
	
	$.fn.booklist.defaults = {
		title : 'title',
		cols : [{name: 'column name', value:'column value'}],
		records : []
	};
})(jQuery);