
$(document).ready(function () {
    $("#MarcaId").change(function () {

        $("#ModeloId").empty();
        $("#ModeloId").append("<option value=''>SELECIONE ...</option>")

        $("#VersaoId").empty();
        $("#VersaoId").append("<option value=''>SELECIONE ...</option>")

        if ($("#MarcaId").val() != "0" && $("#MarcaId").val() != "") {
            
            var url = ValidaUrl("/Anuncio/GetListaModelos");

            $.get(url, { MarcaId: $("#MarcaId").val() }, function (data) {
                $.each(data, function (index, row) {
                    $("#ModeloId").append("<option value='" + row.ID + "'>" + row.Name + "</option>")
                });
            });
        }
    });

    $("#ModeloId").change(function () {
        $("#VersaoId").empty();
        $("#VersaoId").append("<option value=''>SELECIONE ...</option>")

        if ($("#ModeloId").val() != "0" && $("#ModeloId").val() != "") {

            var url = ValidaUrl("/Anuncio/GetListaVersoes");

            $.get(url, { ModeloId: $("#ModeloId").val() }, function (data) {
  
                $.each(data, function (index, row) {
                    $("#VersaoId").append("<option value='" + row.ID + "'>" + row.Name + "</option>")
                });
            });
        }
    });


    function ValidaUrl(url) {
        
        var host = window.location.host;

        var substr = ":";

        var found = host.indexOf(substr) !== -1;

        if (found) {
            urlTemp = url;  // desenvolvimento
        } else {
            urlTemp = "/AnuncioDeVeiculo" + url; // homologação/produção
        }

        return urlTemp;
    }
});