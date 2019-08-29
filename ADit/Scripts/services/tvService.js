$(document).ready(function() {

    ChangeMaterialQuestion();
    ChangeApconApproval();
    ChangeApconApprovalType();



    var $materialTypeId = 0;

    //Generate Total Tv Price
    function genrateTotalTVPrice($tvStationId) {
        //Price
        var $currentPrice = $('#totalamount_' + $tvStationId).val();
        
        if ($currentPrice ==="")
        {
            var $slot = $('#slots_' + $tvStationId).val();


            //Airing Qty
            var $totalSlot = $('#totalSlots_' + $tvStationId).val();
            var $product = $('#amount_' + $tvStationId).val();
            var $day = $('#dayscalc_' + $tvStationId).val();

            $currentPrice = $totalSlot * $product;

        }

        var $productPrice = $('#amount_' + $tvStationId).val();
       
        //Duration Quantity

        var $slots = $('#slots_' + $tvStationId).val();
        

        //Airing Qty
        var $totalSlots = $('#totalSlots_' + $tvStationId).val();

        var $days = $('#dayscalc_' + $tvStationId).val();


        //Multiply TV Station time Price Price By Total Slots
        var $newPrice = $productPrice  * $totalSlots;


     


        $('#totalamount_' + $tvStationId).val($newPrice);
        $('#textamount_' + $tvStationId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

       

       generateTotalPrice($currentPrice, $newPrice);


    }
    

   
    $('input[name="selectedTvStationIds"]').each(function () {
        
        //check if its checked
        var checked = $(this).is(":checked");

        if (!checked) {
            this.checked = checked;
        }

        var theIdPostFix = $(this).val();
        var isThisChecked = $(this).is(":checked");
        var sdateId = "startDate_" + theIdPostFix;
        var sdateInput = $("#" + sdateId);

        var edateId = "endDate_" + theIdPostFix;
        var edateInput = $("#" + edateId);

        var timingCodeId = "timingCode_" + theIdPostFix;
        var timingCodeInput = $("#" + timingCodeId);

        var timeBeltId = "timeBelt_" + theIdPostFix;
        var timeBeltIdInput = $("#" + timeBeltId);

        var slotsId = "slots_" + theIdPostFix;
        var slotsIdInput = $("#" + slotsId);

        var totalSlotsId = "totalSlots_" + theIdPostFix;
        var totalSlotsIdInput = $("#" + totalSlotsId);

        if (isThisChecked) {
            sdateInput.prop("disabled", false);
            edateInput.prop("disabled", false);
            timingCodeInput.prop("disabled", false);
            timeBeltIdInput.prop("disabled", false);
            slotsIdInput.prop("disabled", false);
            totalSlotsIdInput.prop("disabled", false);

        }
        if (!isThisChecked) {
            sdateInput.prop("disabled", true);
            edateInput.prop("disabled", true);
            timingCodeInput.prop("disabled", true);
            timeBeltIdInput.prop("disabled", true);
            slotsIdInput.prop("disabled", true);
            totalSlotsIdInput.prop("disabled", true);
            sdateInput.val("");
            edateInput.val("");
        }
    });



    $("#MaterialQuestionId").change(function() {


        ChangeMaterialQuestion();
        $("#MaterialTypeId").trigger('change');

    });

    $("#ApconApproval").change(function() {

        ChangeApconApproval();
    });

    $("#ApconApprovalTypeId").change(function() {


        ChangeApconApprovalType();

    });

    function ChangeMaterialQuestion() {
        if ($("#MaterialQuestionId").val() === "N") {
            $("#scriptingMaterialSection").addClass("hide");
            $("#scriptingMaterial").val("");
            $("#productionMaterialSection").addClass("hide");
            $("#productionMaterial").val("");
        } else if ($("#MaterialQuestionId").val() === "S") {
            $("#scriptingMaterialSection").removeClass("hide");
            $("#productionMaterialSection").addClass("hide");
            $("#productionMaterial").val("");
        } else if ($("#MaterialQuestionId").val() === "SM") {
            $("#scriptingMaterialSection").removeClass("hide");
            $("#productionMaterialSection").removeClass("hide");
        } else {
            $("#scriptingMaterialSection").addClass("hide");
            $("#productionMaterialSection").addClass("hide");
        }
    }

    function ChangeApconApproval() {
        if ($("#ApconApproval").val() === "Yes") {
            $("#ApconNumber").removeClass("hide");
            $("#ApconType").addClass("hide");


        } else if ($("#ApconApproval").val() === "No") {
            $("#ApconNumber").addClass("hide");
            $("#ApconType").removeClass("hide");

        } else {
            $("#ApconNumber").addClass("hide");
            $("#ApconType").removeClass("hide");
        }


    }

    function ChangeApconApprovalType() {
        if ($("#ApconApprovalTypeId").val() !== -1) {


            $("#ApconApprovalPriceSection").removeClass("hide");
            $("#ApconPrice").removeClass("hide");

            $("#ApconApprovalNumberSection").addClass("hide");

        } else {
            //Hide Apcon Price Classes
            $("#ApconApprovalPriceSection").addClass("hide");
            $("#ApconPrice").addClass("hide");


            //Hide Apcon Approval Number Classes
            $("#ApconApprovalNumberSection").removeClass("hide");
            $("#ApconNumber").removeClass("hide");
            $("#ApconNumber").val("");
        }
    }


    $("#ApconApprovalTypeId").change(function() {

        var $apconApprovalTypeId = $(this).val();
        var $currentPrice = $("#ApconPrice").val();
        var $newPrice = 0;


        if ($apconApprovalTypeId > 0) {
            $.ajax({
                "type": "Get",
                "url": "/Print/ApconApprovalPriceRadio?apconApprovalTypeId=" + $apconApprovalTypeId,
                success: (function(data) {
                    console.log(data);


                    $newPrice = data.apconPrice;

                    if ($newPrice > 0) {
                        $("#ApconPrice").val(parseFloat($newPrice));
                        $("#selectedApconTypePriceId").val(data.apconApprovalTypePriceId);

                        //Hide the Apcon Approval Number
                        $("#ApconApprovalNumberSection").addClass("hide");
                        $("#ApconNumber").addClass("hide");
                        $("#ApconNumber").val("");

                        //Show the Apcon Approval Type Price
                        $("#ApconApproval").removeClass("hide");
                        $("#ApconPrice").removeClass("hide");


                        //Generate Totla Price
                        generateTotalPrice($currentPrice, $newPrice);
                    } else {

                        //The Price is zero, The Only Reason is that user have an Apcon Approval Number thats needs to be provided
                        $("#ApconPrice").val(0);
                        $("#ApconTypePriceId").val("");
                        $("#ApconApproval").addClass("hide");
                        $("#ApconPrice").addClass("hide");

                        //Show the Apcon Approval Number Box

                        $("#ApconNumber").removeClass("hide");
                        $("#ApconApprovalNumberSection").removeClass("hide");
                        $("#ApconNumber").val("");
                    }


                })
            });
        } else {
            $("#ApconPrice").val(0);
            $("#ApconTypePriceId").val("");
            $("#ApconApproval").addClass("hide");
            $("#ApconPrice").addClass("hide");


            //Show the Apcon Approval Number Box

            $("#ApconNumber").removeClass("hide");
            $("#ApconApprovalNumberSection").removeClass("hide");

            $("#ApconNumber").val("");

            generateTotalPrice($currentPrice, $newPrice);

        }


    });


    $("#MaterialTypeId").change(function() {

        $('input[name="selectedTvStationIds"]').each(function () {
            var checked = $(this).is(":checked");

            if (!checked) {
                this.checked = checked;
            }

            var theIdPostFix = $(this).val();

            var sdateId = "startDate_" + theIdPostFix;
            var sdateInput = $("#" + sdateId);

            var edateId = "endDate_" + theIdPostFix;
            var edateInput = $("#" + edateId);


            var timingCodeId = "timingCode_" + theIdPostFix;
            // Round down.
            $('#days_' + theIdPostFix).html(0);
            $('#dayscalc_' + theIdPostFix).val(0);

            var timingCodeInput = $("#" + timingCodeId).val(-1);

            var timeBeltId = "timeBelt_" + theIdPostFix;
            var timeBeltIdInput = $("#" + timeBeltId).val(-1);

            var slotsId = "slots_" + theIdPostFix;
            var slotsIdInput = $("#" + slotsId).val(0);

            $("#slotPrice_" + theIdPostFix).html(0);

            var totalSlotsId = "totalSlots_" + theIdPostFix;
            var totalSlotsIdInput = $("#" + totalSlotsId).val(0);



            calculateTotalSlot(0, 0, theIdPostFix);

        });
        $materialTypeId = $(this).val();
        if ($materialTypeId === "-1") {
            var $currentScriptingPrices = $('#selectedMaterialScriptPrice').val();
            var $currentProductionPrices = $('#selectedMaterialProductionPrice').val();

            var $newScriptingPrices = $('#selectedMaterialScriptPrice').val(0);
            $newScriptingPrices = 0;

            var $newProductionPrices = $('#selectedMaterialProductionPrice').val(0);
            $newProductionPrices = 0;
            generateTotalPrice($currentProductionPrices, $newProductionPrices);

            generateTotalPrice($currentScriptingPrices, $newScriptingPrices);
        } else
        {

            var $currentScriptingPrice = $('#selectedMaterialScriptPrice').val();
            var $currentProductionPrice = $('#selectedMaterialProductionPrice').val();
            var $newProductionPrice = 0;
            var $newScriptingPrice = 0;
            if ($materialTypeId > 0) {
                $.ajax({
                    "type": "Get",
                    "url": "/Tv/TVMaterialPrices?materialPriceId=" + $materialTypeId,
                    success: (function (data) {

                        // console.log(data);


                        //Prodction Prices and Details
                        $newProductionPrice = data.productionPrice;


                        if ($("#MaterialQuestionId").val() === "SM") {
                            $newProductionPrice = 0;
                            $("#selectedMaterialProductionPrice").val($newProductionPrice);
                            $("#selectedMaterialProductionTypeId").val(0);
                            generateTotalPrice($currentProductionPrice, $newProductionPrice);
                        } else {
                            $("#selectedMaterialProductionPrice").val($newProductionPrice);
                            $("#selectedMaterialProductionTypeId").val(data.productionPriceId);
                            generateTotalPrice($currentProductionPrice, $newProductionPrice);
                        }


                        //Scriting Prices and Details
                        $newScriptingPrice = data.scriptingPrice;

                        if ($("#MaterialQuestionId").val() === "S") {

                            $newScriptingPrice = 0;
                            $("#selectedMaterialScriptPrice").val($newScriptingPrice);
                            $("#selectedScriptingTypeId").val(0);
                            console.log("the current price" + $currentScriptingPrice);
                            console.log("the new price" + $newScriptingPrice);
                            generateTotalPrice($currentScriptingPrice, $newScriptingPrice);
                        } else if ($("#MaterialQuestionId").val() === "SM") {
                            $newScriptingPrice = 0;

                            $("#selectedMaterialScriptPrice").val($newScriptingPrice);
                            $("#selectedScriptingTypeId").val(0);
                            generateTotalPrice($currentScriptingPrice, $newScriptingPrice);
                        } else if ($("#MaterialQuestionId").val() === "N") {
                            $("#selectedMaterialScriptPrice").val($newScriptingPrice);
                            $("#selectedScriptingTypeId").val(data.scriptingPriceId);
                            generateTotalPrice($currentScriptingPrice, $newScriptingPrice);

                        } else {
                            $("#selectedMaterialScriptPrice").val($newScriptingPrice);
                            $("#selectedScriptingTypeId").val(data.scriptingPriceId);
                            generateTotalPrice($currentScriptingPrice, $newScriptingPrice);

                        }


                    })


                });


            }

        }


        
        //selectedMaterialScriptPrice
        
       


      });
    //$("#MaterialTypeId").change(function() {


    //    var $materialTypeId = $(this).val();
    //    var $currentScriptingPrice = $("#selectedMaterialScriptPrice").val();
    //    var $currentProductionPrice = $("#selectedMaterialProductionPrice").val();
    //    var $newProductionPrice = 0;
    //    var $newScriptingPrice = 0;

    //    if ($materialTypeId > 0) {
    //        $.ajax({
    //            "type": "Get",
    //            "url": "/Radio/GetMaterialPrices?materialTypeId=" + $materialTypeId,
    //            success: (function(data) {

    //                console.log(data);
    //                //Prodction Prices and Details
    //                $newProductionPrice = data.productionPrice;
    //                $("#selectedMaterialProductionPrice").val($newProductionPrice);
    //                $("#selectedMaterialProductionTypeId").val(data.productionPriceId);
    //                generateTotalPrice($currentProductionPrice, $newProductionPrice);


    //                //Scriting Prices and Details
    //                $newScriptingPrice = data.scriptingPrice;

    //                $("#selectedMaterialScriptPrice").val($newScriptingPrice);
    //                $("#selectedScriptingTypeId").val(data.scriptingPriceId);
    //                generateTotalPrice($currentScriptingPrice, $newScriptingPrice);
    //            })


    //        });


    //    } else {


    //        $newProductionPrice = 0;
    //        $("#selectedMaterialProductionPrice").val($newProductionPrice);
    //        $("#selectedMaterialProductionTypeId").val(0);
    //        generateTotalPrice($currentProductionPrice, $newProductionPrice);


    //        //Scriting Prices and Details
    //        $newScriptingPrice =0;

    //        $("#selectedMaterialScriptPrice").val($newScriptingPrice);
    //        $("#selectedScriptingTypeId").val(0);
    //        generateTotalPrice($currentScriptingPrice, $newScriptingPrice);


    //    }


    //});


    //Generate Price for TV Srtation

//Get The Tv Prices from the Database
        //rate Total Transaction Price
        function generateTotalPrice(currentPrice = 0, newPrice = 0) {

            if (currentPrice === "") {
                currentPrice = 0;
            }



            var $currentTotal = ($("#finalAmount").val());
          


            //Add to Any Price Collected for the Television
            var $initialTotal = parseFloat($currentTotal - parseFloat(currentPrice));



            var $finalPrice = $initialTotal + parseFloat(newPrice);

         

            $finalPrice = parseInt($finalPrice || 0);


            $("#text_finalAmount").html("Price : &#8358; " + ($finalPrice.toLocaleString("en")));

            $("#finalAmount").val($finalPrice);


        }

        $('.TimingId').change(function() {
            //Get The Current Television Station ID
            var timindID = this.id;

            var $tvStationId = (timindID.split("_")[1]);
            var $selectedTiming = $("#timingCode_" + $tvStationId).val(); // Get The Selected Timing

            //Get The Selected Time Belt
            var $selectedTimeBelt = $("#timeBelt_" + $tvStationId).val();


            //Call the  Controller to get the Price for the Selected Services Details
            getTVPrice($tvStationId, $selectedTiming, $selectedTimeBelt);

        });


        $('.timeBeltId').change(function() {
            //Get The Current Television Station ID
            var timeBeltId = this.id;

            var $tvStationId = (timeBeltId.split("_")[1]);
            var $selectedTiming = $("#timingCode_" + $tvStationId).val(); // Get The Selected Timing

            //Get The Selected Time Belt
            var $selectedTimeBelt = $("#timeBelt_" + $tvStationId).val();


            //Call the  Controller to get the Price for the Selected Services Details
            getTVPrice($tvStationId, $selectedTiming, $selectedTimeBelt);

        });


        $('.slots').keyup(function() {

          
            var $slots = this.id;

            var $tvStationId = ($slots.split("_")[1]);

            //Calculate Total Slots
            
            var days = $('#dayscalc_' + $tvStationId).val();
            var $numberOfSlots = $('#slots_' + $tvStationId).val();

          

            calculateTotalSlot(days, $numberOfSlots, $tvStationId);


        });


        $('.totalSlots').keyup(function() {
            var $totalSlots = this.id;
            var $tvStationId = ($totalSlots.split("_")[1]);
           


        });


        //Calculate Number of Days in a Day
        
        


        
       
    
    //Change Prices based on


    //Gene
    $('input[name="selectedTvStationIds"]').click(function () {

        var checked = $(this).is(":checked");

        if (!checked) {
            this.checked = checked;
        }
       
        var theIdPostFix = $(this).val();

        var isThisChecked = $(this).is(":checked");

        var sdateId = "startDate_" + theIdPostFix;
        var sdateInput = $("#" + sdateId);

        var edateId = "endDate_" + theIdPostFix;
        var edateInput = $("#" + edateId);

        var timingCodeId = "timingCode_" + theIdPostFix;
        var timingCodeInput = $("#" + timingCodeId);

        var timeBeltId = "timeBelt_" + theIdPostFix;
        var timeBeltIdInput = $("#" + timeBeltId);

        var slotsId = "slots_" + theIdPostFix;
        var slotsIdInput = $("#" + slotsId);

        var totalSlotsId = "totalSlots_" + theIdPostFix;
        var totalSlotsIdInput = $("#" + totalSlotsId);

        if (isThisChecked) {
            sdateInput.prop("disabled", false);
            edateInput.prop("disabled", false);
            timingCodeInput.prop("disabled", false);
            timeBeltIdInput.prop("disabled", false);
            slotsIdInput.prop("disabled", false);
            totalSlotsIdInput.prop("disabled", false);
        }

        if (!isThisChecked) {
            sdateInput.prop("disabled", true);
            edateInput.prop("disabled", true);
            timingCodeInput.prop("disabled", true);
            timeBeltIdInput.prop("disabled", true);
            slotsIdInput.prop("disabled", true);
            totalSlotsIdInput.prop("disabled", true);
            sdateInput.val(" ");
            edateInput.val(" ");
        }
    });
   
    $("[id^=startDate_").each(function () {


        var theId = this.id;
        var splitResult = theId.split('_');

        var theIdPostFix = splitResult[1];

        var checkboxId = "checkBox_" + theIdPostFix;
        var checkboxInput = $("#" + checkboxId);

        var checked = checkboxInput.is(":checked");

        if (checked) {

            var endDateId = "endDate_" + theIdPostFix;
            var endDateInput = $("#" + endDateId);
            var endDate = endDateInput.val();

            var startDateId = "startDate_" + theIdPostFix;
            var startDateInput = $("#" + startDateId);
            var startDate = startDateInput.val();

            var startDay = new Date(startDate);
            var endDay = new Date(endDate);
            var millisecondsPerDay = 1000 * 60 * 60 * 24;

            var millisBetween = endDay.getTime() - startDay.getTime();
            var days = Math.floor(millisBetween / millisecondsPerDay) + 1;

            // Round down.
            $('#days_' + theIdPostFix).html(days);
            $('#dayscalc_' + theIdPostFix).val(days);

            //compute totals
            var timingBeltId = $("#timeBelt_" + theIdPostFix).val();
            var timingId = $("#timingCode_" + theIdPostFix).val();
            
          
            getTVPrice(theIdPostFix, timingId, timingBeltId);

            var $slot = $('#slots_' + theIdPostFix).val();


            
            //Calculate Total Slot
            calculateTotalSlot(days, $slot, theIdPostFix);
        }
    });


    

    $("[id^=startDate_").change(function () {

        var theId = this.id;
        var splitResult = theId.split('_');

        var theIdPostFix = splitResult[1];

        var endDateId = "endDate_" + theIdPostFix;
        var endDateInput = $("#" + endDateId);
        var endDate = endDateInput.val();
        var startDate = $(this).val();

        var startDay = new Date(startDate);
        var endDay = new Date(endDate);
        var millisecondsPerDay = 1000 * 60 * 60 * 24;

        var millisBetween = endDay.getTime() - startDay.getTime();
        var days = Math.floor(millisBetween / millisecondsPerDay) + 1;

        // Round down.
        $('#days_' + theIdPostFix).html(days);
        $('#dayscalc_' + theIdPostFix).val(days);


        var $slot = $('#slots_' + theIdPostFix).val();
        //Calculate Total Slot
        calculateTotalSlot(days, $slot, theIdPostFix);
    });

    $("[id^=endDate_").change(function () {

        var theId = this.id;
        var splitResult = theId.split('_');

        var theIdPostFix = splitResult[1];

        var startDateId = "startDate_" + theIdPostFix;
        var startDateInput = $("#" + startDateId);
        var startDate = startDateInput.val();
        var endDate = $(this).val();

        var startDay = new Date(startDate);
        var endDay = new Date(endDate);
        var millisecondsPerDay = 1000 * 60 * 60 * 24;

        var millisBetween = endDay.getTime() - startDay.getTime();
        var days = Math.floor(millisBetween / millisecondsPerDay) + 1;

        // Round down.
        $('#days_' + theIdPostFix).html(days);
        $('#dayscalc_' + theIdPostFix).val(days);


        var $slot = $('#slots_' + theIdPostFix).val();

        //Calculate Total Slot
        calculateTotalSlot(days, $slot, theIdPostFix);
    });

    $('input[name="selectedRadioStationIds"]').click(function () {

        var checked = $(this).is(":checked");

        if (!checked) {
            this.checked = checked;
        }

        var theIdPostFix = $(this).val();

        var isThisChecked = $(this).is(":checked");

        var sdateId = "startDate_" + theIdPostFix;
        var sdateInput = $("#" + sdateId);

        var edateId = "endDate_" + theIdPostFix;
        var edateInput = $("#" + edateId);

        var timingCodeId = "timingCodeId_" + theIdPostFix;
        var timingCodeInput = $("#" + timingCodeId);

        var timeBeltId = "timeBelt_" + theIdPostFix;
        var timeBeltIdInput = $("#" + timeBeltId);

        var slotsId = "slots_" + theIdPostFix;
        var slotsIdInput = $("#" + slotsId);

        var totalSlotsId = "totalSlots_" + theIdPostFix;
        var totalSlotsIdInput = $("#" + totalSlotsId);

        if (isThisChecked) {
            sdateInput.prop("disabled", false);
            edateInput.prop("disabled", false);
            timingCodeInput.prop("disabled", false);
            timeBeltIdInput.prop("disabled", false);
            slotsIdInput.prop("disabled", false);
            totalSlotsIdInput.prop("disabled", false);
        }

        if (!isThisChecked) {
            sdateInput.prop("disabled", true);
            edateInput.prop("disabled", true);
            timingCodeInput.prop("disabled", true);
            timeBeltIdInput.prop("disabled", true);
            slotsIdInput.prop("disabled", true);
            totalSlotsIdInput.prop("disabled", true);
            sdateInput.val(" ");
            edateInput.val(" ");
        }
    });

    //Get Television Prices
    function getTVPrice($tvStationId, $selectedTiming, $selectedTimeBelt) {


        var $currentPrice = $('#amount_' + $tvStationId).val(); //Get The Current Price
        var $newPrice = 0; // Initialise the New Price



        if ($selectedTiming > 0 && $tvStationId > 0 && $selectedTimeBelt > 0 && $materialTypeId > 0) {

            $.ajax({
                "type": "Get",
                "url": "/Tv/TVStationPrice?tvStation=" +
                    $tvStationId +
                    "&timingId=" +
                    $selectedTiming +
                    "&timeBeltId=" +
                    $selectedTimeBelt + "&materialTypeId=" + $materialTypeId ,

                success: (function (price) {
                    console.log(price);


                    $newPrice = price;

                    $('#amount_' + $tvStationId).val($newPrice);
                    // $('#totalamount_' + $tvStationId).val($newPrice);
                    $('#slotPrice_' + $tvStationId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));

                    $('#textamount_' + $tvStationId)
                        .html("&#8358; " + parseInt($newPrice).toLocaleString("en"));


                    genrateTotalTVPrice($tvStationId);
                })
            });

        } else {

            $('#amount_' + $tvStationId).val($newPrice);
            $('#textamount_' + $tvStationId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));


            
        }

    }


    //Calculeting Total Slots
    function calculateTotalSlot(days = 0, $slot = 0, $tvStationId) {

       

        if (isNaN(days)) days = 0;
        if (isNaN($slot)) $slot = 0;

       

        $totalSlot = parseInt(days) * parseInt($slot);

        if (isNaN($totalSlot)) $totalSlot = 0;
        
        $('#totalSlots_' + $tvStationId).val($totalSlot);

        genrateTotalTVPrice($tvStationId);

    }
});


$(document).ready(function() {
    $("#ApconApprovalTypeId").change(function() {
        $("#SelectedAbconAprovalPrice").val($(this).find("option:selected").text().split(":")[1]);
        $("#SelectedAbconAprovalPrice").prop("readonly", true);

    });
});