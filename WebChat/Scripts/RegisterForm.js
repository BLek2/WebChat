function ValidateForm() {
    var nickname = $("#nickname").val();
    var email = $("#email").val();
    var password = $("#password2").val();
    var ConfirmPassword = $("#ConfirmPassword2").val();
    
    var ValidEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var boolCheck = ValidEmail.test(email);
   

    if (nickname == '') {
        swal("Ошибка", "Поле никнейм пустое", "error");
        return false;
    }
    
    if (email == '') {
        swal("Ошибка", "Поле email пустое", "error");

        return false;
    }
    if (boolCheck != true)
    {
        swal("Ошибка", "Введенный email некорректный ", "error");
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