function OnSuccess(data)
{
    $("#message").val("");
    var resultDate = $("#ChatBlock");
    resultDate.empty();
    for (var i = 0; i < data.length; i++)
    {
        resultDate.append('<p>' + data[i] + '</p>');
    }
}
    