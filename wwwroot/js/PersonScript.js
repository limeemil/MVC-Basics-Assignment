function getAllPersons() {
    $.get("/Ajax/GetPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/FindPersonById", { personID: personIDValue }, function (data) {
        $("#PersonList").html(data);
    });
}

function deletePersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/DeletePersonById", { personID: personIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById("statusCodes").textContent = "Person deleted successfully.";
            getAllPersons();
        })
        .fail(function () {
            document.getElementById("statusCodes").textContent = "Could not delete person.";
        })
        .error(function () {
            document.getElementById("statusCodes").textContent = "Something went wrong."
        });
}
