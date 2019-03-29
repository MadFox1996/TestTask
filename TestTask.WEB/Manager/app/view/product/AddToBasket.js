Ext.define('UM.view.product.AddToBasket', {
    extend: 'Ext.window.Window',
    alias: 'widget.addtobasket',

    requires: ['Ext.form.Panel'],

    title: 'Add to Basket',
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
                        fieldLabel: 'ProductID'
                    },
                    {
                        xtype: 'hiddenfield',
                        name: 'NAME',
                        fieldLabel: 'Name'
                    },
                    {
                        xtype: 'hiddenfield',
                        name: 'PRICE',
                        fieldLabel: 'Price'
                    },
                    {
                        xtype: 'hiddenfield',
                        name: 'CODE',
                        fieldLabel: 'Code'
                    },
                    {
                        xtype: 'hiddenfield',
                        name: 'CATEGORY',
                        fieldLabel: 'Category'
                    },
                    {
                        xtype: 'textfield',
                        name: 'QUANTITY',
                        fieldLabel: 'Quantity:',
                        regex: /^[1-9][0-9]?$|^100$/,
                        regexText: 'Only numbers allowed.',
                        allowBlank: false
                    }
                ]
            }
        ];
        this.buttons = [
            {
                text: 'Add',
                action: 'add'
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
