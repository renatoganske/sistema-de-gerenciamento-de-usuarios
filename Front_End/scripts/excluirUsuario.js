import http from "./restRequests.js";

export default window.excluirUsuario = async function (id) {
  const confirmacao = confirm("Deseja mesmo excluir o usuário?")

  if (confirmacao) {
    http.del('Excluir' + id, id, delete_success, delete_error)
  }
}

const delete_success = resposta => {
  alert("Usuário excluído com sucesso!")
  location.reload()
}

const delete_error = (e) => {
  alert(e)
}