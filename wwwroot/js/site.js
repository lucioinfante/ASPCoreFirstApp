// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(document).on("click", ".edit-product-button", function () {
        console.log("You just clicked button number " + $(this).val());

        // fetch the product information and fill the modal form.
        var productId = $(this).val();
        $.ajax({
            type: 'json',
            data: {
                "id": productId
            },
            url: "/Products/ShowOneProductJSON",
            success: function (data) {
                console.log(data);
                // fill the input fields in the modal
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);
            }
        });
        $("#save-button").click(function () {
            // get the values from the input fields and create a json object to submit to the controller.
            var Product = {
                "Id": $("#modal-input-id").val(),
                "Name": $("#modal-input-name").val(),
                "Price": $("#modal-input-price").val(),
                "Description": $("#modal-input-description").val()
            };

            console.log("saved...");
            console.log(Product);

            // save the updated product record in the database using the controller
            $.ajax({
                type: 'json',
                data: Product,
                url: '/Products/ProcessEditReturnPartial',
                success: function (data) {
                    console.log(data);
                    $("card-number-" + Product.Id).html(data).hide().fadeIn(2000);
                }
            });

        })

    });
});



$(function() {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("Right click. Prevent context menu from showing.")
    });

    /*
    $(document).on("click", ".game-button", function (event) {
        event.preventDefault();

        var buttonNumber = $(this).val();
        console.log("button " + buttonNumber + " was clicked")
        doButtonUpdate(buttonNumber);
    });
    */
    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which) {
            case 1:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Button number " + buttonNumber + " was right clicked");
                doButtonUpdate(buttonNumber, "/button/ShowOneButton")
                break;
            case 2:
                alert('Middle mouse is processed')
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Button number " + buttonNumber + " was right clicked");
                doButtonUpdate(buttonNumber, "/button/RightClickShowOneButton")
                break;
            default:
                alert('Nothing');
        }
    });

    function doButtonUpdate(buttonNumber, urlString) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: urlString,
            data: {
                "buttonNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                $("#" + buttonNumber).html(data);
            }
        });
    }
});