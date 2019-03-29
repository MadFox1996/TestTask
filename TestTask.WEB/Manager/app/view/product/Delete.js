Ext.define('UM.view.product.Delete', {
    extend: 'Ext.window.Window',
    alias: 'widget.productdelete',

    requires: ['Ext.form.Panel'],

    title: 'Delete Product',
    layout: 'fit',
    autoShow: true,
    height: 120,
    width: 280,
    html: '<h1>Are you sure?</h1>',

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