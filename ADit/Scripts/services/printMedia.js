$(document).ready(function() {


    $("input[name='selectedNewsPapersId']").each(function () {

        var Id = $(this).val();
        var amount = "#amount_" + Id;
        var amountInput = $(amount).val();
        var insert = "#inserts_" + Id;
        var InsertInput = $(insert).val();
        var total = parseInt(amountInput * InsertInput);
        var totalamount = "#textamount_" + Id;
        $(totalamount).html("&#8358;" + total.toLocaleString("en"));

       



    });


    var finalAmount = $("#finalAmount").val();
 

  var order=  $("#TotalAmount").html("Price : &#8358; " + (finalAmount.toLocaleString("en")));

   
    $('input[name="selectedNewsPapersId"]').each(function () {

        var checked = $(this).is(":checked");

        if (!checked) {
            this.checked = checked;
        }

        var theIdPostFix = $(this).val();
        var isThisChecked = $(this).is(":checked");

      
        var serviceType = "serviceType_" + theIdPostFix;
       
        var printMediaType = "printMediaType_" + theIdPostFix;
        var printMediaInput = $("#" + printMediaType);

        var serviceTypeInput = $("#" + serviceType);

        var serviceColor = "serviceColor_" + theIdPostFix;
       
        var serviceColorInput = $("#" + serviceColor);


       
       var NumberOfInserts = "inserts_" + theIdPostFix;
        var NumberofInsertInput = $("#" + NumberOfInserts);

        var Dates = "date_"+theIdPostFix;
        var DatesInput = $("#" + Dates);

       
        if (isThisChecked) {
            serviceTypeInput.prop("disabled", false);
            serviceColorInput.prop("disabled", false);
            NumberofInsertInput.prop("disabled", false);
            DatesInput.prop("disabled", false);
            printMediaInput.prop('disabled', false);

        }
        if (!isThisChecked) {
            serviceTypeInput.prop("disabled", true);
            serviceColorInput.prop("disabled", true);
            NumberofInsertInput.prop("disabled", true);
            printMediaInput.prop('disabled', true);
            DatesInput.prop("disabled", true);
            DatesInput.val(" ");
        }

    }); 




    $('input[name="selectedNewsPapersId"]').click(function () {
        var checked = $(this).is(":checked");

        if (!checked) {
            this.checked = checked;
        }
        
        var theIdPostFix = $(this).val();
          
        var isThisChecked = $(this).is(":checked");

        var serviceType = "serviceType_" + theIdPostFix;


        var serviceTypeInput = $("#" + serviceType);

        var serviceColor = "serviceColor_" + theIdPostFix;

        var serviceColorInput = $("#" + serviceColor);

        var printMediaType = "printMediaType_" + theIdPostFix;
        var printMediaInput = $("#" + printMediaType);
        var NumberOfInserts = "inserts_" + theIdPostFix;
        var NumberofInsertInput = $("#" + NumberOfInserts);

        var Dates = "date_" + theIdPostFix;
        var DatesInput = $("#" + Dates);


        if (isThisChecked) {
            serviceTypeInput.prop("disabled", false);
       serviceColorInput.prop("disabled", false);
            NumberofInsertInput.prop("disabled", false);
            DatesInput.prop("disabled", false);
            DatesInput.val(" ");
            printMediaInput.prop('disabled', false);

        }
        if (!isThisChecked) {
            serviceTypeInput.prop("disabled", true);
            serviceColorInput.prop("disabled", true);
            NumberofInsertInput.prop("disabled", true);
            DatesInput.prop("disabled", true);
            printMediaInput.prop('disabled', true);
        }

    });


  



    //Generate TransactionTotal Price
    fadeInOutApconQuestion();
    fadeInOutArtWork();


    function generateTotalPrice(currentPrice = 0, newPrice = 0) {



        if (currentPrice === "" || isNaN(currentPrice)) {
            currentPrice = 0;
        }

       
    
        var $currentTotal = parseFloat($("#finalAmount").val());

       

        //Add to Any Price  for the TelevisionCollected
        var $initialTotal = parseFloat($currentTotal - parseFloat(currentPrice));
      
        var $finalPrice = $initialTotal + parseFloat(newPrice);

       

        $("#finalAmount").val($finalPrice);
        $finalPrice = parseInt($finalPrice || 0);

       
       
        $("#TotalAmount").html("Total Price : &#8358; " + ($finalPrice.toLocaleString("en")));
       

    }




    $("#ApconApprovalTypeId").change(function(e) {
        var $apconApprovalId = $(this).val();
        var $currentApprovalPrice = $('#ApconAmount').val();
        var $newPrice = 0;
        if ($apconApprovalId > 0) {


            $.ajax({
                "type": "Get",
                "url": "/Print/ApconApprovalPrice?apconApprovalId=" + $apconApprovalId,
                success: (function(data) {

                    console.log(data);
                    //Prodction Prices and Details
                    var $newPrice = parseFloat(data.apconApprovalAmount);
                    $("#ApconAmount").val($newPrice);
                    $("#selectedApconTypePriceId").val(data.apconApprovalTypePriceId);

                    generateTotalPrice($currentApprovalPrice, $newPrice);

                })
            });


        } else {
            $("#ApconAmount").val(0);
            $("#selectedApconTypePriceId").val("");
            generateTotalPrice($currentApprovalPrice, $newPrice);

        }
    });

    $("#DesignElementId").change(function(e) {
        var $designElementId = $(this).val();
        var $currentDesignPrice = $('#DesignElementAmount').val();
        var $newPrice = 0;

        if ($designElementId > 0) {


            $.ajax({
                "type": "Get",
                "url": "/Print/DesignElementPrice?designElementPriceId=" + $designElementId,
                success: (function(data) {

                    console.log(data);

                    //Prodction Prices and Details
                    $newPrice = parseFloat(data.DesignElementPrice);
                    $("#DesignElementAmount").val($newPrice);
                    $("#DesignElementPriceId").val(data.DesignElementPriceId);
                    $("#DesignAmountOption").fadeIn();

                    //Generate Price
                    generateTotalPrice($currentDesignPrice, $newPrice);
                })
            });

        } else {
            //Hide The Price Box and Remove the Current Pricce
            $("#DesignAmountOption").fadeOut();
            $("#DesignElementAmount").val(0);
            $("#DesignElementPriceId").val(0);
            generateTotalPrice($currentDesignPrice, $newPrice);

        }


    });


    $('.serviceType').change(function() {


        var $newPaperId = this.id.split("_")[1];
       
        var $selectedServiceType = $(this).val();
        var printMediaType = $("#printMediaType_" + $newPaperId).val();
        var serviceColorType = $("#serviceColor_" + $newPaperId).val();
        var $currentPrice = $('#amount_' + $newPaperId).val();

       
        var $newPrice = 0;

        if ($selectedServiceType > 0 && $newPaperId > 0 && serviceColorType && printMediaType>0) {


            $.ajax({
                "type": "Get",
                "url": "/Print/GetNewsPaperPrice?newsPaperId=" +
                    $newPaperId +
                    "&serviceTypeId=" +
                    $selectedServiceType + "&serviceColorId=" + serviceColorType + "&printMediaTypeId=" + printMediaType,
                success: (function(price) {
                    console.log(price);

                    //TODO : Price is to be Multiplied with the number of duration and airing time
                    $newPrice = price.price;


                    $('#amount_' + $newPaperId).val($newPrice);
                    $('#textamount_' + $newPaperId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));


                    genrateTotalAdvertPrice($newPaperId);
                })
            });
        } else {
            $('#totalamount_' + $newPaperId).val($newPrice);

            $('#amount_' + $newPaperId).val($newPrice);
            $('#textamount_' + $newPaperId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

            var $numberOfInserts = $('#inserts_' + $newPaperId).val();
            $currentPrice = $currentPrice * $numberOfInserts;
            generateTotalPrice($currentPrice, $newPrice);
        }


        //Call the  Controller to get the Price for the Selected Services Details

    });








    $('.printMediaType').change(function () {


        var $newPaperId = this.id.split("_")[1];
     
        var $selectedPrintMediaType = $(this).val();

        var serviceColorType = $("#serviceColor_" + $newPaperId).val();
        var $selectedServiceType = $("#serviceType_" + $newPaperId).val();

        var $currentPrice = $('#amount_' + $newPaperId).val();

        var $newPrice = 0;

        if ($selectedServiceType > 0 && $newPaperId > 0 && serviceColorType && $selectedPrintMediaType>0) {


            $.ajax({
                "type": "Get",
                "url": "/Print/GetNewsPaperPrice?newsPaperId=" +
                    $newPaperId +
                    "&serviceTypeId=" +
                    $selectedServiceType + "&serviceColorId=" + serviceColorType + "&printMediaTypeId=" + $selectedPrintMediaType,
                success: (function (price) {
                    console.log(price);

                    //TODO : Price is to be Multiplied with the number of duration and airing time
                    $newPrice = price.price;

                    console.log($newPrice);
                    $('#amount_' + $newPaperId).val($newPrice);
                    console.log($newPaperId, $newPrice);
                    $('#textamount_' + $newPaperId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
                    
                    
                    genrateTotalAdvertPrice($newPaperId);
                })
            });
        } else {
            $('#totalamount_' + $newPaperId).val($newPrice);
            $('#amount_' + $newPaperId).val($newPrice);
            $('#textamount_' + $newPaperId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

            var $numberOfInserts = $('#inserts_' + $newPaperId).val();
            $currentPrice = $currentPrice * $numberOfInserts;

         
            generateTotalPrice($currentPrice, $newPrice);
        }


        //Call the  Controller to get the Price for the Selected Services Details

    });


    $('.serviceColor').change(function () {

       
        var $newPaperId = this.id.split("_")[1];
        
       
        var $selectedServiceColor = $(this).val();

        var printMediaType = $("#printMediaType_" + $newPaperId).val();
        var $currentPrice = $('#amount_' + $newPaperId).val();
        var $selectedServiceType = $("#serviceType_"+ $newPaperId).val();

        var $newPrice = 0;
       
        if ($selectedServiceType > 0 && $newPaperId > 0 && $selectedServiceColor && printMediaType >0) {


            $.ajax({
                "type": "Get",
                "url": "/Print/GetNewsPaperPrice?newsPaperId=" +
                    $newPaperId +
                    "&serviceTypeId=" +
                    $selectedServiceType + "&serviceColorId=" + $selectedServiceColor + "&PrintMediaTypeId=" + printMediaType,
                success: (function (price) {
                    console.log(price);
                    alert("ok");
                    //TODO : Price is to be Multiplied with the number of duration and airing time
                    $newPrice = price.price;


                    $('#amount_' + $newPaperId).val($newPrice);
                    $('#textamount_' + $newPaperId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));


                    genrateTotalAdvertPrice($newPaperId);
                })
            });
        } else {
            $('#totalamount_' + $newPaperId).val($newPrice);
            $('#amount_' + $newPaperId).val($newPrice);
            $('#textamount_' + $newPaperId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
            var $numberOfInserts = $('#inserts_' + $newPaperId).val();
            $currentPrice = $currentPrice * $numberOfInserts;

            generateTotalPrice($currentPrice, $newPrice);
        }


        //Call the  Controller to get the Price for the Selected Services Details

    });







    $('.insertsNumber').keyup(function() {


        var airingNumber = this.id;
        var $NewsPaperId = (airingNumber.split("_")[1]);

        genrateTotalAdvertPrice($NewsPaperId);


    });


    function genrateTotalAdvertPrice($newsPaperId) {


        var $productPrice = $('#amount_' + $newsPaperId).val();
       
        var $currentPrice = $('#totalamount_' + $newsPaperId).val();

      
       
        var $numberOfInserts = $('#inserts_' + $newsPaperId).val();


     
        var $newPrice = $productPrice * $numberOfInserts;
      
        $('#totalamount_' + $newsPaperId).val($newPrice);
      
      $('#textamount_' + $newsPaperId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

       
        generateTotalPrice($currentPrice, $newPrice);


    }

    $("#Artwork").change(function() {

        fadeInOutArtWork();

    });


    $("#ApconQuestion").change(function() {

        fadeInOutApconQuestion();

    });

    function fadeInOutArtWork() {
        if ($("#Artwork").val() === "true") {
            $("#artworkIdentifier").fadeIn();

            $("#artworkdescription").fadeOut();


        }


        if ($("#Artwork").val() === "false") {

            $("#MaterialDigitalFileId").val();
            $("#artworkIdentifier").fadeOut();
            $("#artworkdescription").fadeIn();
            $("#artworkSelector").fadeOut();


        }


        if ($("#Artwork").val() === "Empty") {
            $("#artworkIdentifier").fadeOut();
            $("#artworkdescription").fadeOut();

        }
    }

    function fadeInOutApconQuestion() {


        if ($("#ApconQuestion").val() === "true") {

           
            // $("#apconidentifier").val("-1");
            $("#Apcondescribe").fadeIn();
            $("#ApconAmount").val(0);
           
            $("#selectedApconTypePriceId").val(-1);
           
            $("#apconidentifier").fadeOut();

            $("#ApconAmountOption").fadeOut();
            // $("#ApconAmount").val("");


        } else if ($("#ApconQuestion").val() === "false") {


            //  $("#ApconApprovalNumber").val("");
            $("#Apcondescribe").fadeOut();
            $("#ApconAmountOption").fadeIn();
            
            $("#apconidentifier").fadeIn();


        }

    }


    $('.selectorNo').change(function() {
        $("#Artwork").fadeOut();


    });


    $('#myModal').on('shown.bs.modal',
        function() {
            $('#myInput').trigger('focus');
        })

    $('.datepicker').datepicker();

    //var firstId = this.value;


    //$('.date').datepicker({

    //    multidate: true,
    //    format: 'dd-mm-yyyy',

    //});  


    $(function() { // will trigger when the document is ready
        $('.StartDatess').datepicker({
            dateFormat: "dd/M/yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-60:+0"

        }); //Initialise any date pickers
    });


    $(document).ready(function() {
        var date_input = $('input[name="date"]'); //our date input has the name "date"

        var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
        date_input.datepicker({
            format: 'mm/dd/yyyy',
            container: container,
            todayHighlight: true,
            autoclose: true,
        });

    })

});