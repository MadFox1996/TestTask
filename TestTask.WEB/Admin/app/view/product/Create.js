Ext.define('UM.view.product.Create', {
    extend: 'Ext.window.Window',
    alias: 'widget.productcreate',

    requires: ['Ext.form.Panel'],

    title: 'Create Product',
    layout: 'fit',
    autoShow: true,
    height: 180,
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
                        xtype: 'textfield',
                        name: 'NAME',
                        fieldLabel: 'NAME',
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        name: 'PRICE',
                        fieldLabel: 'PRICE',
                        regex: /^\d+$/,
                        allowBlank: false,
                        regexText:"Price must contain only digits"
                    },
                    {
                        xtype: 'textfield',
                        name: 'CODE',
                        fieldLabel: 'CODE',
                        allowBlank: false,
                        regex:/^[0-9]{4}-[0-9]{4}-[A-Z]{2}[0-9]{2}$/,
                        regexText:"xxxx-xxxx-yyxx - code format. x is digit and y - is capital letter "
                    },
                    {
                        xtype: 'textfield',
                        name: 'CATEGORY',
                        fieldLabel: 'CATEGORY'
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