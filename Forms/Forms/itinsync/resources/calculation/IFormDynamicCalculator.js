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
    debugger;

    

    for (var i = 0; i < inputFields.length; i++) {
        var inputObj = inputFields[i];
        // Is it one of our validations
        if (!this.containsVaildParameters(inputObj)) continue;

        // Get the type
        var inputType = this.getInputType(inputObj);
        var checkOrRadio = ((inputType == 'RADIO') || (inputType == 'CHECKBOX'));


        // Get the id
        var inputObjName = inputObj.getAttribute('id');
        if (checkOrRadio)
            inputObjName = inputObj.getAttribute('id');
        if (inputObjName == null)
            inputObjName = inputObj.getAttribute('name');

        if (!inputObjName)
            continue;
        //Dynalic_radio1 = object 
        controllsObject.push(inputObj)
       
       // controllsObject[inputObjName] = inputObj;

        if (checkOrRadio && !inputObj.checked) {
            continue;
        }
        inputObjFormula = inputObj.getAttribute('formula');
        if (!inputObjFormula)
            continue;
        //((10 + dynamic_radio2+ dynamic_radio3 +dynamic_radio4)/4100)
        //"(10+20)"

        //(parseint(10)+parseint(20))
        debugger;
        for (var count = 0; count < controllsObject.length; count++)
        {
            currentObject = controllsObject[count];

            var currentID = currentObject.getAttribute("id");
            currentID = currentID.replace(PAGE_CONTEXT, "");
            if (inputObjFormula.includes(currentID))
            {

                var inputType = this.getInputType(currentObject);
                var checkOrRadio = ((inputType == 'RADIO') || (inputType == 'CHECKBOX'));

                if (checkOrRadio && !currentObject.checked)
                    inputObjFormula = inputObjFormula.replace(currentID, "0");

                else if (inputType == "TEXT") {
                    if (currentObject.getAttribute("formula", "").length == 0 && currentObject.value.length>0)
                        inputObjFormula = inputObjFormula.replace(currentID, currentObject.value);
                    else
                        inputObjFormula = inputObjFormula.replace(currentID, "0");
                }
                    

                else
                    inputObjFormula = inputObjFormula.replace(currentID, currentObject.getAttribute("points"));


            }
        }

        var finalResult = eval(inputObjFormula);
        inputObj.value = finalResult;
    }


}


function getInputType(inputObj) {
    var type = "";
    if (inputObj.tagName == 'INPUT')
        type = inputObj.type.toUpperCase();

    return (type);
}

function containsVaildParameters(inputObj) {
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

        

    }

    return (false);
}