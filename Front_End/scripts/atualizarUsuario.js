
export default function atualizarUsuario () {
  let botaoAtualizarUsuario = document.querySelectorAll(".btn-atualizar-usuario");
  botaoAtualizarUsuario.forEach(botao => botao.href= `./cadastro.html?id=${botao.id}`)
}