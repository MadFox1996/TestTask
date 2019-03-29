Ext.Loader.setConfig(
    {
        enabled: true
    });
Ext.require('Ext.container.Viewport');



Ext.application({
    name: 'UM',
    appFolder:'app',
    controllers: [
        'UserProductController'
    ],

    launch: function() {
        Ext.create('Ext.container.Viewport', {
            layout: { type: 'vbox', align: 'stretch', pack: 'start' },
            items: [
                {
                    xtype: 'userproductlist',flex:1
                },
                {
                    xtype: 'basket',flex:1
                }
            ]
        });
    }
});
