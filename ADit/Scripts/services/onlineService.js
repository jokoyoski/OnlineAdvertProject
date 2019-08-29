$(document).ready(function () {
   
    
   
    $(document).ready(function () {
        
        $("#ArtWorkId").trigger('change');



        $('input[name="selectedOnlinePlatformIds"]').each(function () {

            var $OnlinePlatformPackage = $(this).val();


            genrateTotalPackagesPrice($OnlinePlatformPackage);




        });







        $('input[name="selectedOnlinePlatformIds"]').each(function () {
             
            var checked = $(this).is(":checked");

            if (!checked) {
                this.checked = checked;
            }


            var theIdPostFix = $(this).val();
            var isThisChecked = $(this).is(":checked");

            var timingCodeId = "timingCodeId_" + theIdPostFix;
            var timingCodeInput = $("#" + timingCodeId);
            if (isThisChecked) {
                
                timingCodeInput.prop("disabled", false);

               

            }
            if (!isThisChecked) {
                
                timingCodeInput.prop("disabled", true);
               
            }

        });


        $('input[name="selectedOnlinePlatformIds"]').click(function () {
            var checked = $(this).is(":checked");

            if (!checked) {
                this.checked = checked;
            }

            var theIdPostFix = $(this).val();
            var isThisChecked = $(this).is(":checked");

            
            var timingCodeId = "timingCodeId_" + theIdPostFix;
            var timingCodeInput = $("#" + timingCodeId);

            

            if (isThisChecked) {
               
                timingCodeInput.prop("disabled", false);
               
            }

            if (!isThisChecked) {
               
                timingCodeInput.prop("disabled", true);
                
            }
        });

        //Chamge Online Exrea Service
        $("#OnlineExtraServiceId").change(function (e) {
            var $onlineExtraServiceId = $(this).val();
            var $newPrice = 0;
            var $currentExtraServicePrice = $('#OnlineExtraServicePrice').val();

            if ($onlineExtraServiceId > 0) {


                $.ajax({
                    "type": "Get",
                    "url": "/Online/OnlineExtraServicePrice?extraServiceId=" + $onlineExtraServiceId,
                    success: (function (data) {

                        console.log(data);
                        //Prodction Prices and Details
                        $newPrice = parseFloat(data.extraServicePrice);

                       // alert(data);

                        $("#OnlineExtraServicePrice").val($newPrice);
                        $("#OnlineExtraServicePriceId").val(data.extraServicePriceId);


                        generateTotalPrice($currentExtraServicePrice, $newPrice);

                    }),
                    error: function (error) {
                        alert("An Error has occured");
                    }
                });


            } else {
                $("#OnlineExtraServicePrice").val(0);
                $("#OnlineExtraServiceId").val(0);
                $("#OnlineExtraServicePriceId").val(0);
                
                generateTotalPrice($currentExtraServicePrice, $newPrice);
            }

        });



        //Change The Arwork DropDown
        $("#ArtWorkId").change(function () {

           
           
            var $artWorkId = $(this).val();
            var $currentArtWorkPrice = $('#OnlineArtworkAmount').val();
            var $newPrice = 0;
            if ($artWorkId > 0) {


                $.ajax({
                    "type": "Get",
                    "url": "/Online/OnlineArtworkPrice?artWorkId=" + $artWorkId,
                    success: (function (data) {

                        console.log(data);
                        //Prodction Prices and Details
                         $newPrice = parseFloat(data.artWorkPrice);
                        $("#OnlineArtworkAmount").val($newPrice);
                        $("#ArtworkPricesId").val(data.artWorkPriceId);

                        if ($newPrice > 0) {
                            $("#upload").addClass("hide");
                        } else {
                            $("#upload").removeClass("hide");
                        }
                        generateTotalPrice($currentArtWorkPrice, $newPrice);

                    }),
                    error: function (error) {
                        alert("An Error has occured");
                    }
                });


            } else {
                $("#OnlineArtworkAmount").val(0);
                $("#ArtworkPricesId").val("");
                $("#upload").addClass("hide");

                generateTotalPrice($currentArtWorkPrice, $newPrice);
            }


        });

        


    });


    $('.OnlineDurationId').change(function () {

        var $selectedId = this.id;
        var OnlinePlatformId = $selectedId.split("_")[1];

        //we got the Id of the duration selected
        
        var timingId = $("#timingCodeId_" + OnlinePlatformId).val();

        generatePlatFormPrice(OnlinePlatformId, timingId);

    });


    //Duration Drop Down
    $('.onlineDuration').change(function () {
        var $selectedId = this.id;
        var $packageId = $selectedId.split("_")[1];
        var $selectedDuration = $('#timingCodeId_' + $packageId).val();
        var $currentPrice = $('#amount_' + $packageId).val();
        var $newPrice = 0;

        if ($selectedDuration > 0 && $packageId > 0) {


            $.ajax({
                "type": "Get",
                "url": "/Online/GetPackagePrice?packageId=" + $packageId + "&durationId=" + $selectedDuration,
                success: (function (price) {
                    console.log(price);

                    //TODO : Price is to be Multiplied with the number of duration and airing time

                    $newPrice = price;

                    $('#amount_' + $packageId).val($newPrice);

                    $('#airPrice_' + $packageId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

                    $('#textamount_' + $packageId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));



                    genrateTotalPackagesPrice($packageId);
                })
            });
        } else {

            $('#amount_' + $packageId).val($newPrice);
            $('#textamount_' + $packageId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
            genrateTotalPackagesPrice($packageId);


        }




    });


    function generatePlatFormPrice($packageId, $selectedDuration ) {

        var $currentPrice = $('#amount_' + $packageId).val();
        var $newPrice = 0;


        if ($packageId > 0 && $selectedDuration > 0 ) {

            var theUrl = "/Online/GetPackagePrice?packageId=" + $packageId + "&durationId=" + $selectedDuration;

            $.ajax({
                "type": "Get",
                "url": theUrl,
                success: (function (price) {
                    console.log(price);

                    //TODO : Price is to be Multiplied with the number of duration and airing time

                    $newPrice = price;

                    $('#amount_' + $packageId).val($newPrice);

                    $('#textamount_' + $packageId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));


                    genrateTotalPackagesPrice($packageId);
                })
            });
        } else {

            $('#amount_' + $packageId).val($newPrice);
            $('#textamount_' + $packageId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
            generateTotalPrice($currentPrice, $newPrice);


        }


    }


    function genrateTotalPackagesPrice($packageId) {






        //Price
        var $currentPrice = $('#totalamount_' + $packageId).val();
       

        if ($currentPrice === "") {
            


            
           
            var $Price = $('#amount_' + $packageId).val();
           

            $currentPrice = $Price;
        }


        var $productPrice = $('#amount_' + $packageId).val();


        //Multiply 
        var $newPrice = $productPrice;


        $('#totalamount_' + $packageId).val($newPrice);
        $('#textamount_' + $packageId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

       
        generateTotalPrice($currentPrice, $newPrice);


    }

     

    //Generate TransactionTotal Price
    function generateTotalPrice(currentPrice = 0, newPrice = 0) {


        var $currentTotal = parseFloat($("#finalAmount").val());



        //Add to Any Price Collected for the Television
        var $initialTotal = parseFloat($currentTotal - parseFloat(currentPrice));


        var $finalPrice = $initialTotal + parseFloat(newPrice);


        console.log("Current Total - " +
            $currentTotal +
            "Current Price - " +
            currentPrice +
            "New Price - " +
            newPrice);
         
        $finalPrice = parseInt($finalPrice || 0);


        $("#text_finalAmount").html("Price : &#8358; " + ($finalPrice.toLocaleString("en")));

        $("#finalAmount").val($finalPrice);


    }

});