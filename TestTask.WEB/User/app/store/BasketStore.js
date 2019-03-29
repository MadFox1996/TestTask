Ext.define('UM.store.BasketStore', {
    extend: 'Ext.data.Store',
    model: 'UM.model.BasketModel',
    autoLoad: true,
    paramsAsHash: true
});