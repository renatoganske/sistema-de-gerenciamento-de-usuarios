// Validação do telefone. Permite apenas digitação de números. Cria máscara para o telefone

function mask(o) {
  setTimeout(function () {
    var v = mphone(o.value);
    if (v != o.value) {
      o.value = v;
    }
  }, 1);
}

function mphone(v) {
  var r = v.replace(/\D/g, "");
  r = r.replace(/^0/, "");
  if (r.length > 10) {
    r = r.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
  } else if (r.length > 5) {
    r = r.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
  } else if (r.length > 2) {
    r = r.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
  } else {
    r = r.replace(/^(\d*)/, "($1");
  }
  return r;
}

//valida senha
function checkPassword() {
  let validatePassword = "validatePassword";
  let password = document.getElementById("password").value
  let regex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/i;

  if (!regex.test(password)) {
    document.getElementById(validatePassword).innerHTML = "A senha deve conter 6 caracteres, sendo no mínimo 1 número."
    return false;
  }

  if (password == "") {
    document.getElementById(validatePassword).innerHTML = "Digite uma senha."
    return false;
  }

  else
    document.getElementById(validatePassword).innerHTML = ""
  return true;
}

//valida repetição da senha
function repeatPassword() {
  let repeatPassword = "repeatPassword";
  let password2 = document.getElementById("password2").value;
  let regex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/i;

  if (!regex.test(password2)) {
    document.getElementById(repeatPassword).innerHTML = "Repita a senha anterior.";
    return false;
  }

  if (password2 == "") {
    document.getElementById(repeatPassword).innerHTML = "Digite uma senha."
    return false;
  }

  else
    document.getElementById(repeatPassword).innerHTML = "";
  return true;
}

//valida se as senhas são iguais
function matchPassword() {
  let repeatPassword = "repeatPassword";
  let password = document.getElementById("password").value;
  let password2 = document.getElementById("password2").value;

    if (password != password2) {
      document.getElementById(repeatPassword).innerHTML = "As senhas devem ser iguais.";
      return false;
    }

  else
    document.getElementById(repeatPassword).innerHTML = "";
  return true;
}


