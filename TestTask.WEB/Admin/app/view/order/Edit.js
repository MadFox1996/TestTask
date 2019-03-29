Ext.define('UM.view.order.Edit', {
    extend: 'Ext.window.Window',
    alias: 'widget.orderedit',

    requires: ['Ext.form.Panel'],

    title: 'Edit Goods',
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
                        xtype: 'datefield',
                        name: 'SHIPMENT_DATE',
                        fieldLabel: 'Shipment date',
                        allowBlak: true
                    },
                    {
                        xtype: 'combobox',
                        name: 'status',
                        fieldLabel: 'Status',
                        allowBlank: false,
                        store: new Ext.data.SimpleStore({
                            fields:
                                [
                                  
                                    'status'
                                ],
                            data:
                            [
                                ['New'],
                                ['Execution'],
                                ['Completed']
                            ]
                        }),
                        valueField: 'status',
                        displayField: 'status',
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
