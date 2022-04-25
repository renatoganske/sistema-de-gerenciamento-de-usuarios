import atualizarUsuario from "./atualizarUsuario.js";
import buscarUsuarioNome from "./buscarUsuarioNome.js";
import http from "./restRequests.js";
import { trocaNomeDeUsuario, logout } from "./menu.js";
const botaoLogout = document.querySelector("#logout");

trocaNomeDeUsuario()
botaoLogout.addEventListener('click', logout)

const tabela = document.querySelector("tbody");

export function listarUsuarios(resultado) {
  tabela.innerHTML = " "

  resultado.forEach(usuario => {

    let contagemDeLinhas = tabela.rows.length
    const linha = tabela.insertRow(contagemDeLinhas)

    const tdNome = linha.insertCell(0);
    const tdTelefone = linha.insertCell(1);
    const tdEmail = linha.insertCell(2);
    const tdDataDeNascimento = linha.insertCell(3);
    const tdStatus = linha.insertCell(4);
    const tdActions = linha.insertCell(5);

    tdNome.innerHTML = `<div class="list-profile"><img src="../Front_End/assets/imgs/generic_profile.jpg"
                        alt="Foto de perfil" class="portrait"> ${usuario.nome} ${usuario.sobrenome}`;


    tdTelefone.innerHTML = ConverterTelefone(usuario.telefone);

    tdEmail.innerHTML = usuario.email;

    let dataDeNascimento = new Date(usuario.dataDeNascimento);
    tdDataDeNascimento.innerHTML = new Intl.DateTimeFormat('pt-BR').format(dataDeNascimento);

    if (usuario.status) {
      tdStatus.innerHTML = `<p class="status-ativo">Ativo</p>`;
    } else {
      tdStatus.innerHTML = `<p class="status-inativo">Inativo</p>`
    }

    tdActions.innerHTML = `<div class="list-icons"><a id="${usuario.idPessoa}" class="btn-atualizar-usuario" href="#"><i class="far fa-edit"></i></a>
                          <a onclick="excluirUsuario(${usuario.idPessoa})" class="btn-deletar-usuario" href="#"><i class="far fa-trash-alt"></i></a></div>`
  })

  atualizarUsuario();
}

function ConverterTelefone(telefone) {
  const novoTelefone = "(" + telefone.slice(0, 2) + ") " + (telefone.length == 11 ? telefone.slice(2, 7) : telefone.slice(2, 6)) + "-" + (telefone.length == 11 ? telefone.slice(7, 11) : telefone.slice(6, 10))
  return novoTelefone;
}

const success = response => {
  response.json()
    .then(usuario => {
      if (document.querySelector("tbody") != null) {
        listarUsuarios(usuario);
        buscarUsuarioNome(usuario);
      }
    })
}

http.get('ListarTodosOsUsuarios', null, success)
