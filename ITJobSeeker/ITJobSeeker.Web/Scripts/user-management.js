function DeActive(ID) {
    console.log('called');
    $.ajax({
        type: "POST",
        url: '/UserManagement/DeActiveUser',
        data: JSON.stringify({ id: ID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Status == 0) {
                //$('#message-body').text('Register Successfully');
                //$('#modalMessage').modal("show");
                //window.location.href = '@Url.Action("AccountGridView", "AccountManagement")';
            }
        },
        error: function (data, status) {
            alert(data);
        }
    });
}
function Active(ID) {
    console.log('called');
    $.ajax({
        type: "POST",
        url: '/UserManagement/ActiveUser',
        data: JSON.stringify({ id: ID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.Status == 0) {
                //$('#message-body').text('Register Successfully');
                //$('#modalMessage').modal("show");
                //window.location.href = '@Url.Action("AccountGridView", "AccountManagement")';
            }
        },
        error: function (data, status) {
            alert(data);
        }
    });
}