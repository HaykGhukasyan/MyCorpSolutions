function customer(id, firstName, lastName) {
    var self = this;
    self.id = id;
    self.firstName = firstName;
    self.lastName = lastName;
    self.fullName = self.firstName + ' ' + self.lastName;
}