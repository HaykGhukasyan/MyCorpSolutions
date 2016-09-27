function mainViewModel(endpoints) {
    var self = this;
    self.endpoints = endpoints;
    self.customerUrl = self.endpoints.customerServiceEndpoint + endpoints.customerUrl;
    self.orderUrl = self.endpoints.customerServiceEndpoint + endpoints.orderUrl;

    self.loadingCustomers = ko.observable(false);
    self.loadingOrders = ko.observable(false);

    self.customers = ko.observable([]);
    self.orders = ko.observable([]);

    self.loadCustomers = function () {
        self.loadingCustomers(true);
        $.ajax({
            url: self.customerUrl,
            method: 'GET',
            success: function (data) {
                self.customers(data.map(function (item) {
                    return new customer(item.Id, item.FirstName, item.LastName);
                }));
            },
            error: function (error) {
                console.log('Error loading customers: ' + error);
            }

        })
    }

    self.loadOrders = function (customer) {
        self.loadingOrders(true);
        $.ajax({
            url: self.orderUrl,
            method: 'GET',
            success: function (data) {
                self.orders(data.map(function (item) {
                    return new order(item.Id, item.CustomerId, item.OrderItem);
                }).filter(function (order) {
                    return order.customerId === customer.id;
                }));
            },
            error: function (error) {
                console.log('Error loading orders: ' + error);
            }

        })
    }
};