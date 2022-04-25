const btnOpenMenu = document.querySelector("#open-menu-btn");
const nomeDeUsuario = document.querySelector("#username")
const botaoLogout = document.querySelector("#logout");

    function toggleMenu(){
        const sideBar = document.querySelector("sidebar");
        sideBar.classList.toggle('active');
    }
    btnOpenMenu.addEventListener('click', toggleMenu);

    export function trocaNomeDeUsuario(){
        const nomeUsuarioLogado = localStorage.getItem("nomeCompleto");
        nomeDeUsuario.innerHTML = nomeUsuarioLogado;
    }

    export function logout(){
        localStorage.clear();
        location.href="./login.html";  
    }

    botaoLogout.addEventListener('click', logout)

    onload=trocaNomeDeUsuario();  

