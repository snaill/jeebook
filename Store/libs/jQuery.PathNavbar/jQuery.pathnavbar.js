/*
 * jQuery.PathNavbar 1.0
 * Copyright(c) 2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */
 
 /*
	/jeebook/trunk/Store/libs/jQuery.PathNavbar
	size : 3
	<ul class="pnb-nav-ul">
		<li>
			<span>Store</span>
			<ul>
				<li>jeebook</li>
				<li>trunk</li>
			</ul>
		</li>
		<li>
			<span>libs</span>
		</li>
		<li>
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
				html.append('<li><span style="padding-right: 23px">' + s[i]);
				html.append('<img src="' + pnb.settings.rightIcon + '" class="' + pnb.settings.rightCss + '" style="border:0;" /></span>');					
				if ( i == index )
				{
					html.append('<ul>');	
					for ( var j = 0; j < index; j ++ )
					{
						html.append('<li><span>' + s[j] + '</span></li>');
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
			pnb.settings = $.extend({}, pnb.defaults, options);
			$(this).html(path2html(pnb.settings.path, pnb.settings.size));
			
			var $mainmenu = $(this).children('ul:eq(0)');
			$mainmenu.parent().get(0).className = pnb.settings.classname;
			var $headers=$mainmenu.find('ul').parent();
			$headers.hover(
				function(e){
					$(this).children('span:eq(0)').addClass('selected');
					$(this).find('span>img').attr('src', 'down.gif');			
					$(this).find('span>img').attr('className', 'downarrowclass');		
				},
				function(e){
					$(this).children('span:eq(0)').removeClass('selected');
					$(this).find('span>img').attr('src', 'right.gif');
					$(this).find('span>img').attr('className', 'rightarrowclass');		
				}
			) 
			
			$headers.each(function(i){ //loop through each LI header
				var $curobj=$(this).css({zIndex: 100-i}); //reference current LI header
				var $subul=$(this).find('ul:eq(0)').css({display:'block'});
				this._dimensions={w:this.offsetWidth, h:this.offsetHeight, subulw:$subul.outerWidth(), subulh:$subul.outerHeight()};
				this.istopheader=$curobj.parents("ul").length==1? true : false; //is top level header?
				$subul.css({top:this.istopheader ? this._dimensions.h+"px" : 0});

				$curobj.hover(
					function(e){
						var $targetul=$(this).children("ul:eq(0)")
						this._offsets={left:$(this).offset().left, top:$(this).offset().top};
						var menuleft=this.istopheader ? 0 : this._dimensions.w;
						menuleft=(this._offsets.left+menuleft+this._dimensions.subulw>$(window).width())? (this.istopheader? -this._dimensions.subulw+this._dimensions.w : -this._dimensions.w) : menuleft; //calculate this sub menu's offsets from its parent
						if ($targetul.queue().length<=1){ //if 1 or less queued animations
							$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).animate({height:'show',opacity:'show'}, 300);
						}
					},
					function(e){
						var $targetul=$(this).children("ul:eq(0)");
						$targetul.animate({height:'hide', opacity:'hide'}, 300);
					}
				) //end hover
			})
			$mainmenu.find("ul").css({display:'none', visibility:'visible'});
		   /*
			
			$(this).click(function(){
			alert("this");
			});
				
			$(this).find('ul li span').hover(function(){
			$(this).parent().find('ul:first').css({visibility: "visible",display: "none"}).show(400);
			}, function(){
			$(this).parent().find('ul:first').css({visibility: "hidden"});
			});
						
			$(this).find('ul li span[class!="drop"]').click(function(){
			$(this).parent().nextAll().remove();
					
			if ( settings.callback != null )
				settings.callback(getPath($(this).parent()));
			});*/
		});
    };
    
    var pnb = $.fn.pathnavbar;
    pnb.defaults = {
        path : '/',
		size : 5,
		classname : 'ddsmoothmenu',
		downIcon : 'down.gif',
		rightIcon : 'right.gif',
		downCss : 'downarrowclass',
		rightCss : 'rightarrowclass'		
    };
    pnb.settings = {};
})(jQuery);