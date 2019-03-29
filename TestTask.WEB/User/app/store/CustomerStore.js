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
    idProperty: 'ID',
    root: 'data',
    messageProperty: 'message'
});
var proxy = new Ext.data.HttpProxy({
    reader: reader,
    writer: writer,
    type: 'ajax',
    api: {
        read: '/Customer/Get',
        create: '/Customer/Create',
        update: '/Customer/Update',
        destroy: '/Customer/Delete'
    },
    headers: {
        'Content-Type': 'application/json; charset=UTF-8'
    }
});
Ext.define('UM.store.CustomerStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.Customer',
    autoLoad: true,
    paramsAsHash: true,
    proxy: proxy
});