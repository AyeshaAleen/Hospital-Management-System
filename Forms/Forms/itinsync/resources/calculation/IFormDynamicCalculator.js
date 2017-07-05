var formValidationMasks = new Array();
var FORMS_CALCULATION_PLUS = "PLUS";
var FORMS_CALCULATION_MINUS = "MINUS";
var FORMS_CALCULATION_MULTIPLY = "MULTIPLY";
var FORMS_CALCULATION_DIVIDE = "DIVIDE";
var FORMS_CONTROL_PERCENTAGE = "PERCENTAGE ";
var FORMS_CONTROL_AVERAGE = "AVERAGE";
var PAGE_CONTEXT = "CommonMasterBody_DocumnetMasterBody_";
var controllsObject = new Array();
function calculation() {
    id = "forms";
    isForm = true;

    this.isThisForm = isForm;
    this.formFieldsObjects = new Array();
    this.toplevelId = id;
    this.initted = false;

    if (this.initted == true)
        return;

    var theDiv;
    var idDiv = this.toplevelId;
    if (this.isThisForm)
        theDiv = document.forms[idDiv];
    else
        theDiv = document.getElementById(idDiv);

    // Is the passed div valid??
    if (!theDiv)
        return;


    // Get all the components
    var inputFields = theDiv.getElementsByTagName('INPUT');
    var selectBoxes = theDiv.getElementsByTagName('SELECT');

    this.initInputFields(inputFields, idDiv, false);



}

function initInputFields(inputFields, idDiv, bIgnoreSkipValidation) {
    

    
    controllsObject = new Array();
    for (var i = 0; i < inputFields.length; i++) 
    {
        var inputObj = inputFields[i];
        // Is it one of our validations
        if (!this.containsVaildParametersCalculation(inputObj)) continue;

        inputObjFormula = inputObj.getAttribute('formula');
        if (!inputObjFormula)
            continue;
         //Dynalic_radio1 = object 
        controllsObject.push(inputObj);
    }

    for (var i = 0; i < controllsObject.length; i++)
    {
        currentObject = controllsObject[i];
        var currentID = currentObject.getAttribute("id");
        currentID = currentID.replace(PAGE_CONTEXT, "");
        inputObjFormula = currentObject.getAttribute('formula');
       var  avgCounter=0;
        for (var j = 0; j < inputFields.length; j++)
        {
            var inputObj = inputFields[j];
            

            if (inputObj.id == PAGE_CONTEXT + "dynamic_textSIO2_29" || inputObj.id == PAGE_CONTEXT + "dynamic_textSIO2_9")
            {
                
            }
            if (!this.containsVaildParametersCalculation(inputObj)) continue;

            
            var currentID = inputObj.getAttribute("id");
            currentID = currentID.replace(PAGE_CONTEXT, "");

            if (inputObjFormula.includes(currentID)) {

                var inputType = this.getInputType(inputObj);
                var checkOrRadio = ((inputType == 'RADIO') || (inputType == 'CHECKBOX'));

                if (checkOrRadio && !inputObj.checked)
                    inputObjFormula = inputObjFormula.replace(currentID, "0");

                else if (inputType == "TEXT") {
                    if (inputObj.getAttribute("formula", "").length == 0 && inputObj.value.length > 0) {
                        inputObjFormula = inputObjFormula.replace(currentID, inputObj.value);
                        avgCounter++;
                    }

                    else
                        inputObjFormula = inputObjFormula.replace(currentID, "0");
                }


                else
                    inputObjFormula = inputObjFormula.replace(currentID, inputObj.getAttribute("points"));


            }
        }

        //in case of avg we need to set count
        if (inputObjFormula.includes("AVG"))
            inputObjFormula = inputObjFormula.replace("AVG", avgCounter);
        var finalResult = eval(inputObjFormula);
        if (!isNaN(finalResult))
            currentObject.value = finalResult;
        
     }

}


function getInputType(inputObj) {
    var type = "";
    if (inputObj.tagName == 'INPUT')
        type = inputObj.type.toUpperCase();

    return (type);
}

function containsVaildParametersCalculation(inputObj) {
    // If we are a radio or checkbox then ask our parents
    var tagName = inputObj.tagName.toUpperCase();
    var type = this.getInputType(inputObj);

    // Return false for 'hidden' type input controls 
    if (type == 'HIDDEN')
        return false;

    var useObjectForParams = inputObj;

    if (inputObj) {
        var req = useObjectForParams.getAttribute("points");
        if (req)
            return (true);

        var opt = useObjectForParams.getAttribute("resultField");
        if (opt)
            return (true);

        var msk = useObjectForParams.getAttribute("imask");
        if (msk)
            return (true);

        var formula = useObjectForParams.getAttribute("formula");
        if (formula)
            return (true);

        var req = useObjectForParams.getAttribute("irequired");
        if (req)
            return (true);

    }

    return (false);
}