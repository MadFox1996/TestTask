Ext.define('UM.controller.ProductController', {
    extend: 'Ext.app.Controller',

    stores: ['ProductStore','OrderItemStore'],

    models: ['Product','OrderItem'],

    views: ['product.List', 'product.Edit', 'product.Create'],

    refs: [
        {
            ref: 'productsPanel',
            selector: 'panel'
        },
        {
            ref: 'productCreate',
            selector: 'productcreate'
        }
    ],

    init: function () {
        this.control({
            'viewport > productlist dataview': {
                itemdblclick: this.editProduct
            },
            'productedit button[action=save]': {
                click: this.updateProduct
            },
            'productlist button[action=create]':
            {
                click: this.createProduct
            },
            'productcreate button[action=add]':
            {
                click: this.addProduct
            },
            'productlist actioncolumn': {
                click: this.delete
            },
            'productdelete button[action=delete]': {
                click: this.deleteProduct
            }
        });
    },

    editProduct: function (grid, record) {
        var edit = Ext.create('UM.view.product.Edit').show();
        edit.down('form').loadRecord(record);
    },

    updateProduct: function (button)
    {
        var store = Ext.getStore('ProductStore');

        var win = button.up('window'),
            form = win.down('form'),
            record = form.getRecord(),
            values = form.getValues();
        if (form.getForm().isValid())
        {
            record.set('NAME', values.NAME);
            record.set('PRICE', values.PRICE);
            record.set('CODE', values.CODE);
            record.set('CATEGORY', values.CATEGORY);
            win.close();
            store.sync();
        }
        else
        {
            Ext.MessageBox.show({
                title: "ERROR-A1001",
                msg: "Please fill the required fields correctly.",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
},
    createProduct: function (button) {
        var create = Ext.create('UM.view.product.Create').show();
    },

    addProduct: function (button) {
            var win = button.up('window'),
                form = win.down('form'),
                values = form.getValues();
        if (form.getForm().isValid())
        {
            var store = Ext.getStore('ProductStore');
            var rec = Ext.create('UM.model.Product');
            rec.set('NAME', values.NAME);
            rec.set('PRICE', values.PRICE);
            rec.set('CODE', values.CODE);
            rec.set('CATEGORY', values.CATEGORY);
            var id = ((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-4' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1).substr(0, 3) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)).toLowerCase();
            rec.set('id', id);
            store.add(rec);
            win.close();
            store.sync();
        } else {
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
        var ProductStore = Ext.getStore('ProductStore');
        var OrderItemStore = Ext.getStore('OrderItemStore');

        var orderItems = OrderItemStore.query('ProductDTOid', record.data.id);

        if (orderItems.length == 0) {
            Ext.Msg.confirm('Remove Qualification', 'Are you sure?', function (button) {
                if (button == 'yes') {
                    ProductStore.remove(record);
                    ProductStore.sync();
                }
            }, this);
        }
        else
        {
            Ext.MessageBox.show({
                title: "ERROR!!!",
                msg: "You can not remove the good that contained in the order!",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
    }
});