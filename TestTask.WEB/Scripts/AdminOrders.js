Ext.Loader.setConfig(
    {
        enabled: true
    });
Ext.Loader.setPath('Ext.ux', '../ux');
Ext.require('Ext.container.Viewport');

Ext.application({
    name: 'UM',
    appFolder: 'app',
    controllers: [
        'OrderController'
    ],

    launch: function () {
        Ext.create('Ext.container.Viewport', {
            layout: 'fit',
            items: [
                {
                    xtype: 'adminorderlist'
                }
            ]
        });
    }
});
