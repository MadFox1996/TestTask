var writer = new Ext.data.JsonWriter({
    type: 'json',
    encode: false,
    listful: true,
    writeAllFields: true,
    returnJson: true,
    allowSingle: false
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
        read: '/OrderItem/Get',
        create: '/OrderItem/Create',
        update: '/OrderItem/Update',
        destroy: '/OrderItem/Delete'
    },
    headers: {
        'Content-Type': 'application/json; charset=UTF-8'
    }
});
Ext.define('UM.store.OrderItemStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.OrderItem',
    autoLoad: true,
    paramsAsHash: true,
    proxy: proxy
});