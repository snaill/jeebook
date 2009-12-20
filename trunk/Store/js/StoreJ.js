/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

$(document).ready(function(){
	var o = $.jeebook.getDirectories('/');
	
	// navbar
	$('#navbar').pathnavbar({
		path : '/jeebook/trunk/Store/libs/jQuery.PathNavbar',
		size : 3,
		callback : function(p) {
			alert(p);
		}
	});
/* 	ddsmoothmenu.init({
		mainmenuid: "navbar", //menu DIV id
		orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
		classname: 'ddsmoothmenu', //class added to menu's outer DIV
		//customtheme: ["#1c5a80", "#18374a"],
		contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
	});	 */		

	// initialize tooltip 
	$("#toolbox button[title]").tooltip({ 

		// use single tooltip element for all tips 
		tip: '#toolboxtip',  
		 
		// tweak the position 
		offset: [10, 2], 
		 
		// use "slide" effect 
		effect: 'slide' 
		 
	// add dynamic plugin  
	}).dynamic( { 
	 
		// customized configuration on bottom edge 
		bottom: { 
		 
			// slide downwards 
			direction: 'down', 
			 
			// bounce back when closed 
			bounce: true 
		} 
	}); 

	// toolbox
	var triggers = $("button.modalInput").overlay({ 
 
		// some expose tweaks suitable for modal dialogs 
		expose: { 
			color: '#333', 
			loadSpeed: 200, 
			opacity: 0.9 
		}, 
	 
		closeOnClick: false 
	});
	
	$("#prompt form").submit(function(e) { 
 
		// close the overlay 
		triggers.eq(1).overlay().close(); 
	 
		// get user input 
		var input = $("input", this).val(); 
	 
		// do something with the answer 
		triggers.eq(1).html(input); 
	 
		// do not submit the form 
		return e.preventDefault(); 
	});
	
	// bookpanel
	// initialize scrollable 
	$("div.scrollable").scrollable({
		vertical:true, 
		size: 3
		
	// use mousewheel plugin
	}).mousewheel();	
	
	// if the function argument is given to overlay, 
    // it is assumed to be the onBeforeLoad event listener 
    $("a[rel]").overlay({ 
 
        expose: 'darkred', 
        effect: 'apple', 
 
        onBeforeLoad: function() { 
 
            // grab wrapper element inside content 
            var wrap = this.getContent().find(".contentWrap"); 
 
            // load the page specified in the trigger 
            wrap.load(this.getTrigger().attr("href")); 
        } 
 
    });
	
	// end init
	setTimeout(function(){
		$('#loading').remove();
		$('#loading-mask').fadeOut({remove:true});
	}, 250);
});