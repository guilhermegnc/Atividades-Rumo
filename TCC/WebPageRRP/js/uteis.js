function FormatarData(dataString) {
    var dataTeste = new Date(dataString);
    var ano = dataTeste.getFullYear();
    var mes = String(dataTeste.getMonth() + 1).length == 1 ? '0' + String(dataTeste.getMonth() + 1) : String(dataTeste.getMonth() + 1);
    var dia = String(dataTeste.getDate()).length == 1 ? '0' + String(dataTeste.getDate()) : String(dataTeste.getDate());

    return dia + "/" + mes + "/" + ano;
}