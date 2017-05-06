// Error Types
var iERROR_TYPE_ERROR = "ERROR";
var iERROR_TYPE_WARNING = "WARNING";
var iERROR_TYPE_INFO = "INFORMATIONAL";
var iERROR_TYPE_QUESTION = "QUESTION";


// definition of AlphaPlusSpecial including French and Spanish special characters
var alphaPlusSpecialStartChar = "A-Za-z:_\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02FF\u00A1\u00BF\u0020\u0022\u002D\u0027";
var alphaPlusSpecialChar = alphaPlusSpecialStartChar + "\\-\\.\u00B7";
var alphaPlusSpecialParams = "^[" + alphaPlusSpecialStartChar + "][" + alphaPlusSpecialChar + "]*$";
var iJSMandatoryValidationMsg = "Mandatory.Validation.Message";
var iValidRequired = "Val.Required"
var iValidMask = "Val.Mask";
var formValidationMasks = new Array();
// Patterns

formValidationMasks['email'] = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$/gi;	// Email
formValidationMasks['serveremail'] = /\b[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b/gi; //Server Sif Email
formValidationMasks['numeric'] = /^[0-9]+$/gi;	// Numeric
formValidationMasks['numericaccount'] = /^[*,0-9]+$/gi; // Numeric account
formValidationMasks['numericIntPosNeg'] = /^[-]?[0-9]+$/gi;	// Numeric
formValidationMasks['numericPosNeg'] = /^[-]?\d+(\.\d{0,2})?$/gi; // Numeric - both positive and negative
formValidationMasks['numericPosNegZeroDecimal'] = /^[-]?[0-9]*$/gi; // numeric values both positive and negative 
formValidationMasks['alpha'] = /^[A-Z]+$/gi;	// Alpha
// formValidationMasks['alphaplusspecial'] = /^[a-zA-Z\''\ \.\-[.]*$/gi; // alphanumeric plus space, quote, fullstop, dash and ampersand.
formValidationMasks['alphaplusspecial'] = alphaPlusSpecialParams;
formValidationMasks['alphanumeric'] = /^[A-Z,a-z,0-9]+$/gi;	// Alphanumeric
formValidationMasks['alphanumericplusspecial'] = /^[a-zA-Z0-9&\''\ \.\-[.]*$/gi; // alphanumeric plus space, quote, fullstop, dash and ampersand.
formValidationMasks['alphanumericplusspecialAndCurrency'] = /^[a-zA-Z0-9&\''\ \.\-[.$£]*$/gi; // alphanumeric plus space, quote, fullstop, dash, ampersand dollar ($) and pound (£).
formValidationMasks['alphanumHashParan'] = /^[a-zA-Z0-9#\\\/\()\ \.\-]*$/gi; //  alphanumeric with special characters parenthesis, slashes, dot, dash, hash and space
formValidationMasks['alphanumhyphenated'] = /^[a-zA-Z0-9\ \'\-]*$/gi; // alphanumeric plus apostrophe, Hyphen, space.
formValidationMasks['zip'] = /^[0-9]{5}\-[0-9]{4}$/gi;	// Numeric
formValidationMasks['postcode'] = /^[A-Za-z]{1,2}[\d]{1,2}([A-Za-z])?\s?[\d][A-Za-z]{2}$/gi; // Postcode
formValidationMasks['postcode.GB'] = /^[A-Za-z]{1,2}[\d]{1,2}([A-Za-z])?\s?[\d][A-Za-z]{2}$/gi; // Postcode
formValidationMasks['postcode.US'] = /^\d{5}([\-]?\d{4})?$/; // Postcode
formValidationMasks['postcode.DE'] = /^\d{5}?$/; // German Postcode http://html5pattern.com/Postal_Codes
formValidationMasks['postcode.AU'] = /^[0-9]{4}/gi; //Australian postcode
formValidationMasks['postcode.CA'] = /^[ABCEGHJKLMNPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ ]?\d[ABCEGHJ-NPRSTV-Z]\d$/gi; // Postcode
formValidationMasks['postcode.ES'] = /^((0[1-9]|5[0-2])|[1-4][0-9])[0-9]{3}$/gi; //Spanish postcode http://html5pattern.com/Postal_Codes
formValidationMasks['postcode.FR'] = /^\d{2}[ ]?\d{3}$/; //French postcode
formValidationMasks['usdate'] = /^([0]?[1-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$/gi; // US Date
formValidationMasks['ukdate'] = /^([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0]?[1-9]|[1][0-2])[.\/-]([0-9]{4}|[0-9]{2})$/gi; // UK Date
formValidationMasks['usdate4'] = /^([0]?[1-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4})$/gi; // US Date 4 year
formValidationMasks['ukdate4'] = /^([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0]?[1-9]|[1][0-2])[.\/-]([0-9]{4})$/gi; // UK Date 4 year
formValidationMasks['time'] = /^([0-1][0-9]|[2][0-3]):([0-5][0-9])$/gi; // Time HH:MM
formValidationMasks['sortcode'] = /^[0-9]{2}$/gi; // Sortcode
formValidationMasks['sortcode1'] = /^\d{2}-\d{2}-\d{2}$/gi; // full sortcode
formValidationMasks['sortcodeGB'] = /^\d{2}-\d{2}-\d{2}$/gi;
formValidationMasks['sortcodeAU'] = /^[0-9]{6}$/gi; // SortcodeAU
formValidationMasks['sortcodeUS'] = /^[0-9]{9}$/gi; // SortcodeUS
formValidationMasks['sortcodeCA'] = /^\d{5}-\d{3}$/gi; // SortcodeCA
formValidationMasks['buildingSocRollNo'] = /^[0-9A-Za-z\&'\*,\.\-\ \()\/]{1,18}$/gi; // buildingSocRollNo (doesnt need sort code) 
formValidationMasks['acctno.GB'] = /^[0-9*]{8}$/gi; // acctno.GB = 8 numerics, but to be consistent with 'cardno' also allow '*' for when it's masked, which DB update then ignores (see Cltact.java).  
formValidationMasks['acctno.US'] = /^[0-9*]{1,17}$/gi; // acctno.US = 1-17 numerics (very open / no standard)
formValidationMasks['acctno.CA'] = /^[0-9*]{1,17}$/gi; // acctno.CA
formValidationMasks['acctno.AU'] = /^[0-9*]{1,17}$/gi; // acctno.AU
formValidationMasks['carddate'] = /^[0-9]{2}$/gi; // Card Dates
formValidationMasks['seccode'] = /^[0-9]{3}$/gi; // Security Code
formValidationMasks['cardno'] = /^([0-9*]{13,19})$/gi; // Credit Card Number
formValidationMasks['cardmnth'] = /^(0[1-9]|1[012])$/gi; // Card Month Date
formValidationMasks['cardyear'] = /^[0-9]{4}$/gi; // Card Year Date
formValidationMasks['phonenum'] = /^[0-9' ']+$/gi; // Phone Number
formValidationMasks['phonenum.GB'] = /^[0-9]{0,5}[ ]{0,1}[0-9]{0,6}$/gi; // GB Phone Number
formValidationMasks['phonenum.US'] = /^\d{3}-\d{3}-\d{4}$/gi; // US Phone Number (999)-999-9999
formValidationMasks['policynum'] = /^[A-Z|0-9]{1}[A-Z|0-9|-]{2}([0-9]{2,9})$/gi; // Policy Number
formValidationMasks['noInitialNumeric'] = /^[A-Za-z][A-Za-z0-9 ''-]*$/gi; // no numeric initial character
formValidationMasks['floatTwoDP'] = /^\d+(?:\.\d{0,2})?$/gi; // float to 2 decimal places
formValidationMasks['floatingPoint'] = /^[0-9]*\.?[0-9]*$/gi;  // float to 2 decimal places
formValidationMasks['currency2DP'] = /^\d+(?:\.\d{0,2})?$/gi;
formValidationMasks['9Digits2DP'] = /^(?=.*[1-9].*$)\d{0,9}(?:\.\d{0,2})?$/gi;
formValidationMasks['1Digit4DP'] = /^\d{1}\.\d{4}$/gi; // numeric x.xxxx - require the full "one digit, decimal point, four digits"
formValidationMasks['SSN.US'] = /^\d{3}-\d{2}-\d{4}$/gi; // Social Security Number
formValidationMasks['SSN.GB'] = /^[A-Z]{2}[0-9]{6}[A-Z]{1}$/g; // National Insurance Number
formValidationMasks['percentage2DP'] = /^(?!^0*$)(?!^0*\.0*$)^\d{1,2}(\.\d{1,2})|(100|100\.0|100\.00)$/gi; // zero to 100 with 2 decimal places - used for percentages
formValidationMasks['percent2Digits2DP'] = /^(\.0{1,2}?)?$|^\d{0,2}(\.\d{1,2})?$/gi; // 00.00 to 99.99 percentage values.
formValidationMasks['percentageDigits'] = /^0?[0-9]?[0-9]$|^(100)?$/gi; // 0 to 100 percentage values with no decimal places.
formValidationMasks['V5DocReferecne.GB'] = /^[0-9]{11,12}$/gi;	// Numeric Exact

var dateMask_ddMMyyyy = /^([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0]?[1-9]|[1][0-2])[.\/-]([0-9]{4}|[0-9]{2})$/gi;
var dateMask_MMddyyyy = /^([0]?[1-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$/gi;
var dateMask_yyyyMMdd = /^(([0-9]{4}|[0-9]{2})[.\/-]([0]?[1-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1]))$/gi

// date validation masks for each country/region
formValidationMasks['CAdate'] = dateMask_ddMMyyyy;
formValidationMasks['CHdate'] = dateMask_ddMMyyyy;
formValidationMasks['DEdate'] = dateMask_ddMMyyyy;
formValidationMasks['ESdate'] = dateMask_ddMMyyyy;
formValidationMasks['FRdate'] = dateMask_ddMMyyyy;
formValidationMasks['GBdate'] = dateMask_ddMMyyyy;
formValidationMasks['NLdate'] = dateMask_ddMMyyyy;
formValidationMasks['PTdate'] = dateMask_ddMMyyyy;
formValidationMasks['SEdate'] = dateMask_yyyyMMdd;
formValidationMasks['USdate'] = dateMask_MMddyyyy;

// the AU mask must be specified in full because this file is read
// and used by the non-JS validation and variables will not be replaced.
// AU is the only region currently supported by the external application
formValidationMasks['AUdate'] = /^([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0]?[1-9]|[1][0-2])[.\/-]([0-9]{4}|[0-9]{2})$/gi;

var formValidatorSet = new Array();

function IValidation(id, isForm) {
    this.isThisForm = isForm;
    this.formValidationObjects = new Array();
    this.toplevelId = id;

    this.initted = false;
    return this;
}

IValidation.prototype.initValidation = function ()
{

    if (this.initted == true)
        return;

    this.initted = true;

    
    var theDiv;
    var idDiv = this.toplevelId;
    if (this.isThisForm)
        theDiv = document.forms[idDiv];
    else
        theDiv = document.getElementById(idDiv);

    this.formValidationObjects = new Array();

    
    // Is the passed div valid??
    if (!theDiv)
        return;

    // remove all button group container objects...relevant while reinitialising
    var arrBtnGrp = new Array();
    var arrInputs = theDiv.getElementsByTagName("INPUT");
    for (var i = 0; i < arrInputs.length; i++) {
        var elemInput = arrInputs[i];
        if (!elemInput)
            continue;
        var typeInput = elemInput.type.toUpperCase();

        var idBtnGrp = elemInput.getAttribute('id');
        if ((typeInput == 'HIDDEN') && idBtnGrp && (idBtnGrp.indexOf('buttonGroup_') == 0)) {
            elemInput.parentNode.removeChild(elemInput);
        }
    }
  
  
    // Get all the components
    var inputFields = theDiv.getElementsByTagName('INPUT');
    var selectBoxes = theDiv.getElementsByTagName('SELECT');
    var textAreas = theDiv.getElementsByTagName('TEXTAREA');

    
    this.initValidationForInputFields(inputFields, idDiv, false);
    this.initValidationForSelectFields(selectBoxes, idDiv, false);
    this.initValidationForTextAreas(textAreas, idDiv, false);
   
}
IValidation.prototype.initValidationForInputFields = function (inputFields, idDiv, bIgnoreSkipValidation)
{

    for (var i = 0; i < inputFields.length; i++)
    {
        // get this input
        var inputObj = inputFields[i];

        // Is it one of our validations
        if (!this.containsValidationParameters(inputObj)) continue;

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

        // If radio then get its parent
        if ((inputType == 'RADIO') || (inputType == 'CHECKBOX'))
        {
            //TODO we to put logic for radio button and check box

            var buttonGroup = document.getElementById('buttonGroup_' + inputObjName);
            if (!buttonGroup || buttonGroup.removed) {
                if (!buttonGroup)
                    buttonGroup = this.createButtonGroupHiddenField(inputObj);

                // Add it to the list
                this.formValidationObjects[this.formValidationObjects.length] = buttonGroup;
                buttonGroup.validator = this;

                buttonGroup.removed = false;

                // Does it validate?
                this.validateInput(false, buttonGroup);
            }
            else
                this.validateInput(false, buttonGroup);

        }
        else
        {
            // Add it to the list
            this.formValidationObjects[this.formValidationObjects.length] = inputObj;
        }

        // Set the handle for later use
        inputObj.validator = this;

        // Does it validate?
        if ((inputType != 'RADIO') && (inputType != 'CHECKBOX'))
            this.validateInput(false, inputObj);

        // Add the action handlers
        if ((inputType == 'RADIO') || (inputType == 'CHECKBOX'))
        {
            inputObj.addEventListener('change', removeManadatoryRadioCheck);
        }
        else
        {
            inputObj.addEventListener('change', removeManadatory);
        }


    }
}
function removeManadatory()
{
    this.className = "form-control";

    var mask = this.getAttribute('imask');
   
    
    if (mask != undefined && mask && !this.value.match(formValidationMasks[mask]))
        {
            
            this.className = "border-color-red form-control";
        }
    
    
}

function removeManadatoryRadioCheck() {
    var name = this.getAttribute('name');
    var arrBtnGrp = document.getElementsByName(name);
    for (var i = 0; i < arrBtnGrp.length; i++) {
        arrBtnGrp[i].className = "";
    }
}

IValidation.prototype.createButtonGroupHiddenField = function (inputObj) {
    var buttonGroup = document.createElement('input');
    buttonGroup.setAttribute('type', 'hidden');
    buttonGroup.setAttribute('id', 'buttonGroup_' + inputObj.name);
    buttonGroup.setAttribute('irequired', inputObj.getAttribute('irequired'));
    buttonGroup.setAttribute('imessage', inputObj.getAttribute('imessage'));

    //	document.body.appendChild (buttonGroup);
    // Modified to fix Operation Abort issue in IE
    inputObj.parentNode.appendChild(buttonGroup);

    return buttonGroup;
}
IValidation.prototype.initValidationForSelectFields = function (selectBoxes, idDiv, bIgnoreSkipValidation)
{
    for (var i = 0; i < selectBoxes.length; i++)
    {
        // get this input
        var selectObj = selectBoxes[i];

        // Is it one of our validations
        if (!this.containsValidationParameters(selectObj))
            continue;

        // Get the name
        var selectObjName = selectObj.id;
        if (!selectObjName)
            continue;

        // Are we to skip validating this??
        if (!bIgnoreSkipValidation )
            continue;

        // Add it to the list
        this.formValidationObjects[this.formValidationObjects.length] = selectObj;

        // Set the handle for later use
        selectObj.validator = this;

        // Does it validate?
        this.validateInput(false, selectObj);
    }
}
IValidation.prototype.initValidationForTextAreas = function (textAreas, idDiv, bIgnoreSkipValidation)
{
    for (var i = 0; i < textAreas.length; i++)
    {
        // get this input
        var textArea = textAreas[i];

        // Is it one of our validations
        if (!this.containsValidationParameters(textArea)) continue;

        // Get the id
        var textAreaName = textArea.getAttribute('id');
        if (!textAreaName)
            continue;

        // Are we to skip validating this??
        if (!bIgnoreSkipValidation && this.skipValidation(idDiv, textArea))
            continue;

        // Add it to the list
        this.formValidationObjects[this.formValidationObjects.length] = textArea;

        // Set the handle for later use
        textArea.validator = this;

        // Does it validate?
        this.validateInput(false, textArea);

    }
}

IValidation.prototype.skipValidation = function (topParentId, thisObj) {
    if (thisObj == null)
        return false;

    var parentObj = thisObj.parentNode;
    // Is the parent object null??
    if (parentObj == null)
        return false;

    // If the parent is an expanding-div then dont skip validation 
    // irrespective of whether it is expanded or contracted.
    // however, if the containing span is hidden, we do want to skip validation
    var parentID = parentObj.id;
    if (parentID && (parentObj.id.indexOf('_xmlAssembledExpDiv') > -1) && parentObj.parentNode.style.display != 'none')
        return false;

    var attrSkipValidate = false;
    try {
        // Some of the parent objects doesnt have this method
        //		if (!attrSkipValidate)
        attrSkipValidate = parentObj.getAttribute('igValidateSkip');
        if (!attrSkipValidate)
            attrSkipValidate = false;
    }
    catch (e) { }
    // If there is an igValidateSlip attribute present and this is not the top level parent then skip validation
    if (attrSkipValidate && (attrSkipValidate == 'true') && (parentObj.id != topParentId))
        return true;
    else  // Skip if the parent is hidden
        if (parentObj.style && (parentObj.style.visibility == 'hidden') && !isTabElement(parentObj))
            return true;
        else
            if (parentObj.style && (parentObj.style.display == 'none') && !isTabElement(parentObj)) {
                // Is it a dhtmlxcombo?
                if (parentObj.className && parentObj.className.indexOf("dhx_combo_box") > -1)
                    return false;

                // Else..
                return true;
            }
            else // Recurse through the parents
                return this.skipValidation(topParentId, parentObj);

    return false;
}

IValidation.prototype.containsValidationParameters = function (inputObj) {
    // If we are a radio or checkbox then ask our parents
    var tagName = inputObj.tagName.toUpperCase();
    var type = this.getInputType(inputObj);

    // Return false for 'hidden' type input controls 
    if (type == 'HIDDEN')
        return false;

    var useObjectForParams = inputObj;

    if (inputObj) {
        var req = useObjectForParams.getAttribute("irequired");
        if (req)
            return (true);

        var opt = useObjectForParams.getAttribute("ioptional");
        if (opt)
            return (true);

        var msk = useObjectForParams.getAttribute("imask");
        if (msk)
            return (true);

        var fre = useObjectForParams.getAttribute("ifreemask");
        if (fre)
            return (true);

        var reg = useObjectForParams.getAttribute("iregexppattern");
        if (reg)
            return (true);
    }

    return (false);
}

IValidation.prototype.getInputType = function (inputObj) {
    var type = "";
    if (inputObj.tagName == 'INPUT')
        type = inputObj.type.toUpperCase();

    return (type);
}

IValidation.prototype.trim = function (str, chars) {
    return (this.ltrim(this.rtrim(str, chars), chars));
}

IValidation.prototype.ltrim = function (str, chars) {
    chars = chars || "\\s";
    return (str.replace(new RegExp("^[" + chars + "]+", "g"), ""));
}

IValidation.prototype.rtrim = function (str, chars) {
    chars = chars || "\\s";
    return (str.replace(new RegExp("[" + chars + "]+$", "g"), ""));
}

IValidation.prototype.isEmpty = function (inputObj, tagName, type)
{
    var ctlEmpty = true;

    // Determine if the control is empty
    if (!inputObj)
        return (ctlEmpty);

    // Else for each type
    if (tagName == 'INPUT')
    {
        // For each input type
        if ((type == 'TEXT') || (type == 'PASSWORD')) {
            //ctlEmpty = (this.trim (inputObj.value).length == 0);

            // Added to support new mask fields (RW)
            var jqMask = inputObj.getAttribute('mask_init');
            var jqPrompt = inputObj.getAttribute('labelprompt');

            if ((jqMask != undefined && jqMask != "") || (jqPrompt != undefined && jqPrompt != "")) {
                if (jqMask == inputObj.value || jqPrompt == inputObj.value)
                    ctlEmpty = true;
                else
                    ctlEmpty = (this.trim(inputObj.value).length == 0);
            }
            else
                ctlEmpty = (this.trim(inputObj.value).length == 0);

        }
        else
            if ((type == 'RADIO') || (type == 'CHECKBOX')) {
                // Determine if the button group has
                // any value...
                var parent = inputObj.parentNode;
                var len = parent.childNodes.length;
                for (var i = 0; i < len; i++) {
                    var radio = parent.childNodes[i];
                    if (radio.checked) {
                        ctlEmpty = false;
                        break;
                    }
                }
            }
            else  // We assume this to be a button group field
                if (type == 'HIDDEN') {
                    // Get all the radio buttons and look for the
                    var idBtnGrp = inputObj.getAttribute('id');
                    if (idBtnGrp && idBtnGrp.indexOf('buttonGroup_') != 0)
                        return ctlEmpty;

                    var sRadioName = idBtnGrp.substring(12);
                    var arrBtnGrp = document.getElementsByName(sRadioName);
                    for (var i = 0; i < arrBtnGrp.length; i++) {
                        var radio = arrBtnGrp[i];
                        if (radio.checked) {
                            ctlEmpty = false;
                            break;
                        }
                    }
                }
    }
    else if (tagName == 'SELECT')
    {
            var selValue = "";

            //if its size greater than 1 then this combo is behaving as list box
            if (inputObj.size > 1) {
                //list box is only empty if we do not have any optiomn in it
                ctlEmpty = inputObj.length == 0;
            }
            else if (inputObj.selectedIndex > -1) {
                selValue = inputObj.options[inputObj.selectedIndex].text;
                ctlEmpty = !((inputObj.selectedIndex >= 0) && (selValue.length > 0));
            }
        }
    else if (tagName == 'TEXTAREA')
    {
       ctlEmpty = (this.trim(inputObj.value).length == 0);
    }

    return (ctlEmpty);
}
function iFormIsValid(formValidator) {
    var ret = true;

    if (formValidator) {
        
        // Check that the form validates OK....
        ret = formValidator.isFormValid(true);
    }

    return (ret);
}



IValidation.prototype.isFormValid = function (bShowMessage) {
    //var allMsgs = "Please ensure that all required\nfields have been entered correctly.\n";
    var allMsgs = iJSMandatoryValidationMsg;
    var overallSuccess = true;

    // If no flag then set it
    if (typeof bShowMessage == 'undefined')
        bShowMessage = true;

    for (var i = 0; i < this.formValidationObjects.length; i++) {
        var inputObj = this.formValidationObjects[i];

        // get the disabled state of the component
        var disabled = inputObj.disabled;
        // don't validate disabled components
        if (disabled == true)
            continue;

        var tagName = inputObj.tagName.toUpperCase();
        var type = inputObj.validator.getInputType(inputObj);

        if (tagName == "INPUT" && type == "HIDDEN") {
            // This is likely to be a button group
            if (inputObj.id.indexOf("buttonGroup_") == 0) {
                // Strip off the button group bit
                var bgDiv = inputObj.id.substring(12);
                var parDiv = document.getElementById(bgDiv);
                if (parDiv) {
                    if (parDiv.tagName == "INPUT") {
                        // Looks like the little tinkers have done the layout themselves
                        // and added a bunch of radio buttons to their own <TD>, say, so
                        // we adjust the parent
                        if (parDiv.parentNode)
                            parDiv = parDiv.parentNode;
                    }

                    // Set as false...
                    inputObj.validates = false;

                    // Get all children of type
                    var objChildren = parDiv.getElementsByTagName("INPUT");
                    for (var iC = 0; iC < objChildren.length; iC++) {
                        if (this.getInputType(objChildren[iC]) == "RADIO") {
                            if (objChildren[iC].getAttribute("igrequired") == "1") {
                                // Get the value
                                var radVal = objChildren[iC].checked;
                                if (radVal == true) {
                                    // Set as validates
                                    inputObj.validates = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Could this be a html-select converted into dhtml-combo??
        if ((tagName == 'SELECT') && (inputObj.style && (inputObj.style.display == 'none'))) {
            // Check whether there is a textfield with the same id
            var objInput = document.getElementById(inputObj.id);
            if (objInput && (objInput != inputObj))
                inputObj = objInput;
        }

        var userObject = inputObj;

        // Has it validated alright?? 
        var bValidates = userObject.validates;
        if (!bValidates) {
            overallSuccess = false;
            // Get the error messages
            var validationMsg = inputObj.getAttribute("imessage");
            var reasonMessage = "";

            
            if (inputObj.id.indexOf("buttonGroup_") == 0 &&  type == "HIDDEN")
            {
                var sRadioName = inputObj.id.substring(12);
                var arrBtnGrp = document.getElementsByName(sRadioName);
                //arrBtnGrp.className = "radio-required";
                for (var irequiredcounter = 0; irequiredcounter < arrBtnGrp.length; irequiredcounter++) {
                    arrBtnGrp[irequiredcounter].className = "radio-required";
                }
            }
            else
                inputObj.className = "border-color-red form-control";
            // get any failure reasons
            if (inputObj.reasonArray) {
                for (var iReason = 0 ; iReason < inputObj.reasonArray.length ; iReason++) {
                    reasonMessage = reasonMessage + inputObj.reasonArray[iReason];
                    if (iReason != inputObj.reasonArray.length - 1)
                        reasonMessage = reasonMessage + " ; ";
                };
            }
            if (validationMsg) {
                allMsgs = allMsgs + "<br/>" + validationMsg;
                if (reasonMessage.length > 0)
                    allMsgs = allMsgs + " - " + reasonMessage;
            }
        }
        else {
            inputObj.className = "form-control";
        }
    }

    // Set the value in the array
    formValidatorSet[this.toplevelId] = overallSuccess;

    if (bShowMessage) {
        if (!overallSuccess) {
            //alert (allMsgs);
            iShowWarningMessage(allMsgs);
        }
        else {
            // Hide the message as all seems OK
            iHideMessage();
        }
    }

    return overallSuccess;
}

IValidation.prototype.validateInput = function (e, inputObj) {
    if (!inputObj)
        inputObj = this;
    var inputValidates = true;

    var name = inputObj.getAttribute("id");
    if (!name)
        name = inputObj.id;
    if (!name)
        name = inputObj.name;

    var tagName = inputObj.tagName.toUpperCase();
    if (!inputObj.validator)
        return;
    var type = inputObj.validator.getInputType(inputObj);

    var useObjectForParams = inputObj;
    // Is this a radio button or checkbox
    if ((tagName == 'INPUT') && ((type == 'RADIO') || (type == 'CHECKBOX'))) {
        name = inputObj.name;
        useObjectForParams = document.getElementById('buttonGroup_' + name);
    }

    if (useObjectForParams) {
        var required = useObjectForParams.getAttribute("irequired");
        if (!required)
            required = inputObj.required;

        var optional = useObjectForParams.getAttribute("ioptional");
        if (!optional)
            optional = inputObj.optional;

        var mask = useObjectForParams.getAttribute("imask");
        if (!mask)
            mask = inputObj.mask;

        // Set time format if mask of time - SA-DEF-1190
        if (mask == 'time') {
            // only do if 4 digits and no : already
            if ((inputObj.value.length == 4 && inputObj.value.search(":") == -1)) {
                var val1 = inputObj.value.substring(0, 1);
                var val2 = inputObj.value.substring(1, 2);
                var val3 = inputObj.value.substring(2, 3);
                var val4 = inputObj.value.substring(3, 4);

                // Only do if all 4 digits are numerics
                if (!isNaN(val1) && !isNaN(val2) && !isNaN(val3) && !isNaN(val4))
                    inputObj.value = val1 + val2 + ':' + val3 + val4;

            }
        }

        var freemask = useObjectForParams.getAttribute("ifreemask");
        if (!freemask || freemask == "null")
            freemask = inputObj.freemask;

        var regexpPattern = useObjectForParams.getAttribute("iregexppattern");
        if (!regexpPattern || regexpPattern == "null")
            regexpPattern = inputObj.regexpPattern;
    }

    var empty = inputObj.validator.isEmpty(inputObj, tagName, type);

    // If optional but we have length then actually we need to make
    // sure that the validation mask is valid!
    if (optional && !empty)
        required = "1";

    // create an array to contain any validation failure reasons.
    // this will be added to the object at the end of this function
    // if validation fails
    var reasonArray = new Array();

    if (required && empty) {
        inputValidates = false;
        reasonArray.push(iValidRequired);
    }


    var inputValue = inputObj.value;

    // Added to support new mask fields (RW)
    if ((tagName == 'INPUT') && ((type == 'TEXT') || (type == 'TEXTAREA'))) {
        var jqMask = inputObj.getAttribute('mask_init');
        var jqPrompt = inputObj.getAttribute('labelprompt');

        if ((jqMask != undefined && jqMask != "") || (jqPrompt != undefined && jqPrompt != "")) {
            if (jqMask == inputObj.value || jqPrompt == inputObj.value)
                inputValue = "";
        }
    }

    

    if (freemask) {
        var tmpMask = freemask;
        tmpMask = tmpMask.replace(/-/g, '\\-');
        tmpMask = tmpMask.replace(/S/g, '[A-Z]');
        tmpMask = tmpMask.replace(/N/g, '[0-9]');
        tmpMask = eval("/^" + tmpMask + "$/gi");
        if (!inputObj.value.match(tmpMask)) {
            inputValidates = false
            reasonArray.push(iValidMask);
        }
    }

    if (regexpPattern) {
        var tmpMask = eval(regexpPattern);
        if (!inputObj.value.match(tmpMask)) {
            inputValidates = false;
            reasonArray.push(iValidMask);
        }
    }

    if (!required && (inputValue.length == 0) && ((tagName == 'INPUT') || (tagName == 'TEXTAREA')))
        inputValidates = true;

    if (useObjectForParams) {
        // Set the 'validates' flag
        useObjectForParams.validates = inputValidates;
        if ((tagName != 'INPUT') && required && empty)
            useObjectForParams.validates = false;
    }

    // Finally set the style for the validator object
  /*  if ((tagName != 'INPUT') && (tagName != 'DIV')) // combobox
    {
        if (required && empty)
            inputObj.validator.updateMandatoryIndicator(inputObj, true);
        else
            inputObj.validator.updateMandatoryIndicator(inputObj, false);
    }
    else // input type
    {
        if (inputValidates)
            inputObj.validator.updateMandatoryIndicator(inputObj, false);
        else
            inputObj.validator.updateMandatoryIndicator(inputObj, true);
    }

    inputObj.validator.updatePageValidationIndicator(inputObj.id);

    if (useObjectForParams) {
        // Call the function
        var regexpCallback = useObjectForParams.getAttribute("igregexpcallback");
        if (typeof (regexpCallback) == "string") {
            // Callback if the mask validates
            var regexCallbackValidates = false;
            if ((inputValidates == true) && (!empty) && (mask != undefined || freemask != undefined || regexpPattern != undefined))
                regexCallbackValidates = true;

            // Call the function
            try {
                // Build the call
                var toCall = regexpCallback + " ('" + name + "', " + regexCallbackValidates + ");";
                eval(toCall);
            }
            catch (e) {
                alert(e);
            }
        }
    }*/

    // add the reasons array if validation failed
    if (!inputValidates)
        inputObj.reasonArray = reasonArray;

    return (inputValidates);
}

IValidation.prototype.updateMandatoryIndicator = function (inputObj, bShow) {
    
}




/**
 *  Function raises a warning message to the user utilising the User Interact section of the page.
 *
 *  @param {String} text The message text to display
 */
function iShowWarningMessage(text) {
    igShowMessage(iERROR_TYPE_WARNING, text, false);
}

/**
 *  Function raises an error message to the user utilising the User Interact section of the page.
 *
 *  @param {String} text The message text to display
 */
function igShowErrorMessage(text) {
    igShowMessage(iERROR_TYPE_ERROR, text, false);
}



/**
 *  This function should only be called internally by other JS functions
 * it is designed to display a message utilising the standard error panel
 * and will only work where the interact prelude is included on a frame.
 *
 *  @param {String} type One of iERROR_TYPE_ERROR, iERROR_TYPE_WARNING or iERROR_TYPE_INFO
 *  @param {String} text The text to display to the user.
 */
function igShowMessage(type, text) {
    var aePanel = document.getElementById("iErrorPanel");
    if (!aePanel) return;

    var panelClass = "close";
  // // if (type == iERROR_TYPE_INFO)
 //       panelClass = "igInfoPanel";
 //   else
  //      panelClass = "close";

    aePanel.className = panelClass;

    var errorLabel = assembleErrorLabel(type, text, 'Label');
    if (errorLabel == null || errorLabel.length == 0) return;

  

    aePanel.innerHTML = errorLabel;
    // Show the panel
    aePanel.style.display = "block";

    // Scroll the panel into view
    try {
        // Ensure that the error panel is visible
        if (!($.browser.msie && $.browser.version == 10)) //D-15944 Causing The Frame to slide left in IE10 Compaitibility mode off
            aePanel.scrollIntoView(false);

        // call the function to reposition any footer div
        (function ($) { $().positionFooter(); })(jQuery);
    }
    catch (e) {
        // Don't care about errors (cross browser)
    }
}

/**
 *  Function is used to hide any messages that have been displayed to the user using the igShowMessage function.
 */
function iHideMessage(divName) {
    if (typeof (divName) == "undefined")
        divName = "igErrorPanel";

    var aePanel = document.getElementById(divName);
    if (!aePanel) return;

    aePanel.style.display = "none";
}

/**
 * Framework-internal function. This function is used by igShowMessage and igShowAjaxActionErrors
 * to construct an HTML label to display messages to the user.
 *
 *  @param {String} type One of igERROR_TYPE_ERROR, igERROR_TYPE_WARNING or igERROR_TYPE_INFO
 *  @param {String} text The text to display to the user.
 *  @param {String} classType A string that is appended onto a type-code to construct the css classname of the label. 
 *  @return The constructed HTML.
 *  @type String
 */
function assembleErrorLabel(type, text, classType) {
    var errorLabel = "";
    if (text == null || text.length == 0) return errorLabel;

    if (type == null || type.length == 0)
        type = igERROR_TYPE_ERROR;

    var labelClass = "center";
   /* if (type == igERROR_TYPE_ERROR)
        labelClass = "igError" + classType;
    else if (type == igERROR_TYPE_WARNING)
        labelClass = "igWarning" + classType;
    else if (type == igERROR_TYPE_INFO)
        labelClass = "igInfo" + classType;
    else
        labelClass = "igError" + classType;*/

    var errorLabel = "<label class='" + labelClass + "'>" + text + "</label>";

    return errorLabel;
}

