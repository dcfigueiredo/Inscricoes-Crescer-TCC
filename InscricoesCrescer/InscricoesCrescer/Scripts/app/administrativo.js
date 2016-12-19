var paginaAtual = 0;
var filtro = '';

$('#listar-candidatos').click(function (event) {    
    event.preventDefault();
    carregarListaDeCandidatos(filtro, paginaAtual);
});

$(function iniciarPaginaAdministrativo() {
    carregarListaDeCandidatos(filtro, paginaAtual);
});

function carregarListaDeCandidatos(filtragem, pagina) {
    $.ajax({
        url: 'Administrativo/CarregarListaDeCandidatos',
        type: 'GET',
        data: { filtro: filtragem, pagina: pagina }
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);
        ouvirBotoesPaginacaoEFiltro();
        atualizarBotoesPaginacao();
    });
};

function atualizarBotoesPaginacao() {
    $('#btn-voltar').attr('disabled', paginaAtual === 0);

    var ultimaPagina = $('#table-candidatos').data('ultima-pagina');
    $('#btn-avancar').attr('disabled', ultimaPagina);
}

function ouvirBotoesPaginacaoEFiltro() {
    $("#btn-voltar").click(function voltarPagina() {
        if (paginaAtual > 0) {
            paginaAtual--;
            carregarListaDeCandidatos(filtro, paginaAtual);
        }
    });
    $("#btn-avancar").click(function avancarPagina() {
        paginaAtual ++;
        carregarListaDeCandidatos(filtro, paginaAtual);
    });
    $('#btn-filtrar').click(function (event) {
        paginaAtual = 0;
        filtro = $('#filtro').val();
        carregarListaDeCandidatos(filtro, paginaAtual);
    });
}