/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

$(document).ready(function(){
	
	$("div#cmdbar").corner("tl bl 24px");
	
//	$("div#msgbar").msgbar({msg:'test'});

/*	$("div#cmdbar").shadow({
           width:5, 
           startOpacity:60, 
           endOpacity:10, 
           cornerHeight:8, 
           color:"#000000"
    });
*/
	var button = $('#uploadbtn'), interval;
	
	new AjaxUpload(button, {
		action: 'api/book/upload/', 
		onSubmit : function(file, ext){
			// Allow only images. You should add security check on the server-side.
			if (!(ext && /^(bmp|png|jpeg|gif)$/.test(ext))){
				// extension is not allowed
				$("div#msgbar").msgbar({msg:'Error: only images are allowed'});
				// cancel upload
				return false;				
			}	
			
			// If you want to allow uploading only 1 file at time,
			// you can disable upload button
			this.disable();
			
			// Uploding -> Uploading. -> Uploading...
			interval = window.setInterval(function(){
				var text = button.text();
				if (text.length < 5){
					button.text(text + '.');					
				} else {
					button.text('');				
				}
			}, 200);
		},
		onComplete: function(file, response){
			button.text('Upload');
						
			window.clearInterval(interval);
						
			// enable upload button
			this.enable();
			
			// add file to the list
			$('<li></li>').appendTo('#example1 .files').text(file);						
		}
	});
		
	// init pagination
	var error = function( xhr ) {
		var msg = 'HTTP ' + xhr.status + ': ' + xhr.statusText;
		$("div#msgbar").msgbar({msg:msg});
	};
	
	$.jeebook.getCategorys('upload/', {
		async	: true,
		error 	: error,
		success : function(data){
			if ( data.length == 0 )
				return;
				
			var names = [];
			for ( var i = 0; i < data.length; i ++ )
				names[i] = data[i].name;
			
			$("div#pagination").pagination(data.length, {
				num_edge_entries: 2,
				num_display_entries: 8,
				items_per_page:1,
				labels:names,
				callback: function(page_index, jq){
					var url = 'upload/';
					if ( this.labels[page_index] != null )
						url += this.labels[page_index] + '/';
					$.jeebook.getBooks(url, {
						async	: true,
						error 	: error,
						success : function(data){
							alert(data.length);
						}
					});
				}
			});
		}
	});
	/*
	$.ajax({
		url 	: 'api/category/upload/',
		type	: "GET",
		async	: true,
		dataType : 'json',
		success : function(data){
			var names = [];
			for ( var i = 0; i < data.length; i ++ )
				names[i] = data[i].name;
			
			$("div#pagination").pagination(data.length, {
				num_edge_entries: 2,
				num_display_entries: 8,
				items_per_page:1,
				labels:names,
				callback: function(page_index, jq){
					$.ajax({
						url 	: 'api/book/upload/' + this.labels[page_index] + '/',
						type	: "GET",
						async	: true,
						dataType : 'json',
						success : function(data){
							var names = [];
							for ( var i = 0; i < data.length; i ++ )
								names[i] = data[i].name;
							
							$("div#pagination").pagination(data.length, {
								num_edge_entries: 2,
								num_display_entries: 8,
								items_per_page:1,
								labels:names,
								callback: function(page_index, jq){
									alert(this.labels[page_index]);
								}
							});
						},
						error	: function(xhr){
							alert('error');
						}
					});
				}
			});
		},
		error	: function(xhr){
			alert('error');
		}
	});
	*/		
	// end init
	setTimeout(function(){
		$('#loading').remove();
		$('#loading-mask').fadeOut({remove:true});
	}, 250);
});