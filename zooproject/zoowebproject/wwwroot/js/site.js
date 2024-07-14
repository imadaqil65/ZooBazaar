// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var amount = document.querySelectorAll("#amount");

var increase = document.querySelectorAll("#increaseBtn");
var decrease = document.querySelectorAll("#decreaseBtn");

for (let i = 0; i < increase.length; i++) {
    increase[i].addEventListener("click", (function (index) {
        return function () {
            amount[index].stepUp();
        }
    })(i));
}

for (let i = 0; i < decrease.length; i++) {
    decrease[i].addEventListener("click", (function (index) {
        return function () {
            amount[index].stepDown();
        }
    })(i));
}


var editButton = document.getElementById("Edit");
var saveButton = document.getElementById("Save");
var changePassButton = document.getElementById("NewPass")
var firstName = document.getElementById("FirstName");
var lastName = document.getElementById("LastName");
var username = document.getElementById("Username");
var email = document.getElementById("Email");
var password = document.getElementById("Password");
var adress = document.getElementById("Adress");

editButton.addEventListener("click", function () {
    if (firstName.readOnly) {
        firstName.readOnly = false;
        lastName.readOnly = false;
        username.readOnly = false;
        email.readOnly = false;
        adress.readOnly = false;
    } else {
        firstName.readOnly = true;
        lastName.readOnly = true;
        username.readOnly = true;
        email.readOnly = true;
        adress.readOnly = true;
    }
})


saveButton.addEventListener("click", function () {
    if (!firstName.readOnly) {
        firstName.readOnly = true;
        lastName.readOnly = true;
        username.readOnly = true;
        email.readOnly = true;
    }
})

changePassButton.addEventListener("click", function () {
    if (passL.style.display === "none" && password.style.display === "none") {
        passL.style.display = "block";
        password.style.display = "block";
    } else {
        passL.style.display = "none";
        password.style.display = "none";
    }
})