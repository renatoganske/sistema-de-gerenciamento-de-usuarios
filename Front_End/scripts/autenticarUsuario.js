const url_login = "https://localhost:7195/api/Login/Login"

const campoLogin = document.getElementById("input-email")
const campoSenha = document.getElementById("input-senha")
const formulario = document.querySelector("form")

let autenticacaoDoUsuario = {
    method: 'POST',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
}

function autenticarUsuario() {

    let data = {
        email: campoLogin.value,
        senha: campoSenha.value
    }

    fetch(url_login, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": true
        },
        body: JSON.stringify(data)
    })

        .then(function (response) {
            return response.json()
        })

        .then(function (response) {

            if (response.StatusCode === 401) {
                alert(response.Message)
            }
            if (response.email) {
                localStorage.setItem("idPessoa", response.idPessoa)
                localStorage.setItem("nomeCompleto", response.nome + " " + response.sobrenome)
                localStorage.setItem("email", response.email)
                localStorage.setItem("autenticacao", `Basic ${btoa(`${campoLogin.value}:${campoSenha.value}`)}`)

                window.location.href = "/Front_End/dashboard.html"
            }
        })
}

formulario.addEventListener("submit", (event) => {
    event.preventDefault()
    autenticarUsuario()
})