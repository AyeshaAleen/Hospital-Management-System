function iFillControl(id, fillValue)
{

    try
    {
        var obj = id;
        if (typeof (id) == "string")
        {
            obj = document.getElementById(id);
            // Could this be a radio button in FireFox??
            if (!obj && !document.all) {
                var arrObj = document.getElementsByName(id);
                if (arrObj && (arrObj.length > 0))
                    obj = arrObj[0];
            }
        }

        if (obj != undefined && obj != null && fillValue != undefined && fillValue != null)
        {
            // Get the value
            var tagName = obj.tagName;
            if (tagName)
            {
                var callActionObj = obj;
                var tagNameU = tagName.toUpperCase();
                // Have we set the value
                var sCallFunction = "";
                if (tagNameU == "INPUT")
                {
                    // Get the type
                    var type = obj.getAttribute("type");//obj.type;
                    if (type)
                    {
                        // replace any &nbsp; to space
                       // fillValue = fillValue.replace(/&nbsp;/g, ' ').trim();
                      //  fillValue = fillValue.replace(/&amp;/g, '&').trim();
                        var typeU = type.toUpperCase ();
                        if (typeU == "TEXT" || typeU == "HIDDEN")
                        {
                            // Set the value
                            obj.value = fillValue;
                            sCallFunction = "onchange";
                        }
                        else if (typeU == "CHECKBOX" || typeU == "RADIO")
                        {

                            if (fillValue == "true" || fillValue == "1" || fillValue == "y" || fillValue == "Y" || fillValue == true)
                                obj.checked = true;
                            else
                                obj.checked = false;

                            sCallFunction = "onclick";
                            callActionObj = obj;
                            // Get the name
                            //var objName = obj.name;
                            //if (objName)
                            //{
                            //    // Get each of the elements with this name
                            //    var objArray = document.getElementsByName(objName);
                            //    for (var i = 0; i < objArray.length; i++)
                            //    {
                            //        // Get the object
                            //        var objVal = objArray[i].value;
                            //        // Does it match?
                            //        var bValueMatch = (objVal == fillValue);
                            //        // Has the value changed??
                            //        var prevState = objArray[i].checked;
                            //        var currValue = (fillValue.length > 0);
                            //        var bValueChanged = (prevState != currValue);
                            //        objArray[i].checked = bValueMatch;
                            //        // Do we need to call the attached event??
                            //        var bCallEvent = (((typeU == "RADIO") && bValueMatch)
							//						|| ((typeU == "CHECKBOX") && bValueChanged));
                            //        if (bCallEvent)
                            //        {
                            //            // Is there any event attached?? and is enabled??
							//			if (objArray[i].onclick && !objArray[i].disabled)
							//			{
							//				sCallFunction = "onclick";
							//				callActionObj = objArray[i];
							//			}
                            //        }
                            //    }
                            //}
                        }
                       

                        // If we have set the value call the onChange handler
                        if (sCallFunction.length > 0) {
                            //obj.fireEvent (sCallFunction, newEvt);
                            fireBrowserEvent(callActionObj, sCallFunction);
                        }
                    }
                    
                }
                else if (tagNameU == 'SELECT') {
                    // replace any &nbsp; to space
                    
                    // Set the selected combo
                    setSelectedComboValue(obj, fillValue);
                    sCallFunction = "onchange";
                }
                else if (tagNameU == 'LABEL') {
                    // Set the selected label
                    obj.innerHTML = fillValue;
                }
                else if (tagNameU == 'TEXTAREA') {
                    // Set the selected label

                    obj.value = fillValue;
                    sCallFunction = "onchange";
                }
                else {
                    alert("Undefined igFillControl setter for : " + tagNameU);
                }
            }
            else {
                setSelectedComboValue(obj, fillValue);
            }
        }
    }
    catch (e)
    {
        alert("Error in igFillControl : " + e);
    }
}

function fireBrowserEvent(control, eventType) {
    jQuery(control).trigger(eventType);
}

