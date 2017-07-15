function ValidateForm() {
    var nickname = $("#nickname").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var ConfirmPassword = $("#ConfirmPassword").val();
    
    var ValidEmail = /^\w+@\w+\.\w{2,4}$/i;


    if (nickname == '') {
        swal("Ошибка", "Поле никнейм пустое", "error");
        return false;
    }
    
    if (email == '') {
        swal("Ошибка", "Поле email пустое", "error");

        return false;
    }
    if (password == '') {
        swal("Ошибка", "Поле пароль пустое", "error");

        return false;
    }
    if (ConfirmPassword == '') {
        swal("Ошибка", "Вы забыли подтвердить пароль", "error");

        return false;
    }
    if (ConfirmPassword != password) {
        swal("Ошибка", "Пароли не совпадают", "error");

        return false;
    }

 
    
}

function OnSuccess(data){
    alert(data);
}