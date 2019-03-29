

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
        read: '/Product/Get',
        create: '/Product/Create',
        update: '/Product/Update',
        destroy: '/Product/Delete'
    },
    headers: {
        'Content-Type': 'application/json; charset=UTF-8'
    }
});

Ext.define('UM.store.ProductStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.Product',
    autoLoad: true,
    paramsAsHash: true,
    proxy: proxy
});