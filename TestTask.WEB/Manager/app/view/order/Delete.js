Ext.define('UM.view.order.Delete', {
    extend: 'Ext.window.Window',
    alias: 'widget.deleteorder',

    requires: ['Ext.form.Panel'],

    title: 'Delete Order',
    layout: 'fit',
    autoShow: true,
    height: 120,
    width: 280,
    html: '<h1>This action will delete your order. Are you sure?</h1>',

    initComponent: function () {
        this.buttons = [
            {
                text: 'Delete',
                action: 'delete'
            },
            {
                text: 'Cancel',
                scope: this,
                handler: this.close
            }
        ];
        this.callParent(arguments);
    }
});