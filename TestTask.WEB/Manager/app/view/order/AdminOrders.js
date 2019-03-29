Ext.define('UM.view.order.AdminOrders', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.adminorderlist',

    title: 'All Orders',
    store: 'OrderStore',
    padding: 55,

    requires: [
        'Ext.grid.column.Action',
        'Ext.grid.*',
        'Ext.data.*',
        'Ext.ux.grid.FiltersFeature',
        'Ext.toolbar.Paging',
        'Ext.ux.ajax.JsonSimlet',
        'Ext.ux.ajax.SimManager'
    ],
    xtype: 'array-grid',
    //stateful: true,
    stateId: 'stateGrid',
    //viewConfig: {
    //    stripeRows: true,
    //    enableTextSelection: true
    //},

    layout: 'fit',

    columns: [
        {
            header: 'Order Date', dataIndex: 'ORDER_DATE', flex: 1
        },

        {
            header: 'Shipment Date', dataIndex: 'SHIPMENT_DATE', flex: 1
        },

        {
            header: 'Order Number', dataIndex: 'ORDER_NUMBER', flex: 1
        },
        {
            header: 'Status', dataIndex: 'status', flex: 1, filterable: true,
            filter: {
                type: 'list',
                store: Ext.data.StoreManager.lookup('OrderStore'),
                options: ['New','Completed','Execution']
            }
        }
    ],
    features: [
        { ftype: 'filters',local:true }
    ]
});