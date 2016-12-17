var paginaAtual = 0;
$('#listar-candidatos').on('click', carregarListaDeCandidatos(paginaAtual));
$(function iniciarPaginaAdministrativo() {
    //executa para carregar a partial view padrão da index
    carregarListaDeCandidatos(paginaAtual);

    //listener pra recarregar a lista quando for clicado
    
});

function carregarListaDeCandidatos(pagina) {
    console.log("asdsadadd");
    $.ajax({
        url: 'Administrativo/CarregarListaDeCandidatos',
        type: 'GET',
        data: { pagina: pagina }
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);

    });
};

