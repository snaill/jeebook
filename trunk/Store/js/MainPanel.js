/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */


Ext.app.MainPanel = function() {
	  
	// create the Grid
	this.grid = new Ext.app.StoreGrid();
	var tree = new Ext.app.StoreTree();
	
	Ext.app.MainPanel.superclass.constructor.call(this, {
		id 		  : 'MainPanel_Id',
		region    : 'center',
		margins   : '3 0 0 0', 
		layout    : 'border',
		defaults  : {
			autoScroll : true
		},
 		tbar: [ Ext.action.DownloadSite,
				'->',
				Ext.action.MainSite,
				Ext.action.BlogSite,
				Ext.action.CodeSite
		],
		items   : [tree, this.grid, 
				  new Ext.app.ContentPanel()
		] 
	});
};

Ext.extend(Ext.app.MainPanel, Ext.Panel, {
	onNotify : function( event ){
		Ext.app.ContentPanel.getObj().onNotify( event );
	},
	updateToolButton : function( o, action ){
		if ( o.disabled != null )	{
			action.setDisabled(o.disabled);
		}
	},
	updateToolbar : function( o ){
		if ( o.addFolder != null )	{
			this.updateToolButton( o.addFolder, Ext.getCmp('btn_addFolder') ); 
		}
		
		if ( o.addFile != null )	{
			this.updateToolButton( o.addFile, Ext.getCmp('btn_addFile') ); 
		}
				
		if ( o.rename != null )	{
			this.updateToolButton( o.rename, Ext.getCmp('btn_rename') ); 
		}
		
/* 		if ( o.delete != null )	{
			this.updateToolButton( o.delete, Ext.getCmp('btn_delete') ); 
		} */
	}
});

Ext.app.MainPanel.getObj = function(){
	return Ext.getCmp('MainPanel_Id');
};
