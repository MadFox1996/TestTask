Ext.define('UM.model.User', {
    extend: 'Ext.data.Model',
    fields: [
        'id',
        'UserName',
        'Password',
        'Role',
        { name: 'CustomerDTO', mapping: 'CustomerDTO' },
    ],
    associations: [
        { type: 'hasOne', model: 'UM.model.Customer', name: 'CustomerDTO', foreignKey: 'id', associationKey: 'CustomerDTO' }
    ]
});