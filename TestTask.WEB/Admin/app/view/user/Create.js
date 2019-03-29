Ext.define('UM.view.user.Create', {
    extend: 'Ext.window.Window',
    alias: 'widget.createUser',

    requires: ['Ext.form.Panel'],

    title: 'Create User',
    layout: 'fit',
    autoShow: true,
    height: 280,
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
                        name: 'NAME',
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
                        name: 'CODE',
                        fieldLabel: 'Code',
                        allowBlank: false,
                        regex: /^\d{4}$/,
                        regexText:'Input the code of customer in format XXXX where x is a number.'
                    },
                    {
                        xtype: 'textfield',
                        name: 'ADRESS',
                        fieldLabel: 'Adress',
                        allowBlank: true
                    },
                    {
                        xtype: 'textfield',
                        name: 'DISCOUNT',
                        fieldLabel: 'Discount',
                        allowBlank: true
                    },
                    {
                        xtype: 'combobox',
                        name: 'Role',
                        fieldLabel: 'Role',
                        allowBlank: false,
                        forceSelection: true,
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
                    },
                    {
                        xtype:'textfield',
                        inputType: 'password',
                        id:'txt_password',
                        name: 'Password',
                        fieldLabel: 'Password',
                        allowBlank: false
                    },
                    {
                        xtype: 'textfield',
                        id: "txt_confirmPassword",
                        name: "password_confirm",
                        fieldLabel: "Confirm Password",
                        validationEvent: "blur",
                        initialPin: "password",
                        allowBlank: false,
                        maxLength: 20,
                        inputType: "password",
                        
                        validator: function () {
                            var pass1 = Ext.getCmp('txt_password').getValue();
                            var pass2 = Ext.getCmp('txt_confirmPassword').getValue();
                        
                            if (pass1 == pass2)
                                return true;
                            else
                                return 'Passwords must match!';
                        }
                    }
                ]
            }
        ];
        this.buttons = [
            {
                text: 'Create',
                action: 'create'
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
