$(document).ready(function () {
    $('#checkBoxId').each(function () {


        $("#Material").prop("disabled", true);
        $("#responseCheckBoxId").prop("disabled", true);
        $("#mailMessage").prop("disabled", true);


    })


    $('#checkBoxId').click(function () {

        var checked = $(this).is(":checked");


        if (checked) {

            $("#Material").prop("disabled", false);
            $("#responseCheckBoxId").prop("disabled", false);
            $("#mailMessage").prop("disabled", false);


        } else {
            $("#Material").prop("disabled", true);
            $("#responseCheckBoxId").prop("disabled", true);
            $("#mailMessage").prop("disabled", true);


        }

    })


    $("#fufilmentStatus").click(function () {


        var currentStatus = $("#fulfilmentStatusCode").val();
        var currentMessageStatus = $("#mailMessage").val();
        var currentMaterialStatus = $("#Material").val();

        if (currentStatus === -1) {
            currentStatus = "undefined";

        }

        if (currentStatus === "undefined" && currentMessageStatus === ""
            && currentMaterialStatus === "") {

            alert("You cannot post an empty form");
            return false;
        }


    })




    $(".dropDown").hide();
    $(".proddropDown").hide();

    $("#yesScript").click(function () {


        $(".dropDown").show();
    });
    $("#noScript").click(function () {


        $(".dropDown").hide();
    });



    var prodButton = $("#prodButton");
    var scriptButton = $("#scriptButton");

    var prodValue = $("#proddataValue");
    var dataValue = $("#dataValue");


    prodButton.fadeOut();
    scriptButton.fadeOut();
  
    $("#materialTypeId").change(function () {
        var $materialTypeId = $(this).val();
        
        if ($materialTypeId === "-1")
        {
            $("#dataValue").html("&#8358; " + parseInt(0).toLocaleString("en"));
            $("#amount").val(0);
            scriptButton.fadeOut();
            return;

        }
        var theurl = "/Radio/GetMaterialPrices?materialTypeId=" + $materialTypeId;
        console.log(theurl);
        $.ajax({

            "type": "Get",
            "url": theurl,
            success: (function (data) {

                console.log(data);
                $("#dataValue").html("&#8358; " + parseInt(data.scriptingPrice).toLocaleString("en"));
                $("#amount").val(data.scriptingPrice);
               
                console.log(data.scriptingPrice);

                if (data.scriptingPrice>0) {
                    scriptButton.fadeIn();
                }
                else {
                    scriptButton.fadeOut();
                }
            })

        });
    });
















    $("#yesProd").click(function () {


        $(".proddropDown").show();
    });
    $("#noProd").click(function () {


        $(".proddropDown").hide();
    });


    if (currentStatus !== "PRODUCTION") {
        $("#productionButton").hide();
    }


    $("#prodmaterialTypeId").change(function () {
        var $materialTypeId = $(this).val();
        if ($materialTypeId === "-1") {
            $("#proddataValue").html("&#8358; " + parseInt(0).toLocaleString("en"));
            $("#prodamount").val(0);
            prodButton.fadeOut();
            return false;

        }
        var theurl = "/Radio/GetMaterialPrices?materialTypeId=" + $materialTypeId;
        console.log(theurl);
        $.ajax({

            "type": "Get",
            "url": theurl,
            success: (function (data) {

                console.log(data);
                $("#proddataValue").html("&#8358; " + parseInt(data.productionPrice).toLocaleString("en"));
                $("#prodamount").val(data.productionPrice);
                if (data.productionPrice> 0) {
                    prodButton.fadeIn();
                }
                else {
                    prodButton.fadeOut();
                }

            })

        });
    });

});
