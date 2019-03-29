Ext.define('UM.controller.UserController', {
    extend: 'Ext.app.Controller',

    stores: ['CustomerStore', 'UserStore','OrderStore'],

    models: ['Customer', 'User','Order'],

    views: ['user.List'],

    init: function () {
        this.control({
            'viewport > userlist dataview': {
                itemdblclick: this.editUser
            },
            'userupdate button[action=save]': {
                click: this.updateUser
            },
            'userlist button[action=create]': {
                click: this.createUser
            },
            'createUser button[action=create]': {
                click: this.AddUser
            },
            'userlist actioncolumn': {
                click: this.delete
            }
        });
    },

    createUser: function (button) {
        var Create = Ext.create('UM.view.user.Create').show();
    },

    AddUser: function (button) {
        var win = button.up('window'),
            form = win.down('form'),
            values = form.getValues();
        if (form.getForm().isValid()) {

            var store = Ext.getStore('UserStore');
            var CustomerStore = Ext.getStore('CustomerStore');

            var rec = Ext.create('UM.model.User');
            var record = Ext.create('UM.model.Customer');

            var id = ((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-4' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1).substr(0, 3) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)).toLowerCase();

            var customerId = ((((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-4' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1).substr(0, 3) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) + '-' +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1) +
                (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)).toLowerCase();

            rec.set('id', id);
            rec.set('UserName', values.UserName);
            rec.set('Role', values.Role);
            rec.set('Password', values.Password);

            record.set('id', customerId);
            record.set('NAME', values.NAME);
            record.set('CODE',values.CODE);
            record.set('ADRESS', values.ADRESS);
            record.set('DISCOUNT', values.DISCOUNT);

            rec.set('CustomerDTO', record.data);
            

            store.add(rec);
            CustomerStore.add(record);
            win.close();
            store.sync();
            CustomerStore.sync();
        } else {
            Ext.MessageBox.show({
                title: "ERROR!",
                msg: "Please fill the required fields correctly.",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        }
    },

    editUser: function (grid, record) {
        var edit = Ext.create('UM.view.user.Update').show();
        rec = record;
        rec.set('CustomerDTO_NAME', record.data.CustomerDTO.NAME);
        rec.set('CustomerDTO_CODE', record.data.CustomerDTO.CODE);
        rec.set('CustomerDTO_ADRESS', record.data.CustomerDTO.ADRESS);
        rec.set('CustomerDTO_DISCOUNT', record.data.CustomerDTO.DISCOUNT);
        edit.down('form').loadRecord(rec);
    },
    updateUser: function (button) {
        var win = button.up('window'),
            form = win.down('form'),
            values = form.getValues(),
            data = form.getRecord();
       

        if (form.getForm().isValid()) {
            var store = Ext.getStore('UserStore');
            var CustomerStore = Ext.getStore('CustomerStore');

            var rec = Ext.create('UM.model.User');
            var record = Ext.create('UM.model.Customer');

            var customer = CustomerStore.findRecord('id', data.data.CustomerDTO.id);
            var User = store.findRecord('id', values.id);

            User.set('UserName', values.UserName);
            User.set('Role', values.Role);
            User.set('Password', values.Password);

            customer.set('NAME', values.CustomerDTO_NAME);
            customer.set('CODE', values.CustomerDTO_CODE);
            customer.set('ADRESS', values.CustomerDTO_ADRESS);
            customer.set('DISCOUNT', values.CustomerDTO_DISCOUNT);

            User.set('CustomerDTO', customer.data);

            win.close();
            store.sync();
            CustomerStore.sync();
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

    delete: function (view, cell, rowIndex, colIndex, e, record, row) {
        var store = Ext.getStore('UserStore');
        var orderStore = Ext.getStore('OrderStore');

        var userOrders = orderStore.query('CustomerDTOid', record.data.CustomerDTO.id);

        if (userOrders.length == 0) {
            Ext.Msg.confirm('Remove Qualification', 'Are you sure?', function (button) {
                if (button == 'yes') {
                    var store = Ext.getStore('UserStore');
                    store.remove(record);
                    store.sync();
                }
            }, this);
        } else {
            Ext.MessageBox.show({
                title: "ERROR!!!",
                msg: "You can't delete user that have orders",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.WARNING
            });
        } 
    }
});