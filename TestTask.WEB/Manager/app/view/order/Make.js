Ext.define('UM.view.order.Make', {
    extend: 'Ext.window.Window',
    alias: 'widget.makeorder',

    requires: ['Ext.form.Panel'],

    title: 'Make Order',
    layout: 'fit',
    autoShow: true,
    height: 120,
    width: 280,

    initComponent: function () {
        this.items = [
            {
                xtype: 'form',
                padding: '5 5 0 5',
                border: false,
                style: 'background-color: #fff;',

                items: [
                    {
                        xtype: 'hiddenfield',
                        name: 'id',
                        fieldLabel:'ProductID'
                    },
                    {
                        xtype: 'hiddenfield',
                        name: 'PRICE',
                        fieldLabel:'Price'
                    },
                    {
                        xtype: 'textfield',
                        name: 'PRODUCT_COUNTS',
                        fieldLabel: 'Quantity:',
                        regex: /^[1-9][0-9]?$|^100$/,
                        regexText: 'Only numbers allowed.'
                    }
                ]
            }
        ];
        this.buttons = [
            {
                text: 'Order',
                action: 'order'
            },
            {
                text: 'Cancel',
                scope: this,
                handler: this.close
            }
        ];
        this.callParent(arguments);
    }
});
