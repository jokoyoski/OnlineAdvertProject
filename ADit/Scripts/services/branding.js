var Designamount = 0;
var DesignId = 0;
var brandingAmount = 0;
var brandingId = 0;

$(document).ready(function () {

    generateTotalPrice();
    

    // $("#scriptingMaterialSection").addClass("hide");



    $("#DesignElementId").change(function () {

        if ($("#DesignElementId").val() === 7) {
            $("#scriptingMaterialSection").removeClass("hide");

        }
    });


    
    function generateTotalPrice() {

       
        var totalPrice = parseFloat($("#brandingMaterialPrice").val()) +
            parseFloat($("#designElementPrice").val());

       
        isNaN(totalPrice) ? totalPrice = 0 : totalPrice = totalPrice;
      
        $("#finalAmount").val(totalPrice);
                                              
        $("#TotalAmount").html("Total Price : &#8358; " + (totalPrice.toLocaleString("en")));
    }


    $("#BrandingMaterialId").change(function () {

        var $brandingMaterialId = $(this).val();

        if ($brandingMaterialId >= 1) {

            $.ajax({
                "type": "Get",
                "url": "/Branding/BrandingMaterialPriceAmount?brandingMaterialId=" + $brandingMaterialId,
                success: (function (data) {

                    console.log(data);
                    //Prodction Prices and Details
                    brandingAmount = data.brandingMaterialPriceAmount;
                    brandingId = data.brandingMaterialPriceId;

                    $("#brandingMaterialPrice").val(parseFloat(brandingAmount));
                    $("#BrandingMaterialPriceId").val(brandingId);
                    generateTotalPrice();

                }),
                error: (function (ex) {
                    alert("An error has occured while trying to get your price");
                })
            });


        } else {
            $("#brandingMaterialPrice").val(parseFloat(0));
            $("#BrandingMaterialPriceId").val("");

            generateTotalPrice();

        }

    });


    $("#DesignElmentId").change(function () {
        var $designElementPriceId = $(this).val();
      
        if ($designElementPriceId > 0) {
            $.ajax({
                "type": "Get",
                "url": "/Print/DesignElementPrice?designElementPriceId=" + $designElementPriceId,
                success: (function (data) {

                    console.log(data);

                    Designamount = data.DesignElementPrice;

                    DesignId = data.DesignElementPriceId;

                  
                  
                    $("#designElementPrice").val(parseInt(Designamount));
                    $("#DesignElementPriceId").val(DesignId);

                    generateTotalPrice();


                }),
                error: (function (err) {
                    alert("An error has occured while trying to get the price");
                })


            });
        } else {
            $("#designElementPrice").val(0);
            $("#DesignElementPriceId").val(0);
            generateTotalPrice();
        }
    });

   

});