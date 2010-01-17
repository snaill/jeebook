/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

$(document).ready(function(){
	
	$("div#cmdbar").corner("tl bl 24px");
	
	$("div#msgbar").msgbar({msg:'test'});

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
	//	name: 'myfile',
		onSubmit : function(file, ext){
			// Allow only images. You should add security check on the server-side.
			if (!(ext && /^(bmp|png|jpeg|gif)$/.test(ext))){
				// extension is not allowed
				$('#example2 .text').text('Error: only images are allowed');
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
	$.ajax({
		url 	: 'api/category/upload/',
		type	: "GET",
		async	: true,
		dataType : 'json',
		success : function(data){
			var labels = [];
			for ( var i = 0; i < data.length; i ++ )
				labels[i] = data[i].name;
			
			$("div#pagination").pagination(data.length, {
				num_edge_entries: 2,
				num_display_entries: 8,
				callback: function(page_index, jq){
				},
				items_per_page:1
			});
		},
		error	: function(xhr){
			alert('error');
		}
	});
			
	// end init
	setTimeout(function(){
		$('#loading').remove();
		$('#loading-mask').fadeOut({remove:true});
	}, 250);
});