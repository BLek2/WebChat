function ValidateForm()
{
    var checkElementGo = 0;

    var login = $("#login").val();
    var password = $("#password").val();

    if (login == '' && password == '') {
        swal("Ошибка","Поле для логина пустое", "error");
        swal("Ошибка", "Поле для пароля пустое", "error");
        checkElementGo++;
        return false;
    }



    if (login == '') {
        swal("Ошибка", "Поле для логина пустое", "error");
        checkElementGo++;
        return false;
    }
    if (password == '')
    {
        swal("Ошибка", "Поле для пароля пустое", "error");
        checkElementGo++;
        return false;
    }
    if (checkElementGo == 0)
    {
        swal("Отлично!", "Добро пожаловать в чат!", "success");
    }
}