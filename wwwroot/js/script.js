$( document ).ready( function () {

    $(".add-credit-card, .go-to-wallet").click(function () {
        event.preventDefault();
        $("#creditcardform").toggleClass('d-none').toggleClass('d-flex');
        $("#walletForm1").toggleClass('d-none').toggleClass('d-flex');
    });

    $(".add-ach, .go-to-wallet-ach").click(function () {
        event.preventDefault();
        $("#achform").toggleClass('d-none').toggleClass('d-flex');
        $("#walletForm2").toggleClass('d-none').toggleClass('d-flex');
    });

    $(".btn-delete-card, .btn-delete-ach").click(function () {
        let card_delete = $(this).parent();

        if (confirm("¿Estás seguro que deseas eliminar esta tarjeta?")) {
            card_delete.remove();
        } else {
            return;
        }
    });

    $(".credit-card, .ach-account").click(function () {
        let input_ID = $(this).attr("data-target");
        $("#"+input_ID).prop("checked", true);
    });

    $("#Order_RoutingNumber").prop('readonly', true);

    $("#dropDownRoutNumb").on("change", function () {
        if (this.value == "Otros") {
            $("#Order_RoutingNumber").prop('readonly', false).val('');
            $("#Order_CustomerName").val('Otros');
        } else {
            $("#Order_RoutingNumber").prop('readonly', true);
            $("#Order_RoutingNumber").val(this.value);
            //$("#Order_CustomerName").val(this.text());
        }
    });

    $(".btn-paymethod-mobile").click(function () {
        resizingParent();
        let val = $(this);
        let icon = val.attr('data-icon');
        let name = val.attr('data-name');
        let methodDetail = $("#methodDetail");

        methodDetail.html(`<i class="${icon} mr-3" aria-hidden="true"></i>${name}`);
    });
    
    // Send a message to the parent
    var sendMessage = function (msg) {
        // Make sure you are sending a string, and to stringify JSON
        window.parent.postMessage(msg, '*');
    };
    var resizingParent = function (value = 600) {
        var main = document.getElementById("main");

        var height = Math.max(main.scrollHeight, main.offsetHeight, value);

        sendMessage(JSON.stringify({ action: 3, event: 'Resize', description: 'Resizing', height: height }));
    }

});