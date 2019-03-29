Ext.define('UM.view.product.Basket', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.basket',

    title: 'My Basket',
    store: 'BasketStore',
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
    autoload: true,
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
            header: 'Quantity', dataIndex: 'QUANTITY', flex: 1
        },
        {
            xtype: 'actioncolumn',
            width: 50,
            items:
                [{
                    icon: 'delete-icon.png',
                    tooltip: 'delete',
                    type: 'delete'
                }]
        }
    ],
    header: {
        xtype: 'header',
        layout: 'fit',
        items: [{
            xtype: 'button',
            text: 'Create Order',
            action: 'createorder'
        },
        {
            xtype: 'button',
            text: 'Reset',
            action: 'resetbasket'
        }
        ]
    }
});


