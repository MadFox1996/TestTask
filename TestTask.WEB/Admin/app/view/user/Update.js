Ext.define('UM.view.user.Update', {
    extend: 'Ext.window.Window',
    alias: 'widget.userupdate',

    requires: ['Ext.form.Panel'],

    title: 'Edit User',
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
                        name: 'id',
                        fieldLabel: 'UserID'
                    },
                    {
                        xtype: 'textfield',
                        name: 'CustomerDTO_NAME',
                        fieldLabel: 'Name',
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        name: 'UserName',
                        fieldLabel: 'UserName',
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        name: 'CustomerDTO_CODE',
                        fieldLabel: 'Code',
                        allowBlank: false,
                        regex: /^\d{4}$/,
                        regexText: 'Input the code of customer in format XXXX where x is a number.'
                    },
                    {
                        xtype: 'textfield',
                        name: 'CustomerDTO_ADRESS',
                        fieldLabel: 'Adress',
                        allowBlank: true
                    },
                    {
                        xtype: 'textfield',
                        name: 'CustomerDTO_DISCOUNT',
                        fieldLabel: 'Discount',
                        allowBlank: true
                    },
                    {
                        xtype: 'combobox',
                        name: 'Role',
                        fieldLabel: 'Role',
                        allowBlank: false,
                        store: new Ext.data.SimpleStore({
                            fields:
                                [
                                    'Role'
                                ],
                            data:
                                [
                                    ['admin'],
                                    ['manager'],
                                    ['user']
                                ]
                        }),
                        valueField: 'Role',
                        displayField: 'Role',
                        queryMode: 'local'
                    }
                ]
            }
        ];
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
