﻿function OnSuccess(data) {

    $("#message").val("");
    var resultDate = $("#ChatBlock");
    resultDate.empty();
    for (var i = 0; i < data.length; i++)
    {
        resultDate.append('<p>' + data[i] + '</p>');
    }

    setInterval(function () { document.getElementById('ChatBlock').scrollTop = 9999; }, 100);
}
    