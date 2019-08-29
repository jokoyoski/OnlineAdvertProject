$(document).ready(function () {

    ChangeApprovalType();
    ChangeApproval();
    ChangeMaterialQuestion();

    var $materialTypeId = 0;

    $('input[name="selectedRadioStationIds"]').each(function () {
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
            sdateInput.val("");
            edateInput.val("");
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
            var timingId = $("#timingCodeId_" + theIdPostFix).val();

            generateProductPrice(theIdPostFix, timingId, timingBeltId);
            genrateTotalRadioPrice(theIdPostFix);

            //Calculating Total Slots
      var slot =      $('#slots_' + theIdPostFix).val();

            calculateTotalSlot(days, slot, theIdPostFix);


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


        //Calculating Total Slots
        var slot = $('#slots_' + theIdPostFix).val();

        calculateTotalSlot(days, slot, theIdPostFix);

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

        //Calculating Total Slots
        var slot = $('#slots_' + theIdPostFix).val();

        calculateTotalSlot(days, slot, theIdPostFix);

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


    $("#MaterialQuestionId").change(function () {

        ChangeMaterialQuestion();
        $("#MaterialTypeId").trigger('change');

    });


    $("#ApconApproval").change(function () {

        ChangeApproval();
    });


    $("#ApconApprovalTypeId").change(function () {
        ChangeApprovalType();
    });


    $(".timeBeltId").change(function () {

        // console.log("ok");
        var TimeId = this.id;
        //we got the Id of the RadioStationId
        var RadioStationId = TimeId.split("_")[1];
        //we got the Id of the timingBelt selected
        var timingBeltId = $("#timeBelt_" + RadioStationId).val();

        var timingId = $("#timingCodeId_" + RadioStationId).val();
        generateProductPrice(RadioStationId, timingId, timingBeltId);
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
            $("#productionMaterial").val("");

        } else if ($("#MaterialQuestionId").val() === "SM") {

            $("#scriptingMaterialSection").removeClass("hide");
            $("#productionMaterialSection").removeClass("hide");

        } else {

            $("#scriptingMaterialSection").addClass("hide");
            $("#productionMaterialSection").addClass("hide");

        }
    }


    function ChangeApproval() {

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


    function ChangeApprovalType() {
        if ($("#ApconApprovalTypeId").val() > 0) {

            $("#ApconApproval").removeClass("hide");
            $("#ApconPrice").removeClass("hide");
        } else {
            //Hide Apcon Price Classes
            $("#ApconApproval").addClass("hide");
            $("#ApconPrice").addClass("hide");

            //Hide Apcon Approval Number Classes
            $("#ApconNumber").addClass("hide");
            $("#ApconNumber").val("");
        }
    }

    $("#ApconApprovalTypeId").change(function () {

        var $apconApprovalTypeId = $(this).val();
        var $currentPrice = $('#ApconPrice').val();
        var $newPrice = 0;


        if ($apconApprovalTypeId > 0) {
            $.ajax({
                "type": "Get",
                "url": "/Print/ApconApprovalPriceRadio?apconApprovalTypeId=" + $apconApprovalTypeId,
                success: (function (data) {
                    //console.log(data);


                    $newPrice = data.apconPrice;

                    if ($newPrice > 0) {
                        $("#ApconPrice").val(parseFloat($newPrice));
                        console.log("new is" + $newPrice);
                        $("#selectedApconTypePriceId").val(data.apconApprovalTypePriceId);

                        //Hide the Apcon Approval Number
                        $("#ApconNumber").addClass("hide");
                        $("#ApconNumber").val("");

                        if ($currentPrice === "") {
                            $currentPrice = 0;
                        }
                        console.log("current is" + $currentPrice);
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
                        $("#ApconNumber").val("");
                    }


                })
            });
        } else {
            $("#ApconPrice").val(0);
            $("#ApconTypePriceId").val("");

            generateTotalPrice($currentPrice, $newPrice);

        }
    });

    $("#MaterialTypeId").change(function () {


        $('input[name="selectedRadioStationIds"]').each(function () {
            var checked = $(this).is(":checked");

            if (!checked) {
                this.checked = checked;
            }

            var theIdPostFix = $(this).val();
          
            var sdateId = "startDate_" + theIdPostFix;
            var sdateInput = $("#" + sdateId);

            var edateId = "endDate_" + theIdPostFix;
            var edateInput = $("#" + edateId);

            var timingCodeId = "timingCodeId_" + theIdPostFix;
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
        //selectedMaterialScriptPrice
       

        var $currentScriptingPrice = $('#selectedMaterialScriptPrice').val();
        var $currentProductionPrice = $('#selectedMaterialProductionPrice').val();
        var $newProductionPrice = 0;
        var $newScriptingPrice = 0;
        if ($materialTypeId > 0) {
            $.ajax({
                "type": "Get",
                "url": "/Radio/GetMaterialPrices?materialTypeId=" + $materialTypeId,
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


    });


    //Generate Price for Radio Srtation
    $('.MaterialTypeTimingId').change(function () {


        var $selectedId = this.id;

        var $radioStationId = $selectedId.split("_")[1];

        //Matraial ID Value
        var $selectedMaterialId = $('#materialTypeTimingId_' + $radioStationId).val();

        //Selected Duration
        var $selectedTimingId = $('#timingCodeId_' + $radioStationId).val();

        generateProductPrice($radioStationId, $selectedTimingId);
        selectedScriptingTypeId
    });


    $('.TimingId').change(function () {
        
        var $selectedId = this.id;
        var RadioStationId = $selectedId.split("_")[1];
        
        //we got the Id of the timingBelt selected
        var timingBeltId = $("#timeBelt_" + RadioStationId).val();
        var timingId = $("#timingCodeId_" + RadioStationId).val();

        generateProductPrice(RadioStationId, timingId, timingBeltId);

    });

    $('.slots').keyup(function () {

        //Duration ID
        //Tv Station ID
        var $numberOfSlots = this.id;

        var $radioStationId = $numberOfSlots.split("_")[1];

       var $days = $('#dayscalc_' + $radioStationId).val();
        var $slot = $('#slots_' + $radioStationId).val();

        calculateTotalSlot($days, $slot, $radioStationId);
    });


    $('.totalSlots').keyup(function () {
        var $totalSlots = this.id;
        var $RadioStationId = $totalSlots.split("_")[1];
    


    });

    //
    //Generate Price Based On User Selected Value
    function generateProductPrice($radioStationId, $selectedTimingId, $selectedTimingBeltId) {


        var $currentPrice = $('#amount_' + $radioStationId).val();
        var $newPrice = 0;

        
        if ($radioStationId > 0 && $selectedTimingId > 0 && $selectedTimingBeltId > 0 && $materialTypeId>0) {


            var theUrl = "/Radio/GetRadioStationPrice?radioStation=" + $radioStationId + "&timingId=" + $selectedTimingId + "&timeBeltId=" + $selectedTimingBeltId+"&materialTypeId="+$materialTypeId;
             
            $.ajax({
                "type": "Get",
                "url": theUrl,

                success: (function (price) {

                    //TODO : Price is to be Multiplied with the number of duration and airing time
                    $newPrice = price;
                    
                    $('#amount_' + $radioStationId).val($newPrice);

                     
                   
                    $('#slotPrice_' + $radioStationId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
                   
                    genrateTotalRadioPrice($radioStationId);
                })
            });
        } else {
            $('#amount_' + $radioStationId).val($newPrice);
          
            $('#slotPrice_' + $radioStationId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
            
           
        }

    }

    $('.durationQty').keyup(function () {

        //Duration ID
        //Tv Station ID
        var $durationQty = this.id;
        var $radioStationId = ($durationQty.split("_")[1]);
        genrateTotalRadioPrice($radioStationId);

    });

    $('.airingNumber').keyup(function () {
        var airingNumber = this.id;
        var $radioStationId = (airingNumber.split("_")[1]);
        genrateTotalRadioPrice($radioStationId);


    });

    function genrateTotalRadioPrice($radioStationId) {

       
        //Price
        var $currentPrice = $('#totalamount_' + $radioStationId).val();

        if ($currentPrice === "")
        {
            var $slot = $('#slots_' + $radioStationId).val();


            //Airing Qty
            var $totalSlot = $('#totalSlots_' + $radioStationId).val();
            var $product = $('#amount_' + $radioStationId).val();
            var $day = $('#dayscalc_' + $radioStationId).val();

            $currentPrice =  $totalSlot * $product;
        }

        var $productPrice = $('#amount_' + $radioStationId).val();

  

        var $slots = $('#slots_' + $radioStationId).val();


        //Airing Qty
        var $totalSlots = $('#totalSlots_' + $radioStationId).val();
        console.log("totalslot" + $totalSlots);


        if ($totalSlots === "") {
            $totalSlots = 1;
        }
        if ($slots === 0) {
            $slots = 1;
        }

        //Multiply Radio Station time Price * DurationQty * AiringNumber
        var $newPrice = $productPrice * $totalSlots;
        
        $('#totalamount_' + $radioStationId).val($newPrice);
        $('#textamount_' + $radioStationId).html("&#8358; " + parseInt($newPrice).toLocaleString("en"));
           
        generateTotalPrice($currentPrice, $newPrice);
        
    }

    //Generate Total Transaction Price
    function generateTotalPrice(currentPrice = 0, newPrice = 0) {

        console.log("current" + currentPrice);

        console.log("new" + newPrice);

        if (currentPrice === "") {
            currentPrice = 0;
        }
        var $currentTotal = parseFloat($("#finalAmount").val());


        //  alert($currentTotal);
        //Add to Any Price Collected for the Television
        var $initialTotal = parseFloat($currentTotal - parseFloat(currentPrice));

        var $finalPrice = $initialTotal + parseFloat(newPrice);
        console.log("new final" + $finalPrice);
        console.log($finalPrice);
        

        $finalPrice = parseInt($finalPrice || 0);

        console.log($finalPrice);
        $("#text_finalAmount").html("Price : &#8358; " + ($finalPrice.toLocaleString("en")));

        $("#finalAmount").val($finalPrice);




    }

    //Calculeting Total Slots
    function calculateTotalSlot(days = 0, $slot = 0, radioStationId) {



        if (isNaN(days)) days = 0;
        if (isNaN($slot)) $slot = 0;



        $totalSlot = parseInt(days) * parseInt($slot);

        if (isNaN($totalSlot)) $totalSlot = 0;

        $('#totalSlots_' + radioStationId).val($totalSlot);

        genrateTotalRadioPrice(radioStationId);
    }



})