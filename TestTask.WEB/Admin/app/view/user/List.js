Ext.define('UM.view.user.List', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.userlist',

    title: 'All Users',
    store: 'UserStore',
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
            header: 'UserName', dataIndex: 'UserName', flex: 1
        },

        {
            header:'Role', dataIndex:'Role',flex:1
        },
     
        {
            header: 'Name', dataIndex: 'CustomerDTO', flex: 1,
            renderer: function (value, metaData, record, row, col, store, gridView) {
                if (record.data.Role != 'admin')
                    return value.NAME;
                else return "";
            }
        },

        {
            header: 'Code', dataIndex: 'CustomerDTO', flex: 1,
            renderer: function (value, metaData, record, row, col, store, gridView) {
                if (record.data.Role!= 'admin')
                    return value.CODE;
                else return "";
            }
        },

        {
            header: 'Adress', dataIndex: 'CustomerDTO', flex: 1,
            renderer: function (value, metaData, record, row, col, store, gridView) {
                if (record.data.Role != 'admin')
                    return value.ADRESS;
                else return "";
            }
        },

        {
            header: 'Discount', dataIndex: 'CustomerDTO', flex: 1,
            renderer: function (value, metaData, record, row, col, store, gridView) {
                if (record.data.Role != 'admin')
                    return value.DISCOUNT;
                else return "";
            }
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
            text: 'Create',
            action: 'create'
        }
        ]
    }
});


