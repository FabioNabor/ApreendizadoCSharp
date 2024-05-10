// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function executarAcaoController(filename) {
    // Fazer uma solicitação AJAX para o endpoint da controller
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Gerenciador/DownloadFile", true);
    xhr.onload = function () {
        if (xhr.status == 200) {
            console.log("Ação do controlador executada com sucesso!");
        } else {
            console.error("Erro ao executar ação do controlador:", xhr.statusText);
        }
    };
    xhr.send();
}
