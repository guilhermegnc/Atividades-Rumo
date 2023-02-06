$(document).ready(function () {
    ListarProdutos();
    $(".preloading").hide();

    var value = Cookies.get('nivelAcesso')
    if(value == 1)
        LoginCookies();

    $('#btnEntrar').prop('disabled', true);
    $('.login').keyup(function () {
        var empty = false;
        $('.login').each(function () {
            if (!empty) { 
                if ($(this).val() == '') {
                    empty = true;
                }
            }
        });
        if (!empty) {
            $('#btnEntrar').prop('disabled', false);
        }
        else {
            $('#btnEntrar').prop('disabled', true);
        }
    });
});

var tabelaProduto;
var urlBaseApi = "https://localhost:44393";

function LimparCorpoTabelaProdutos() {
    var componenteSelecionado = $('#tabelaProduto tbody');
    componenteSelecionado.html('');
}

function ListarProdutos() {
    var rotaApi = '/produto';

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'GET',
        dataType: "json"
    }).done(function (resultado) {
        ConstruirTabela(resultado);
    });
}

$('#cadastroProdutos').click(function() {
    window.location.href = "CadastroProduto.html"
});

function ConstruirTabela(linhas) {

    var htmlTabela = '';


    $(linhas).each(function (index, linha) {
        if(linha.diferencaPreco == null) {
            linha.diferencaPreco = 0;
        }
        if(linha.porcentagemDiferenca == null) {
            linha.porcentagemDiferenca = 0;
        }
        htmlTabela = htmlTabela + `<tr><td>${linha.nome}</td><td>R$${linha.preco.toFixed(2)}</td><td>${FormatarData(linha.dataCadastro)}</td><td>R$${linha.diferencaPreco.toFixed(2)}</td><td>${linha.porcentagemDiferenca.toFixed(2)}%</td></tr>`;
    });
    
    $('#tabelaProduto tbody').html(htmlTabela);
    if (tabelaProduto == undefined) {
        tabelaProduto = $('#tabelaProduto').DataTable({
            language: {
                url: 'dist/datatables/i18n.json'
            }
        });
    }
}