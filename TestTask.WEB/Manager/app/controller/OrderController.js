Ext.define('UM.controller.OrderController', {
    extend: 'Ext.app.Controller',

    stores: ['OrderStore', 'OrderItemStore'],

    models: ['Order', 'OrderItem'],

    views: ['order.AdminOrders'],

    init: function () {
        this.control({
            'viewport > adminorderlist dataview': {
                itemdblclick: this.editOrder
            },
            'orderedit button[action=save]': {
                click: this.updateOrder
            }
        });
    },
    editOrder: function (grid, record) {
        var edit = Ext.create('UM.view.order.Edit').show();
        edit.down('form').loadRecord(record);
    },
    updateOrder: function (button) {
        var store = Ext.getStore('OrderStore');

        var win = button.up('window'),
            form = win.down('form'),
            record = form.getRecord(),
            values = form.getValues();

        if (form.getForm().isValid()) {
            var order = store.findRecord('id', record.data.id);

            order.set('status', values.status);
            order.set('SHIPMENT_DATE', values.SHIPMENT_DATE);
            win.close();
            store.sync();
        }
        else {
            Ext.MessageBox.show({
                title: "ERROR!",
                msg: "Please fill the required fields correctly.",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
    }
});