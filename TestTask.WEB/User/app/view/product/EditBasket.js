Ext.define('UM.view.product.EditBasket', {
    extend: 'Ext.window.Window',
    alias: 'widget.editBasket',

    requires: ['Ext.form.Panel'],

    title: 'Edit Item',
    layout: 'fit',
    autoShow: true,
    height: 380,
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
                        regexText: 'Only numbers allowed.'
                    },
                ]
            },];
        this.buttons = [
            {
                text: 'Save',
                action: 'save'
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
