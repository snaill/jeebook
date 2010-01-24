/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

$(document).ready(function(){
	//
	$("#reader").xslt("data/upload/A/_test.jb/index.xml", "xslt/default/index.xslt");

	// end init
	setTimeout(function(){
		$('#loading').remove();
		$('#loading-mask').fadeOut({remove:true});
	}, 250);
});