


$("#UserRolesId").change(function () {
   
  var $selectedId=  $(this).val();
   
   
    if ($selectedId === "-1") {

        $("#submitButton").prop("disabled", true);


    }
    else {
        $("#submitButton").prop("disabled", false);
    }

})