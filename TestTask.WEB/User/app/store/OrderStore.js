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
    idProperty: 'id',
    root: 'data',
    messageProperty: 'message'
});
var proxy = new Ext.data.HttpProxy({
    reader: reader,
    writer: writer,
    type: 'ajax',
    api: {
        read: '/Order/GetByUser',
        create: '/Order/Create',
        update: '/Order/Update',
        destroy: '/Order/Delete'
    },
    headers: {
        'Content-Type': 'application/json; charset=UTF-8'
    }
});
Ext.define('UM.store.OrderStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.Order',
    autoLoad: true,
    paramsAsHash: true,
    proxy: proxy
});