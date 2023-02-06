$(document).ready(function () {
    $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.|\,]/g, ''));
        if (event.which == 44) {
            return true;
        }
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {

            event.preventDefault();
        }
    });

    $('#btnCadastrar').prop('disabled', true);
    $('input').keyup(function () {
        var empty = false;
        $('input').each(function () {
            if (!empty) { 
                if ($(this).val() == '') {
                    empty = true;
                }
            }
        });
        if (!empty) {
            $('#btnCadastrar').prop('disabled', false);
        }
        else {
            $('#btnEntrar').prop('disabled', true);
        }
    });
});

var urlBaseApi = "https://localhost:44393";

function cadastrar() {
    var nome = $('#nome').val();
    var preco = $('#preco').val();
    var data = $('#dataCadastro').val();
    console.log(nome);
    preco = preco.replace(",", ".");
    console.log(preco);
    
    console.log(data);

    var objeto = {
        nome: nome,
        preco: preco,
        dataCadastro: data,
        situacao: true
    }
    var json = JSON.stringify(objeto);


    var rotaApi = '/produto';

    $(".preloading").show();

    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'POST',
        data: json,
        contentType: 'application/json'
    }).done(function () {
        Swal.fire({
            icon: 'success',
            title: 'Produto adicionado com sucesso.',
            showConfirmButton: false,
            timer: 1500
        });
        $(".preloading").hide();
    });
}

function voltarHome() {
    window.location.href = "Main.html"
}

function cadastrarUsandoRobo() {
    $(".preloading").show();

    var rotaApi = '/produto/robo';
    $.ajax({
        url: urlBaseApi + rotaApi,
        method: 'POST'
    }).done(function () {
        Swal.fire({
            icon: 'success',
            title: 'Produtos adicionados com sucesso.',
            showConfirmButton: false,
            timer: 1500,
        });
        $(".preloading").hide();
    });
}