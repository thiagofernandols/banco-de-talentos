function ExibeMensagem(mensagem, tipo, titulo, tempo) {
    var shortCutFunction = "";
    var msg = "";
    var title = "";
    var duracao = 5000;

    if (tempo != null && tempo != "")
        duracao = tempo;

    switch (tipo) {
        case "SUCESSO":
            shortCutFunction = "success";
            break;
        case "INFO":
            shortCutFunction = "info";
            break;
        case "ATENCAO":
            shortCutFunction = "warning";
            break;
        case "ERRO":
            shortCutFunction = "error";
            duracao = 10000;
            break;
    }
    if (mensagem != null && mensagem != "")
        msg = mensagem;

    if (titulo != null && titulo != "")
        title = titulo;

    toastr.options = {
        closeButton: true,
        debug: false,
        newestOnTop: false,
        progressBar: true,
        positionClass: "toast-top-right",
        preventDuplicates: false,
        onclick: null,
        showDuration: 300,
        hideDuration: 1000,
        timeOut: duracao,
        extendedTimeOut: 1000,
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut"
    }

    var $toast = toastr[shortCutFunction](msg, title);
}

function TrataErroAjax(request) {
    var erromsg = $(request.data).find('.rawExceptionStackTrace').html();
    ExibeMensagem(erromsg, "ERRO");
}