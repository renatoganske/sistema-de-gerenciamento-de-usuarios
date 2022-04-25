import { trocaNomeDeUsuario, logout } from "./menu.js";
import http from "./restRequests.js";

const botaoLogout = document.querySelector("#logout");

trocaNomeDeUsuario()
botaoLogout.addEventListener('click', logout)

const form = document.getElementById('form');
const id = location.href.split("id=")[1]


if (id != undefined) {

  form["password"].removeAttribute("onkeyup")
  form["password2"].removeAttribute("onkeyup")
  form["btn-registrar"].innerHTML = "Atualizar"

  form["password"].addEventListener("keyup", () => {
    checkPassword()
    matchPassword()
  })

  form["password2"].addEventListener("keyup", () => {
    repeatPassword()
    matchPassword()
  })

  const usuario_listado_sucesso = (resposta) => {
    resposta.json()
      .then(usuario => {
        form["name"].value = usuario.nome
        form['last-name'].value = usuario.sobrenome
        form['email'].value = usuario.email
        form['phone'].value = mphone(usuario.telefone)
        form['birth-date'].value = usuario.dataDeNascimento.split("T")[0]
        form['active'].checked = usuario.status
      })
  }

  http.get('ListarUsuario', id, usuario_listado_sucesso)
}

function validateForm(event) {
  event.preventDefault();

  // verificar se o nome está vazio
  if (form['name'].value == "") {
    event.preventDefault();
    // Deixa o input com o focus
    form['name'].focus();
    document.getElementById("validateName").innerHTML = "Por favor, preencha o seu nome.";
    return;
  }
  else
    document.getElementById("validateName").innerHTML = "";

  if (form['last-name'].value == "") {
    event.preventDefault();
    form['last-name'].focus();
    document.getElementById("validateLastName").innerHTML = "Por favor, preencha o seu sobrenome.";
    return;
  }
  else
    document.getElementById("validateLastName").innerHTML = "";

  if (form['phone'].value == "") {
    event.preventDefault();
    form['phone'].focus();
    document.getElementById("validatePhone").innerHTML = "Por favor, preencha o seu telefone.";
    return;
  }
  else
    document.getElementById("validatePhone").innerHTML = "";

  if (form['phone'].value.length < 14) {
    event.preventDefault();
    form['phone'].focus();
    document.getElementById("validatePhone").innerHTML = "Por favor, preencha um número de telefone válido.";
    return;
  }
  else
    document.getElementById("validatePhone").innerHTML = "";

  if (form['birth-date'].value == "") {
    event.preventDefault();
    form['birth-date'].focus();
    document.getElementById("validateBirthDate").innerHTML = "Por favor, preencha a data do aniversário.";
    return;
  }
  else
    document.getElementById("validateBirthDate").innerHTML = "";

  const regex = /^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$/i;
  if (!regex.test(form['email'].value)) {
    event.preventDefault();
    form['email'].focus();
    validateInputError("checkEmail", "Por favor, digite um email válido.");
    return;
  }
  else
    validateInputError("checkEmail", "");

  if (id == undefined) {
    if (!(checkPassword() && repeatPassword() && matchPassword())) {
      event.preventDefault();
      return;
    }  
  }

  const usuario = {
    nome: form['name'].value,
    sobrenome: form['last-name'].value,
    email: form['email'].value,
    telefone: form['phone'].value.replace(/\D/gm, ""),
    dataDeNascimento: form['birth-date'].value.slice(0, 10),
    senha: document.getElementById("password").value,
    senharepeticao: document.getElementById("password2").value,
    status: form['active'].checked
  }
  const url_adicionar = "AdicionarUsuario"
  const url_atualizar = "Atualizar"
  const url = !id ? url_adicionar : url_atualizar + id

  const success = () => {
    const message = id == undefined ? "Usuário cadastrado com sucesso." : "Usuário atualizado com sucesso."
    alert(message)
    if (id == localStorage.getItem("idPessoa")){
      localStorage.setItem("nomeCompleto", usuario.nome + " " + usuario.sobrenome)
      trocaNomeDeUsuario();
    }
    location.href = "./listagem.html"
  }

  const error = (e) => {
    alert(e)    
  }
  const request = !id ? http.post(url, usuario, success, error) : http.put(url, usuario, success, error);
}

function validateInputError(inputId, message) {
  const element = document.getElementById(inputId);
  element.innerHTML = message;
}

form.addEventListener("submit", validateForm)