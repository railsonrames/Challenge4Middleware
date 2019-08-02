$(document).ready(function () {
    $('#getDataButton').on('click', function () {
        $.ajax({
            type: "GET",
            url: "localhost:9001/api/records/list/",
            sucess: function (data) {
                $('#insertPoint').html(setDataTable(data));
            }
        });
    });
});

function setDataTable(dataReceived) {
    var html = '<table class="table"><thead><tr><th>Id</th><th>Name</th><th>Status</th></tr></thead><tbody>';
    $.each(dataReceived, function (innerCounter, dataItem) {
        html += `<tr><td>${dataItem.Id}</td><td>${dataItem.Name}</td><td>${dataItem.Status}</td></tr>`;
    });
    html += '</tbody></table>';
    return html;
};