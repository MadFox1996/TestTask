var writer = new Ext.data.JsonWriter({
    type: 'json',
    encode: false,
    listful: true,
    writeAllFields: true,
    returnJson: true
});

var reader = new Ext.data.JsonReader({
    totalProperty: 'total',
    successProperty: 'success',
    idProperty: 'id',
    root: 'data',
    messageProperty: 'message'
});
var proxy = new Ext.data.HttpProxy({
    reader: reader,
    writer: writer,
    type: 'ajax',
    api: {
        read: '/Accounts/Get',
        create: '/Accounts/Create',
        update: '/Accounts/Update',
        destroy: '/Accounts/Delete'
    },
    headers: {
        'Content-Type': 'application/json; charset=UTF-8'
    }
});
Ext.define('UM.store.UserStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.User',
    autoLoad: true,
    paramsAsHash: true,
    proxy: proxy
});