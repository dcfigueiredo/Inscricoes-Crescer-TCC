var paginaAtual = 0;

$(function iniciarPaginaAdministrativo() {
    $('#listar-candidatos').click(carregarListaDeCandidatos());
});

$(function carregarListaDeCandidatos(paginaAtual) {
    $.ajax({
        url: 'Administrativo/CarregarListaDeCandidatos',
        type: 'GET',
        data: { pagina: paginaAtual }
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);

    });
});

