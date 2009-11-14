/*
 * Jeebook store 1.0
 * Copyright(c) 2008, Jeebook.com
 * snaill@jeebook.com
 * 
 * http://www.jeebook.com
 */

Ext.app.StoreGrid = function() {

	var store = new Ext.data.Store({
		url: 'ashx/GetFiles.ashx',
		baseParam: { path:'aa'},
		reader: new Ext.data.JsonReader({
			// metadata configuration options:
		//	idProperty: 'id'          
			root: 'data',             
		//	totalProperty: 'results', 
			
			// the fields config option will internally create an Ext.data.Record
			// constructor that provides mapping for reading the record data objects
			fields: [
				{name: 'name'},
				{name: 'size'},
				{name: 'time', type: 'date', dateFormat:'Y-m-d H:i:s'},
				{name: 'extension'}
			]    
		})
	});
	Ext.app.StoreGrid.superclass.constructor.call(this, {
		id : 'StoreGrid_Id',
		store: store,
		columns: [
			{width: 16, renderer: this.formatIcon, dataIndex: 'extension'},
			{header: "Name", width: 200, sortable: true, dataIndex: 'name'},
			{header: "Size", width: 60, sortable: true, renderer: this.formatSize, dataIndex: 'size', align : 'right' },
			{header: "Upload time", width: 70, sortable: true, xtype: 'datecolumn', format:'Y-m-d H:i:s', dataIndex: 'time'}
		],
		viewConfig: {
            forceFit:true,
            enableRowBody:true,
            showPreview:true,
            getRowClass : function(record, rowIndex, p, store){
                if( this.showPreview && record.data.remark != null ){
                    p.body = '<p>'+record.data.remark+'</p>';
                    return 'x-grid3-row-expanded';
                }
                return 'x-grid3-row-collapsed';
            }
        },

 		// bbar : new Ext.PagingToolbar({
			// pageSize: 25,
			// store: store, 
			// displayInfo: true,
			// displayMsg: 'Displaying {0} - {1} of {2}',
			// emptyMsg: 'No data to display'
		// }), 
		stripeRows: true,
		margins     : '3 3 3 0',
		cmargins    : '3 3 3 3',
		region:'center'
	});

	this.on('rowdblclick', this.onRowdblclick, this );
};

Ext.extend(Ext.app.StoreGrid, Ext.grid.GridPanel, {
	load : function(path)	{
		var url = 'ashx/GetFiles.ashx?path=' + encodeURIComponent(path);
		this.store.proxy = new Ext.data.HttpProxy( { url : url } );
		this.store.reload();
	},
	onRowdblclick : function( grid, rowIndex, e ) {
		var url = window.location.href;
		url = url.replace( window.location.protocol + '//', 'jeebook://' );
		url = url.substr( 0, url.lastIndexOf( '/' ) + 1 ) + 'ashx/Get.ashx?path=' + Ext.app.StoreTree.getObj().getCurrentPath() 
						+ grid.store.getAt(rowIndex).get('name') + grid.store.getAt(rowIndex).get('extension');
		window.location = url;
	},
	formatIcon : function( extension )	{
		if ( extension == '.jb' )
			return '<img src="images/jb.png" alt="Jeebook Document" />';
		return '<img src="images/unknown.png" alt="Unknown Document" />';
	},
	formatSize : function( size )	{
		return Ext.util.Format.fileSize(size);
	},
	formatDate : function( date )	{
		return date.toLocaleString()
	},
	refresh : function()	{
		this.load( Ext.app.StoreTree.getObj().getCurrentPath() );
	}
});

Ext.app.StoreGrid.getObj = function(){
	return Ext.getCmp('StoreGrid_Id');
};
