Ext.define('UM.model.BasketModel', {
    extend: 'Ext.data.Model',

    idProperty: '_id',

    fields: [
        'id',// product_id
        'NAME',
        'PRICE',
        'CODE',
        'CATEGORY',
        'QUANTITY'
    ],

    proxy: {
        type: 'localstorage',
        id: 'basket'
    }
});