function ValidateForm(){
  var login = $("#login").val();
  var password = $("#password").val();

  if (login == '' && password == '') {
      swal("Ошибка","Поле для логина пустое", "error");
      swal("Ошибка", "Поле для пароля пустое", "error");

      return false;
  }

  if (login == '') {
      swal("Ошибка", "Поле для логина пустое", "error");

      return false;
  }
  if (password == ''){
      swal("Ошибка", "Поле для пароля пустое", "error");

      return false;
  }  
}