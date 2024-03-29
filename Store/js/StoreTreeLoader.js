﻿/*
 * Jeebook store 2.0
 * Copyright(c) 2008-2009, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */


Ext.app.StoreTreeLoader = Ext.extend( Ext.tree.TreeLoader, {
	load : function(node, callback){
        if(this.clearOnLoad){
            while(node.firstChild){
                node.removeChild(node.firstChild);
            }
        }
        if(this.doPreload(node)){ // preloaded json children
            if(typeof callback == "function"){
                callback();
            }
        }else if(node.attributes){
            this.requestData(node, callback);
        }
    },
    requestData : function(node, callback){
        if(this.fireEvent("beforeload", this, node, callback) !== false){
			var nodePath = Ext.app.StoreTree.getObj().getPath( node );
 			var url = 'category' + nodePath;
			this.transId = Ext.Ajax.request({
                method:'GET',
                url: url,
                success: this.handleResponse,
                failure: this.handleFailure,
                scope: this,
                argument: {callback: callback, node: node}
            });
        }else{
            // if the load is cancelled, make sure we notify
            // the node that we are done
            if(typeof callback == "function"){
                callback();
            }
        }
    },

    /**
    * Override this function for custom TreeNode node implementation
    */
    createNode : function( dir ){
		return	new Ext.tree.AsyncTreeNode({
			id : dir.name,
			text : dir.name,
			leaf : dir.leaf
		});
    },

    processResponse : function(response, node, callback){
		var o = Ext.decode( response.responseText );
        try {
			node.beginUpdate();
			for ( var i = 0; i < o.length; i ++ )
			{
				var n = this.createNode( o[i] );
				if ( n )
					node.appendChild(n);
			}
            node.endUpdate();
            if(typeof callback == "function"){
                callback(this, node);
            }
        }catch(e){
            this.handleFailure(response);
        }
    },
		
	handleFailure : function(response){
        this.transId = false;
        var a = response.argument;
        this.fireEvent("loadexception", this, a.node, response);
        if(typeof a.callback == "function"){
            a.callback(this, a.node);
        }
    }
} );