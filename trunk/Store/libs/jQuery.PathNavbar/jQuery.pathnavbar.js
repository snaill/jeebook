/*
 * jQuery.PathNavbar 1.0
 * Copyright(c) 2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

;(function($){
    $.fn.pathnavbar = function( options ) {
        var pnb = $.fn.pathnavbar,
		getItemsByPath = function(p) {
			var s = p.split('/');
			var items = [];
			for (var i = 0, j = 0; i < s.length; i ++ )
			{
				if ( s[i] == "" )
					continue;
				items[j++] = {name:s[i], isLeaf:false};
			}
			return items;
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
	    },
		rebuild = function(o, items) {
			var html = new StringBuilder();
			var index = 0;
			
			html.append('<ul class="jq-menu-topmenu">');	
			if ( items.length > pnb.settings.size )
			{
				index = items.length - pnb.settings.size;
				html.append('<li><span><img src="' + pnb.settings.baseIcon + '" />');	
				html.append('<img src="' + pnb.settings.rightIcon + '" class="' + pnb.settings.rightCss + '"/>');
				html.append('</span>');
				html.append('<ul class="jq-menu-foldmenu">');	
				for ( var j = 0; j < index; j ++ )
				{
					html.append('<li><span>' + items[j].name + '</span></li>');
				}
				html.append('</ul></li>');
			}

			for (var i = index; i < items.length; i ++ )
			{
				html.append('<li><span>' + items[i].name);
				if ( !items[i].isLeaf )
					html.append('<img src="' + pnb.settings.rightIcon + '" class="' + pnb.settings.rightCss + '"/>');		
				html.append('</span>');
				if ( items[i].subs != null )
				{
					html.append('<ul class="jq-menu-submenu">');
					for ( var j = 0; j < items[i].subs.length; j ++ )
					{
						html.append('<li><span>' + items[i].subs[j].name + '</span></li>');
					}
					html.append('</ul>');
				}
				html.append('</li>');
			}
			html.append('</ul>');
			o.html(html.toString());
		};
		
		return this.each(function(){
			pnb.settings = $.extend({}, pnb.defaults, options);
			
			var items = getItemsByPath(pnb.settings.path);
			rebuild($(this), items);
			
			var $mainmenu = $(this).children('ul[class="jq-menu-topmenu"]');
			$mainmenu.parent().get(0).className = pnb.settings.classname;
			var $headers=$mainmenu.find('ul').parent();
			$headers.hover(
				function(e){
					$(this).children('span:eq(0)').addClass('jq-item-selected');
					$(this).find('span>img:last()').attr({
						src : pnb.settings.downIcon,
						className : pnb.settings.downCss
					});
				},
				function(e){
					$(this).children('span:eq(0)').removeClass('jq-item-selected');
					$(this).find('span>img:last()').attr({
						src : pnb.settings.rightIcon,
						className : pnb.settings.rightCss
					});
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
		classname : 'jq-menu',
		downIcon : 'down.gif',
		rightIcon : 'right.gif',
		baseIcon : 'base.gif',
		downCss : 'jq-item-downarrow',
		rightCss : 'jq-item-rightarrow'		
    };
    pnb.settings = {};
})(jQuery);