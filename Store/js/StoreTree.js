﻿/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

Ext.app.StoreTree = function() {
	
	Ext.app.StoreTree.superclass.constructor.call(this, {
		id			: 'StoreTree_Id',
	//	title       : 'Folders',
		region      : 'west',
		split       : true,
		useArrows	: true,
        animate		: true,
		width       : 200,
		collapsible : true,
		collapseMode:'mini',
		margins     : '3 0 3 3',
		cmargins    : '3 3 3 3',
		autoScroll 	: true,
		loader		: new Ext.app.StoreTreeLoader({
       		clearOnLoad:false
       	}),
		root 		: new Ext.tree.AsyncTreeNode({
			id:'data',
			text:'Store'
		})
	});

	this.on('click', function( node ) {
		Ext.app.StoreGrid.getObj().load( this.getPath(node) );
		
		var event = {};
		event.id = Ext.app.Event.FolderChanged;
		event.node = node;
		Ext.app.MainPanel.getObj().onNotify( event );
	}, this );
	
	this.getSelectionModel().select(this.root);
	this.root.expand();
};

Ext.extend(Ext.app.StoreTree, Ext.tree.TreePanel, {
	getPath : function( node ) {
		var s = node.getPath() + '/';
		s = s.substr(1);
		s = s.substr( s.indexOf('/') );
		return s;
	},
	getCurrentPath : function(){
		var node = this.getSelectionModel().getSelectedNode();
		if ( !node )
			node = this.root;
		return this.getPath( node );
	},
	refresh : function(){
		var node = this.getSelectionModel().getSelectedNode();
		if ( !node )
			node = this.root;
		node.reload();
	}
} );

Ext.app.StoreTree.getObj = function(){
	return Ext.getCmp('StoreTree_Id');
};