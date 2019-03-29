Ext.define('UM.model.Order', {
    extend: 'Ext.data.Model',
    idProperty:'id',
    fields:
        [
            {
                name: 'id'
            },
            {
                name: 'ORDER_DATE',
                type: 'Date',
                convert: function (value, record) {
                    var date = new Date(parseInt(value.substr(6)));
                    return Ext.Date.format(date, 'l, F d, Y g:i:s A');
                }
            },
            {
                name: 'SHIPMENT_DATE',
                type: 'Date',
                convert: function (value, record) {
                    if (value != "" && value != null) {
                        if (value.length == 10) {
                            var date = new Date(value);
                        }
                        else {
                            var date = new Date(parseInt(value.substr(6)));
                        }
                        return Ext.Date.format(date, 'Y-m-d');
                    }
                }
            },
            {
                name: 'ORDER_NUMBER'
            },
            {
                name: 'status'
            },
            {
                name: 'CustomerDTOid'
            }
        ]
});