function setSelectedComboValue(obj, fillValue)
{
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }

    for (var i = 0, n = obj.options.length; i < n ; i++) {
        if (obj.options[i].value == fillValue) {
            obj.selectedIndex = i;
            break;
        }
    }
}

function setSelectedComboText(obj, fillValue) {
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }

    for (var i = 0, n = obj.options.length; i < n ; i++) {
        if (obj.options[i].text == fillValue) {
            obj.selectedIndex = i;
            break;
        }
    }
}

function iGetControlValue(id)
{
    var retVal;
    try
    {
        // Get the control itself, can be passed as either the control
        // or as the ID of the object
        var obj = id;
        if (typeof (id) == "string") {
            obj = document.getElementById(id);

            // Could this be a radio button in FireFox??
            if (!obj && !document.all) {
                var arrObj = document.getElementsByName(id);
                if (arrObj && (arrObj.length > 0))
                    obj = arrObj[0];
            }
        }
        //var obj = document.getElementById (id);
        if (obj != undefined && obj != null)
        {
            // Get the value
            var tagName = obj.tagName;
            if (tagName)
            {
                var tagNameU = tagName.toUpperCase();
                if (tagNameU == "INPUT")
                {
                    var type = obj.getAttribute("type");//obj.type;
                   

                    if (type)
                    {
                        var typeU = type.toUpperCase();
                        if (typeU == "TEXT" || typeU == "HIDDEN")
                        {
                            retVal = obj.value;
                        }
                        else if (typeU == "CHECKBOX" || typeU == "RADIO")
                        {
                            if (obj.checked == true)
                                retVal = true;
                            else
                                retVal = false;
                            // Get the name
                            //var objName = obj.name;
                            //if (objName)
                            //{
                            //    // Get each of the elements with this name
                            //    var objArray = document.getElementsByName(objName);
                            //    for (i = 0; i < objArray.length; i++)
                            //    {
                            //        // Get the object
                            //        if (objArray[i].checked)
                            //            retVal = objArray[i].value;
                            //    }
                            //}
                        }
                       
                    }
                }
                else if (tagNameU == 'SELECT')
                {
                    var ismultiselect = obj.getAttribute("ismultiselect");//obj.type;
                     // Set the selected combo
                    if (ismultiselect)
                    retVal = getMultiSelectComboValue(obj);
                    else
                    retVal = getComboValue(obj);
                }
                else if (tagNameU == 'TEXTAREA')
                {
                    retVal = obj.value;
                }
            }
        }
    }
    catch (e)
    {
        alert("Error in igGetControlValue : " + e);
    }

    return retVal;
}
function iGetObject(obj) {
    
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }

    return obj;
}
function iGetAttribute(obj,attribute)
{
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }
    if (obj.getAttribute(attribute))
        return obj.getAttribute(attribute);
    else
        return "";
}
function iSetAttribute(obj,attribute,value)
{
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }
    
    obj.setAttribute(attribute,value);
    
}
function getComboValue(obj)
{
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }

    return obj.options[obj.selectedIndex].value;
}

function getMultiSelectComboValue(obj) {
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }
    var result="";
    for (var i = 0; i < obj.options.length; i++) {
        if (obj.options[i].selected == true) {
            if (result != "")
                result += " "+ obj.options[i].value;
            else
                result = obj.options[i].value;
        }
    }
    return result;
}

function getComboText(obj) {
    if (typeof (obj) == "string") {
        obj = document.getElementById(obj);
    }
    if (obj)
        return obj.options[obj.selectedIndex].text;
    else
        return "";
}

function iIsValueEmpty(value) {
    var ret = true;
    if (value) {
        var tempValue = value.trim();
        if (tempValue.length > 0)
            ret = false;
    }

    return ret;
}

function iDisableControl(id,bool) {
    
    iGetObject(id).disabled = bool;
}

function iClearControl(id) {
    // Clear down the control
    igFillControl(id, "");
}