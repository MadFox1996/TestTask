Ext.define('UM.view.product.userList', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.userproductlist',

    title: 'All Goods',
    store: 'ProductStore',
    padding: 55,

    requires: [
        'Ext.grid.column.Action'
    ],
    xtype: 'array-grid',
    stateful: true,
    stateId: 'stateGrid',
    viewConfig: {
        stripeRows: true,
        enableTextSelection: true
    },

    layout: 'fit',
   
    columns: [
        {
            header: 'Name', dataIndex: 'NAME', flex: 1
        },

        {
            header: 'Price', dataIndex: 'PRICE', flex: 1
        },

        {
            header: 'Code', dataIndex: 'CODE', flex: 1
        },

        {
            header: 'Category', dataIndex: 'CATEGORY', flex: 1
        },

        {
            xtype: 'actioncolumn',
            width: 50,
            items:
            [{
                icon: 'order-icon.png',
                    tooltip: 'delete',
                    type:'delete'
            }]
        }
    ]
});


