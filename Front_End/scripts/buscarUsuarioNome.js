import {listarUsuarios} from "./listarUsuarios.js";

const campoBusca = document.getElementById("search-user")

export default function buscarUsuarioNome(usuarios) {

    campoBusca.addEventListener("keyup", () => {
        const resultadoBusca = usuarios.filter(
            (user) =>
                user.nome.toUpperCase().indexOf(campoBusca.value.toUpperCase()) >= 0 ||
                user.sobrenome.toUpperCase().indexOf(campoBusca.value.toUpperCase()) >= 0 ||
                user.email.toUpperCase().indexOf(campoBusca.value.toUpperCase()) >= 0
        )
        if (campoBusca.value != null || campoBusca.value != "") {
            listarUsuarios(resultadoBusca)
        }

        else {
            listarUsuarios(usuarios)
        }
    })
}