var paginaAtual = 0;
var filtro = '';

$('#listar-candidatos').click(function (event) {
    event.preventDefault();
    carregarListaDeCandidatos(filtro, paginaAtual);
});

$('#abrir-processo-seletivo').click(function (event) {
    event.preventDefault();
    carregarProcessoSeletivo();
});

$(function iniciarPaginaAdministrativo() {
    carregarListaDeCandidatos(filtro, paginaAtual);
});

function carregarProcessoSeletivo() {
    $.ajax({
        url: 'Administrativo/CarregarProcessoSeletivo',
        type: 'GET'
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);
    });
}

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
        paginaAtual++;
        carregarListaDeCandidatos(filtro, paginaAtual);
    });
    $('#btn-filtrar').click(function (event) {
        paginaAtual = 0;
        filtro = $('#filtro').val();
        carregarListaDeCandidatos(filtro, paginaAtual);
    });
    $('.entrevistas').click(function (event) {
        event.preventDefault();
        var id = $(this).attr('id');
        carregarEntrevistas(id);
    });
}

function carregarEntrevistas(id) {
    $.ajax({
        url: 'Administrativo/CarregarEntrevistas',
        type: 'GET',
        data: { id: id }
    })
      .then(function (partialView) {
          $('#container-partial-views').html(partialView);
          ouvirBotoesEntrevista();
      });
}

function ouvirBotoesEntrevista() {
    var idEntrevistado = $('.container-id').attr('id');
    $('#nova-entrevista').click(function event() {
        carregarCadastroEntrevista(0, idEntrevistado);
    });
    $('.abrir-cadastro-entrevista').click(function event() {
        event.prevetDefault();
        var id = $(this).attr('id');
        carregarCadastroEntrevista(id, idEntrevistado);
    });
}

function carregarCadastroEntrevista(idEntrevista, idEntrevistado) {
    $.ajax({
        url: 'Administrativo/CarregarCadastroEntrevista',
        type: 'GET',
        data: {idEntrevista : idEntrevista, idEntrevistado : idEntrevistado}
    })
    .then(function (partialView) {
        $('#container-partial-views').html(partialView);
    });
}