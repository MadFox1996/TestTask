Ext.define('UM.controller.UserProductController', {
    extend: 'Ext.app.Controller',

    stores: ['ProductStore','OrderStore','OrderItemStore','BasketStore'],
   
    models: ['Product','Order','OrderItem','BasketModel'],

    views: ['product.List','order.Make','product.Basket','product.AddToBasket','product.EditBasket'],

    refs: [
        {
            ref: 'productsPanel',
            selector: 'panel'
        }
    ],

    init: function () {
        this.control({
            'userproductlist actioncolumn': {
                click: this.addToBasket
            },
            'addtobasket button[action=add]': {
                click: this.add
            },
            'basket button[action=createorder]':
            {
                click: this.createOrder
            },
            'basket button[action=resetbasket]':
            {
                click: this.resetBasket
            },
            'viewport > basket dataview':
            {
                itemdblclick: this.basketEdit
            },
            'basket actioncolumn':
            {
                click:this.delete
            },
            'editBasket [action=save]':
            {
                click: this.edit
            }
        });
    },

    addToBasket: function (view, cell, rowIndex, colIndex, e, record, row)
    {
        var create = Ext.create('UM.view.product.AddToBasket').show();
        create.down('form').loadRecord(record);  
    },
    add: function (button)
    {
        var win = button.up('window'),
            form = win.down('form'),
            values = form.getValues();

        var bs = Ext.getStore('BasketStore');



        var record = Ext.create("UM.model.BasketModel");
        

        var exist = bs.findRecord('id', values.id);

        if (exist != null)//Если товар уже добавлен
        {
            var newQuantity = Number(exist.data.QUANTITY) + Number(values.QUANTITY);
            exist.set('QUANTITY', String(newQuantity));
            bs.sync();
        }
        else
        {
            record.set('id', values.id);
            record.set('QUANTITY', values.QUANTITY);
            record.set('CODE', values.CODE);
            record.set('CATEGORY', values.CATEGORY);
            record.set('PRICE', values.PRICE);
            record.set('NAME', values.NAME);

            record.phantom = true;
            bs.add(record);
            bs.sync();
        }
        
        
        win.close();
    },
    resetBasket: function (button)
    {
        Ext.Msg.confirm('Reset Basket', 'Are you sure?', function (button) {
            if (button == 'yes') {
                var bs = Ext.getStore('BasketStore');
                var records = bs.data.items;
                var i = records.length;
                while (i--) {
                    bs.remove(records[i]);
                }
                bs.sync();
            }
        }, this);
    },
    createOrder: function (button)
    {
        var bStore = Ext.getStore('BasketStore');
        if (bStore.getCount() == 0) {
            Ext.MessageBox.show({
                title: "Error!",
                msg: "A Basket!",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
        else {
            Ext.Msg.confirm('Create Order', 'Create an order with the specified goods?', function (button) {
                if (button == 'yes') {

                    //order creation
                    var order_store = Ext.getStore('OrderStore');
                    var order = Ext.create("UM.model.Order");

                    var orderId = ((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-4' +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1).substr(0, 3) + '-' +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                        (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)).toLowerCase();
                    var orderNumber = Ext.id();
                    orderNumber = parseInt(orderNumber.replace("ext-gen", ""));
                    order.set('id', orderId);
                    order.set('ORDER_NUMBER', orderNumber);
                    order.set('status', 'New');
                    order_store.add(order);
                    order_store.sync();
                    //order created

                    //order items creations

                    var orderItemStore = Ext.getStore('OrderItemStore');
                    var bs = Ext.getStore('BasketStore');
                    var records = bs.data.items;
                    var i = records.length;

                    for (var z = 0; z < i; z++) {
                        var orderItemInfo = records[z].data;
                        var orderItem = Ext.create("UM.model.OrderItem");

                        var orderItemId = ((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-4' +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1).substr(0, 3) + '-' +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                            (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)).toLowerCase();

                        orderItem.set('id', orderItemId);
                        orderItem.set('PRODUCT_COUNTS', orderItemInfo.QUANTITY);
                        orderItem.set('PRICE', orderItemInfo.PRICE);
                        orderItem.set('OrderDTOid', orderId);
                        orderItem.set('ProductDTOid', orderItemInfo.id);

                        orderItemStore.add(orderItem);
                    }
                    //order items created
                    var buff = Ext.create("UM.model.OrderItem");
                    buff.set('id', null);
                    orderItemStore.add(buff);

                    i = records.length;
                    while (i--) {
                        bs.remove(records[i]);
                    }
                    bs.sync();
                    orderItemStore.sync();
                }
            }, this);
        }    
    },

    basketEdit: function (grid,record) {
        var editWin = Ext.create('UM.view.product.EditBasket').show();
        editWin.down('form').loadRecord(record);
    },
    edit: function (button) {
        var store = Ext.getStore('BasketStore');

        var win = button.up('window'),
            form = win.down('form'),
            record = form.getRecord(),
            values = form.getValues();

        if (form.getForm().isValid()) {
            record.set('QUANTITY', values.QUANTITY);
            win.close();
            store.sync();
        }
        else {
            Ext.MessageBox.show({
                title: "ERROR-A1001",
                msg: "Please fill the required fields correctly.",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
    },
    delete: function (view, cell, rowIndex, colIndex, e, record, row)
    {
        Ext.Msg.confirm('Remove Qualification', 'Are you sure?', function (button) {
            if (button == 'yes') {
                var store = Ext.getStore('BasketStore');
                store.remove(record);
                store.sync();
            }
        }, this);
    }
});