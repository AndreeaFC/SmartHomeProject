$(document).ready(function () {
    //var chat;
    //chat = $.connection.chatHub;
    //chat.client.writeMessage = function (message) {
    //    $("#messages").append("<li>" + message + "</li>");
    //};

    ////establish the connection to the server and start server-side operation
    //$.connection.hub.start().done(function () {
    //    $("#buttonSubmit").click(function () {
    //        chat.server.broadcastMessage($("#txtInput").val())
    //    });
    //});

    GetAllHouseAreas();
});

//*********************************************//
//GET HouseArea
function GetAllHouseAreas() {
    jQuery.support.cors = true;
    $.ajax({
        url: 'http://localhost:49867/api/HouseAreasAPI/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (index, data) {
                $('.dropdown-menu').append('<li>' + data.Id + '</li>');
                "<li role=\"separator\" class=\"divider\"></li>"
            })
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

//POST HouseArea
function AddHouseArea() {
    jQuery.support.cors = true;
    var houseArea = {
        ID: $('#txtaddHouseAreaId').val(),
        Name: $('#txtaddName').val(),
        LightsOn: $('#txtaddLightsOn').val(),
        AreaHeating: $('#txtaddAreaHeating').val(),
        FloorHeating: $('#txtaddFloorHeating').val()
    };

    $.ajax({
        url: 'http://localhost:49867/api/HouseAreasAPI/',
        type: 'POST',
        data: JSON.stringify(houseArea),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

//UPDATE(PUT) HouseArea
function UppdateHouseArea() {
    jQuery.support.cors = true;
    var houseArea = {
        ID: $('#txtUpdateHouseAreaId').val(),
        Name: $('#txtUpdateName').val(),
        LightsOn: $('#txtUpdateLightsOn').val(),
        AreaHeating: $('#txtUpdateAreaHeating').val(),
        FloorHeating: $('#txtUpdateFloorHeating').val()
    };

    $.ajax({
        url: 'http://localhost:49867/api/HouseAreasAPI/' + houseArea.ID,
        type: 'PUT',
        data: JSON.stringify(houseArea),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

//DELETE HouseArea
function DeleteHouseArea() {
    jQuery.support.cors = true;
    var id = $('#txtDelHouseAreaId').val()

    $.ajax({
        url: 'http://localhost:49867/api/HouseAreasAPI/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

//*********************************************//




function FindStudentByName() {
    jQuery.support.cors = true;
    var str = $('#txtStudentNameName').val();
    $.ajax({
        url: 'http://localhost:49867/api/StudentsAPI' + str,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
