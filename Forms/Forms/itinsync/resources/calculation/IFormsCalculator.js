var formValidationMasks = new Array();
var FORMS_CALCULATION_PLUS= "PLUS";
var FORMS_CALCULATION_MINUS= "MINUS";
var FORMS_CALCULATION_MULTIPLY= "MULTIPLY";
var FORMS_CALCULATION_DIVIDE= "DIVIDE";
var FORMS_CONTROL_PERCENTAGE = "PERCENTAGE ";
var FORMS_CONTROL_AVERAGE = "AVERAGE";
var PAGE_CONTEXT = "CommonMasterBody_FormMasterBody_";

function calculation  ()
{
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

function initInputFields(inputFields, idDiv, bIgnoreSkipValidation)
{

    for (var i = 0; i < inputFields.length; i++)
    {
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

        if (checkOrRadio && !inputObj.checked)
        {
            continue;
        }
        if (inputObj.getAttribute("status") == 0)
            continue;

        // do calculation

        var points      = inputObj.getAttribute("points");
        var resultantID = inputObj.getAttribute("resultantID");
        var operation = inputObj.getAttribute("operation");
        var fieldCount = inputObj.getAttribute("fieldCount");

        if (!points || !resultantID || !operation)
            continue;

        this.doOperation(points, resultantID, operation);

        //marked this field as done 
        inputObj.setAttribute("status","0");

    }


}

function doOperation(value, resultantID, operation)
{
    var resultantObject = document.getElementById(PAGE_CONTEXT + resultantID);
    var fieldCount = resultantObject.getAttribute("fieldCount");
    var resultantValue  = resultantObject.value;

    if(!fieldCount)
        fieldCount = 0;

    if (operation == FORMS_CALCULATION_PLUS)
    {
        
        resultantObject.value = parseFloat(resultantValue) + parseFloat(value);
    }
    
    else if (operation == FORMS_CALCULATION_MINUS)
    {
        resultantObject.value = parseFloat(resultantValue) - parseFloat(value);
    }
    else if (operation == FORMS_CALCULATION_MULTIPLY)
    {
        resultantObject.value = parseFloat(resultantValue) * parseFloat(value);
    }
    else if (operation == FORMS_CALCULATION_DIVIDE)
    {
        resultantObject.value = parseFloat(resultantValue) / parseFloat(value);
    }
    else if (operation == FORMS_CONTROL_AVERAGE)
    {
        var totalfield = document.getElementById("hiddenTotal" + resultantID);
        if (totalfield == null || totalfield == undefined)
            totalfield = createHiddenField("hiddenTotal" + resultantID);

        totalfield.value = parseFloat(totalfield.value) + parseFloat(value);


        fieldCount++;
        resultantObject.value = totalfield.value / fieldCount;
        resultantObject.setAttribute("fieldCount", fieldCount);
    }
}
function createHiddenField(totalID)
{
    var x = document.createElement("INPUT");
    x.setAttribute("type", "hidden");
    x.setAttribute("id", totalID);
    x.setAttribute("value", 0);
    return x;
}
function getInputType  (inputObj) {
    var type = "";
    if (inputObj.tagName == 'INPUT')
        type = inputObj.type.toUpperCase();

    return (type);
}

function containsVaildParameters  (inputObj) {
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

    }

    return (false);
}