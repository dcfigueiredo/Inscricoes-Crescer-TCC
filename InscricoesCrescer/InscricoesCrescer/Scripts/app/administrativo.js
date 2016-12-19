var paginaAtual = 0;
$('#listar-candidatos').click(function (event) {    
    event.preventDefault();
    carregarListaDeCandidatos(paginaAtual);
});

$(function iniciarPaginaAdministrativo() {
    carregarListaDeCandidatos(paginaAtual);
});

function carregarListaDeCandidatos(pagina) {
    $.ajax({
        url: 'Administrativo/CarregarListaDeCandidatos',
        type: 'GET',
        data: { pagina: pagina }
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);
        ouvirBotoesPaginacao();
        atualizarBotoesPaginacao();
    });
};

function atualizarBotoesPaginacao() {
    $('#btn-voltar').attr('disabled', paginaAtual === 0);

    var ultimaPagina = $('#table-candidatos').data('ultima-pagina');
    $('#btn-avancar').attr('disabled', ultimaPagina);
}

function ouvirBotoesPaginacao() {
    $("#btn-voltar").click(function voltarPagina() {
        if (paginaAtual > 0) {
            paginaAtual--;
            carregarListaDeCandidatos(paginaAtual);
        }
    });
    $("#btn-avancar").click(function avancarPagina() {
        paginaAtual ++;
        carregarListaDeCandidatos(paginaAtual);
    });
}