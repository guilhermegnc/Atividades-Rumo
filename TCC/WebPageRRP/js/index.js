function Login() {
    var email = $('#email').val();
    var senha = $('#senha').val();

    var objeto = {
        email: email,
        senha: senha,
        nomeUsuario: null,
        cargoUsuario: null
    }

    var json = JSON.stringify(objeto);;

    $.ajax({
        url: 'https://localhost:44393/Autorizacao',
        method: 'POST',
        data: json,
        contentType: 'application/json',
        dataType: 'json'
    }).done(function (resposta) {
        SalvarDadosLogin(resposta);

        // Troca o botão de login pelo de sair/logout, e mostra a opção de cadastrar produto
        $('#login').hide();
        $('#logout').show();
        $("#cadastroProdutos").show();
    }).fail(function (err, errr, errrr) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Usuário ou senha inválidos!',
            timer: 1500
        })
    });
}

function LoginCookies() {
    // Caso já haja cookies com os dados de acesso
    $('#login').hide();
    $('#logout').show();
    $("#cadastroProdutos").show();
}

function SalvarDadosLogin(dadosToken) {
    Cookies.set('bearer', dadosToken.bearer);
    Cookies.set('nivelAcesso', dadosToken.nivelAcesso);
    Cookies.set('nomeUsuario', dadosToken.nomeUsuario);
}

function logout() {
    //Remove os cookies e volta os botões para o valor inicial
    Cookies.remove('bearer')
    Cookies.remove('nivelAcesso')
    Cookies.remove('nomeUsuario')
    $('#login').show();
    $('#logout').hide();
    $("#cadastroProdutos").hide();
}