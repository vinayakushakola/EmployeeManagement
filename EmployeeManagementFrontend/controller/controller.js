
app.controller('homeController', function ($scope, GetEmployeesData, DeleteEmployeeData, $location) {

    $scope.getEmployees = GetEmployeesData.getEmployeesData()
        .then(function (response) {
            $scope.employeesData = response.data;
        }, function (reason) {
            $scope.error = reason;
            console.log(error);
        });
    
    $scope.updateData = function (emp) {
        localStorage.setItem('object', JSON.stringify(emp));
        $location.path('UpdateEmployeeData')
    }

    $scope.deleteEmployee = function (id) {

        $scope.deleteEmployeesData = DeleteEmployeeData.deleteEmployeeDataByID(id)
            .then(function (response) {

                if (response.data)
                    $location.path('home');
                
            }, function (response) {

                alert("Service not Exists");
            });
    };
});


app.controller('addController', function ($scope, AddEmployeeData) {

    $scope.firstname = null;
    $scope.lastname = null;
    $scope.gender = null;
    $scope.department = null;
    $scope.salary = null;
    $scope.addEmployee = function (isValid, firstname, lastname, gender, department, salary) {
        if (isValid) {
            var data = {
                firstname: firstname,
                lastname: lastname,
                gender: gender,
                department: department,
                salary: salary,
            };

            $scope.addingEmployee = AddEmployeeData.addEmployeeData(data)
                .then(function (response) {

                if (response.data)

                    alert('Employee Data Added Successfully!')
            }, function (response) {
                alert("Service not Exists");

            });
        } else {
        };
    };

    
});


app.controller('updateController', function ($scope, UpdateEmployeeData) {

    $scope.id = null;
    $scope.firstName = null;
    $scope.lastName = null;
    $scope.gender = null;
    $scope.department = null;
    $scope.salary = null;
    $scope.employees = JSON.parse(localStorage.getItem('object'));
    console.log($scope.employees)

    $scope.updateEmployee = function (isValid, id, firstName, lastName, gender, department, salary) {
        if (isValid) {

            var data = {
                firstName: firstName,
                lastName: lastName,
                gender: gender,
                department: department,
                salary: salary,
            };

            $scope.updatingEmployee = UpdateEmployeeData.updateEmployeeData(id, data)
                .then(function (response) {

                if (response.data)

                    alert("Employee Data Updated Successfully!");

            }, function (response) {
                alert("Service not Exists");
            });
        } else {
            alert("Fill details!!")
        };
    };

    $scope.getEmployee = function (id) {
        $scope.getEmployeeData = GetEmployeeDataByID.getEmployeeDataByID(id)

            .then(function (response) {

                console.log("response is ", response);
                localStorage.setItem('object', JSON.stringify(response.data));


            }, function (reason) {
                $scope.error = reason;
                alert("Error!!!!")
                console.log(error);
            });
    };
});


app.controller('aboutController', function () {

});

app.controller('contactController', function () {
});