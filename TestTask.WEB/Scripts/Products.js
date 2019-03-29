Ext.Loader.setConfig(
    {
        enabled: true
    });
Ext.require('Ext.container.Viewport');

Ext.application({
    name: 'UM',
    appFolder:'app',
    controllers: [
        'ProductController'
    ],

    launch: function() {
        Ext.create('Ext.container.Viewport', {
            layout: 'fit',
            items: [
                {
                    xtype: 'productlist'
                }
            ]
        });
    }
});

