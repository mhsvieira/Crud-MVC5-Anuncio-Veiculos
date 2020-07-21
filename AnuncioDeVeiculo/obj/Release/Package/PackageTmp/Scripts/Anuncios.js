//window.location.hash: "#2"
//window.location.host: "localhost:4200"
//window.location.hostname: "localhost"
//window.location.href: "http://localhost:4200/landing?query=1#2"
//window.location.origin: "http://localhost:4200"
//window.location.pathname: "/landing"
//window.location.port: "4200"
//window.location.protocol: "http:"
//window.location.search: "?query=1"


$(document).ready(function () {
    $("#MarcaId").change(function () {

        $("#ModeloId").empty();
        $("#ModeloId").append("<option value=''>SELECIONE ...</option>")

        $("#VersaoId").empty();
        $("#VersaoId").append("<option value=''>SELECIONE ...</option>")

        if ($("#MarcaId").val() != "0" && $("#MarcaId").val() != "") {
            
            var host = window.location.host;

            var substr = ":";

            var found = host.indexOf(substr) !== -1;
           
            if (found) {
                url = "/Anuncio/GetListaModelos";  // desenvolvimento
            } else {
                url = "/AnuncioDeVeiculo/Anuncio/GetListaModelos";  // homologação/produção
            }

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

            var host = window.location.host;

            var substr = ":";

            var found = host.indexOf(substr) !== -1;

            if (found) {
                url = "/Anuncio/GetListaVersoes";  // desenvolvimento
            } else {
                url = "/AnuncioDeVeiculo/Anuncio/GetListaVersoes";  // homologação/produção
            }

            $.get(url, { ModeloId: $("#ModeloId").val() }, function (data) {
  
                $.each(data, function (index, row) {
                    $("#VersaoId").append("<option value='" + row.ID + "'>" + row.Name + "</option>")
                });
            });
        }
    });
});