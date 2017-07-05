var formValidationMasks = new Array();
var FORMS_CONTROL_EQUAL = "=";
var FORMS_CONTROL_GREATER = ">";
var FORMS_CONTROL_LESS = "<";
var FORMS_CONTROL_GREATEREQUAL = ">=";
var FORMS_CONTROL_LESSEQUAL = "<=";
var FORMS_CONTROL_NOTEQUAL = "!=";
var OPERATION_TOKEN = [FORMS_CONTROL_EQUAL, FORMS_CONTROL_GREATER, FORMS_CONTROL_LESS, FORMS_CONTROL_GREATEREQUAL, FORMS_CONTROL_LESSEQUAL, FORMS_CONTROL_NOTEQUAL];
var PAGE_CONTEXT = "CommonMasterBody_DocumnetMasterBody_";
var controllsConditionObject = new Array();

function conditions() {
    controllsConditionObject = new Array();
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
    var inputConditionFields = theDiv.getElementsByTagName('INPUT');
    var selectBoxes = theDiv.getElementsByTagName('SELECT');

    this.initInputConditionFields(inputConditionFields, idDiv, false);



}

function initInputConditionFields(inputFields, idDiv, bIgnoreSkipValidation) {
    

    

    for (var i = 0; i < inputFields.length; i++) {
        var inputObj = inputFields[i];
        // Is it one of our validations
        if (!this.containsVaildParametersCondition(inputObj)) continue;

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
        
        inputObjCondition = inputObj.getAttribute('condition');
        if (!inputObjCondition)
            continue;
        //Dynalic_radio1 = object 
        controllsConditionObject.push(inputObj);
        
    }

    for (var count = 0; count < controllsConditionObject.length; count++) {
        currentConditionObj = controllsConditionObject[count];
        var conditionInputType = this.getInputType(currentConditionObj);
        var conditionCheckOrRadio = ((conditionInputType == 'RADIO') || (conditionInputType == 'CHECKBOX'));
        var condition = currentConditionObj.getAttribute("condition");
        

        for (var j = 0; j < inputFields.length; j++)
        {
            var currentObject = inputFields[j];
            if (!this.containsVaildParametersCondition(currentObject)) continue;

            var currentID = currentObject.getAttribute("id");
            currentID = currentID.replace(PAGE_CONTEXT, "");
            
            if (condition.includes(currentID))
            {
               var ConditionObject= document.getElementById(currentObject.getAttribute("id"));

                var inputType = this.getInputType(currentObject);
                var checkOrRadio = ((inputType == 'RADIO') || (inputType == 'CHECKBOX'));

                if (checkOrRadio && !currentObject.checked)
                    condition = condition.replace(currentID, "0");

                else if (inputType == "TEXT") {
                    if (currentObject.value.length > 0) {
                        condition = replaceALL(condition,currentID, ConditionObject.value);
                       
                    }

                    else
                        condition = condition.replace(currentID, "0");
                }
                else
                    condition = replaceALL(condition, currentID, currentObject.getAttribute("points")); 
            }

        }


        var finalResult = eval(condition);

        if (finalResult)
        {
            if (conditionCheckOrRadio) {
                currentConditionObj.checked = true;
            }
            else {
                currentConditionObj.value = currentConditionObj.getAttribute("points");
            }
        }
        
     }
   


}
function replaceALL(condition,seperator,value)
{
    var conditionSplit = condition.split(" "); 
    for (var i = 0; i <= conditionSplit.length-1; i++)
    {
        if (conditionSplit[i].includes(seperator))
            condition = condition.replace(seperator, value);
    }

    return condition;
}

function getInputType(inputObj) {
    var type = "";
    if (inputObj.tagName == 'INPUT')
        type = inputObj.type.toUpperCase();

    return (type);
}

function containsVaildParametersCondition(inputObj) {
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

        var condition = useObjectForParams.getAttribute("condition");

        if (condition)
            return (true);



    }

    return (false);
}