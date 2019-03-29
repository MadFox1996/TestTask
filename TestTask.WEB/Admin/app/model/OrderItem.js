Ext.define('UM.model.OrderItem', {
    extend: 'Ext.data.Model',
    fields: [
        'id',
        'PRODUCT_COUNTS',
        'PRICE',
        'ProductDTOid',
        'OrderDTOid'
    ]
});