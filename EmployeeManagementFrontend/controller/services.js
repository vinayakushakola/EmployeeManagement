
app.service('GetEmployeesData', function ($http) {
    this.getEmployeesData = function () {
        return $http.get('https://localhost:44302/api/employees')
    }
});

app.service('GetEmployeeDataByID', function ($http) {
    this.getEmployeeDataByID = function (id) {
        return $http.get('https://localhost:44302/api/employees/' + id)
    }
});

app.service('DeleteEmployeeData', function ($http) {
    this.deleteEmployeeDataByID = function (id) {
        return $http.delete('https://localhost:44302/api/employees/' + id)
    }
});

app.service('AddEmployeeData', function ($http) {
    this.addEmployeeData = function (data) {
        return $http.post('https://localhost:44302/api/employees', JSON.stringify(data))
    }
});

app.service('UpdateEmployeeData', function ($http) {
    this.updateEmployeeData = function (id, data) {
        return $http.put('https://localhost:44302/api/employees/' + id, JSON.stringify(data))
    }
});