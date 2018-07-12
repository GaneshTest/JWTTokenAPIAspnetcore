const connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationHub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    var responseCount = "";
  //  var l = message.length;
    responseCount = 1;
    var lis = "";
    lis += "<li class='nav-header'><div class='pull-left'>Notifications</div></li>";
    lis += "<li>" +
        "<a href='http://" + window.location.host + "/Notification/MarkAsRead?notificationLogUserId=" + message.id + "' class='noticebar-item notificationMarkAsRead'>" +
        "<span class='noticebar-item-body' style='padding-left: 0px;'>" +
        "<strong class='noticebar-item-title notifictionTitle'>" + message.notificationTitle + "</strong>" +
        "<span class='noticebar-item-text notificationText'>" + message.notificationText + "</span>" +
        "<span class='noticebar-item-time notificationTime'><i class='fa fa-clock-o'></i> " + message.createdDateTime + "</span>" +
        "</span>" +
        "</a>" +
        "</li>";

    $(".notificationList").empty();
    $(".notificationList").html(lis);
    $(".notificationCounter").text(responseCount);
    //init();
    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " says " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});

//connection.start().done(init).catch(err => console.error(err.toString()));

//document.getElementById("sendButton").addEventListener("click", event => {
//    const user = document.getElementById("userInput").value;
//    const message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
//    event.preventDefault();
//});


connection.start().catch(err => console.error(err.toString()));

function init() {
    //var host = window.location.host;
    //$.ajax({
    //    url: 'https://localhost:44353/Notification',
    //})
    //    .done(function (result) {


    //    })
    $.get("http://" + window.location.host + "/Notification/", function (response) {
        var lis = "";
        lis += "<li class='nav-header'><div class='pull-left'>Notifications</div></li>";
        var responseCount = "";
        responseCount = response.length;
        $.each(response, function (index, data) {
            lis += "<li>" +
                "<a href='http://" + window.location.host + "/Notification/MarkAsRead?notificationLogUserId=" + data.Id + "' class='noticebar-item notificationMarkAsRead'>" +
                "<span class='noticebar-item-body' style='padding-left: 0px;'>" +
                "<strong class='noticebar-item-title notifictionTitle'>" + data.NotificationTitle + "</strong>" +
                "<span class='noticebar-item-text notificationText'>" + data.NotificationText + "</span>" +
                "<span class='noticebar-item-time notificationTime'><i class='fa fa-clock-o'></i> " + data.CreatedDateTime + "</span>" +
                "</span>" +
                "</a>" +
                "</li>";
        });
        $(".notificationList").empty();
        $(".notificationList").html(lis);
        $(".notificationCounter").text(responseCount);
    });
}
