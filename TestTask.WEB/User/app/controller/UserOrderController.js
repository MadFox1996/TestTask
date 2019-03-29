Ext.define('UM.controller.UserOrderController', {
    extend: 'Ext.app.Controller',

    stores: ['OrderStore', 'OrderItemStore'],

    models: ['Order','OrderItem'],

    views:['order.List','order.Delete'],

    init: function () {
        this.control({
            'myorderlist actioncolumn': {
                click: this.deleteOrder
            }
        });
    },
    deleteOrder: function (view, cell, rowIndex, colIndex, e, record, row) {
        if (record.data.status == 'New')
        {
            Ext.Msg.confirm('Remove Qualification', 'Are you sure?', function (button) {
                if (button == 'yes')
                {
                    var Orderstore = Ext.getStore('OrderStore');
                    var OrderItemStore = Ext.getStore('OrderItemStore');

                    var orderItems = OrderItemStore.query('OrderDTOid', record.data.id);
                    
                    for (var i = 0, len = orderItems.length; i < len; i++) {
                        var example = orderItems.items[i];
                        OrderItemStore.remove(example);
                    }
                   
                    OrderItemStore.sync();
                 
                    Orderstore.remove(record);
                    Orderstore.sync();
                }
            }, this);
        }
        else {
            Ext.MessageBox.show({
                title: "ATTENTION",
                msg: "Sorry, you can't delete order. Order is executing or executed ",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
    }
});