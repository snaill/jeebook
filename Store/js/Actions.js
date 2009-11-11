/*
 * Jeebook store 1.0
 * Copyright(c) 2008, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */
Ext.app.Actions = function() {
	this.AddFolder = new Ext.Action({
				id:'btn_addFolder',
				text: Ext.app.Resource.Toolbar.AddFolder,
				disabled : false,
				tooltip: {title:'Add folder',text:'Add sub folder to current path.'},
				enableToggle : true,
				handler: function() {
					Ext.app.ContentPanel.getObj().showPanel( new Ext.app.AddFolderPanel(), Ext.getCmp('btn_addFolder') );
				},
				scope:this
			});

	this.AddFile = new Ext.Action({
				id:'btn_addFile',
				text:Ext.app.Resource.Toolbar.AddFile,
				disabled : false,			
				tooltip: {title:'Add document',text:'Upload document to current folder.'},
				enableToggle : true,
				handler: function() {
					Ext.app.ContentPanel.getObj().showPanel( new Ext.app.AddFilePanel(), Ext.getCmp('btn_addFile') );
				},
				scope:this
			});
	this.Rename = new Ext.Action({
				id:'btn_rename',
				text:Ext.app.Resource.Toolbar.Rename,
				disabled : true,			
				tooltip: {title:'Rname',text:'Rname current folder or document.'},
				enableToggle : true,
				handler: function() {
					Ext.app.ContentPanel.getObj().showPanel( new Ext.app.AddFilePanel(), Ext.getCmp('btn_rename') );	
				},
				scope:this
			});
	this.Delete = new Ext.Action({
				id:'btn_delete',
				text:Ext.app.Resource.Toolbar.Delete,
				disabled : true,			
				tooltip: {title:'Delete',text:'Delete current folder or document.'},
				enableToggle : true,
				handler: function() {
					Ext.app.ContentPanel.getObj().showPanel( new Ext.app.AddFilePanel(), Ext.getCmp('btn_delete') );	
				},
				scope:this
			});
	this.DownloadSite = new Ext.Action({
					id:"Action_DownloadSite_Id",
					text: Ext.app.Resource.Toolbar.DownloadSite,
					icon:'images/down.gif',
					handler: function() {
						window.location='http://www.jeebook.com';
					},
					scope:this
				});		
	this.MainSite = new Ext.Action({
					id:"btn_mainSite",
					text: Ext.app.Resource.Toolbar.MainSite,
					handler: function() {
						window.location='http://www.jeebook.com';
					},
					scope:this
				});
				
	this.BlogSite = new Ext.Action({
					id:"btn_blogSite",
					text:Ext.app.Resource.Toolbar.BlogSite,
					handler: function() {
						window.location='http://www.jeebook.com/blog';				
					},
					scope:this
				});
				
	this.CodeSite = new Ext.Action({
					id: 'btn_Code',
					text:Ext.app.Resource.Toolbar.CodeSite,
					handler: function() {
						window.location='http://code.google.com/p/jeebook';						
					},
					scope:this
				}); 
	this.Help = new Ext.Action({
					id:"btn_help",
					text:Ext.app.Resource.Toolbar.Help,
					handler: this.onHelp,
					scope:this
				});
};