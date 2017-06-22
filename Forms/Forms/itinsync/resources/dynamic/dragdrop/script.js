/*jslint white: true, browser: true, undef: true, nomen: true, eqeqeq: true, plusplus: false, bitwise: true, regexp: true, strict: true, newcap: true, immed: true, maxerr: 14 */
/*global window: false, REDIPS: true */
/* Version 1.0.0 */


/* enable strict mode */
"use strict";

// define redips object container
var redips = {};
var FORM_NAME = "";
var CONTROL_COUINT = 0;
var CURRENTPAGE_CONTEXT = "CommonMasterBody_DynamicFormMasterBody_";
var SECTIONID = 0;
// configuration
redips.configuration = function () {
    redips.components = 'tblComponents';// left table id (table containing components)
    redips.tableEditor = 'tblEditor';	// right table id (table editor)
    redips.tableEditorDivs = document.getElementById(redips.tableEditor).getElementsByTagName('DIV');	// live collection of DIV elements inside table editor
    redips.ajaxField = 'http://forms.itinsync.com/php/db_field.php';//'db_field.php';	// get component details (via AJAX)
    redips.ajaxSave = 'http://forms.itinsync.com/php/db_save.php';//'db_save.php';	// save page (via AJAX)
    redips.cDetails = 'cDetails';		// component detail class name (it should be the same as is in CSS file)
    redips.markedColor = '#A9C2EA';		// marked cells background color
    // layout (HTML code) for component placed to the table editor 
    //redips.component = '<div class="redips-layout cHeader"><span class="hLeft" onclick="redips.details(this)">+</span><span class="hTitle">|</span><span class="hRight" onclick="redips.divDelete(this)">x</span>' + '<div class="' + redips.cDetails + '">|</div>';

  //  redips.component = "<a href=\"#\" data-toggle=\"popover\" onclick=\"AddDetail()\" title=\"Popover Header\" data-content=\"Some content inside the popover\">Toggle popover</a>";
        //< button onclick=\"getpopover(this)\" type=\"button\" id=\"bulk_actions_btnsss\" class=\"btn btn-default has-spinner-two\" data-toggle=\"popover\" data-placement=\"bottom\" data-original-title=\"\" data-content=\"wwwwwwwwwwClick any question mark icon to get help and tips with specific tasks\" aria-describedby=\"popover335446789\"> Apply</button>| <span class=\"hRight\" onclick=\"deleteColumn(this)\">x</span>";
   
    redips.component = '<a href="#con-modal" class="hLeft" onclick="AddDetail()">+</a>|<span class="hRight" onclick="deleteColumn(this)">x</span>';

   
    
};


// initialization
redips.init = function () {
    // define reference to the REDIPS.drag and REDIPS.table object
    var rt = REDIPS.table,
        rd = REDIPS.drag;
    // configuration
    redips.configuration();
    // attach onmousedown event handler to tblEditor
    rt.onmousedown(redips.tableEditor, true);
    // selected cell background color
    rt.color.cell = redips.markedColor;
    // disable marking not empty table cells
    rt.mark_nonempty = false;
    // initialize REDIPS.drag library
    rd.init();
    // set drop mode as "single" - DIV element can be dropped only to the empty cells
    rd.dropMode = 'single';
    // event handler invoked on click on DIV element
    rd.event.clicked = function () {
        //debugger;
        var div,	// DIV element reference
            i;		// loop variable
        // loop goes through all DIV elements inside table editor
        for (i = 0; i < redips.tableEditorDivs.length; i++) {
            // set reference to the DIV element
            div = redips.tableEditorDivs[i];
            // if DIV element contains class name of component details then hide
            if (div.className.indexOf(redips.cDetails) > -1) {
                //$('#con-close-modal').modal('show');
                redips.details(div, 'hide');
            }

        }
        // document.getElementById("tblEditor").addEventListener("click", detailWindow);
    };

    // event handler invoked before DIV element is dropped to the table cell
    rd.event.droppedBefore = function (targetCell) {

        // set new width to the dropped DIV element
        var width = targetCell.offsetWidth;
        // set width and reset height value
        //rd.obj.style.width = (width - 2) + 'px';
        rd.obj.style.height = '';
    };
    // event handler invoked in a moment when DIV element is dropped to the table
    rd.event.dropped = function (targetCell) {
        var st,		// source table
            id;		// DIV id
        // deselect target cell id needed
        //$('#con-close-modal').modal('show');
        rt.mark(false, targetCell);
        // define source table
        st = rd.findParent('TABLE', rd.td.source);
        // if source table is table editor then expand DIV element
        if (redips.components === st.id) {
            // define id of dropped DIV element (only first three characters because cloned element will have addition in id)
            id = rd.obj.id.substring(0, 3);


            //			rd.obj.style.borderColor = 'white';
            // send AJAX request (input parameter is field id)
            // div property is reference to the object where AJAX output will be displayed (inside dropped DIV element) 
            rd.ajaxCall(redips.ajaxField + '?id=' + id, redips.handler1, { div: rd.obj });

        }

    };

};


// AJAX handler - display response from redips.ajaxField in div.innerHTML
// callback method is called with XHR and obj object (obj is just passed from ajaxCall to this callback function)
// error handling is wrapped inside callback function
redips.handler1 = function (xhr, obj) {
    debugger;
    // prepare title and layout local variables
    var title,
        layout;
    // if status is OK
    if (xhr.status === 200) {
        // prepare title and layout
        title = obj.div.innerHTML;
        layout = redips.component.split('|');

      
        // set layout and title inside dropped DIV element
        obj.div.innerHTML = xhr.responseText + layout[1];


        //obj.div.innerHTML = layout[0] + layout[1] + xhr.responseText + layout[2];

        //obj.div.innerHTML = xhr.responseText;

       


        var eleminput = obj.div.getElementsByTagName("input");
        var elemlabel = obj.div.getElementsByTagName("label");
        var elemselect = obj.div.getElementsByTagName("select");
        var elemtextarea = obj.div.getElementsByTagName("textarea");
        var elemheading = obj.div.getElementsByTagName("h4");
        var controlID = "";
        if (eleminput.length > 0)
            controlID = fieldset(eleminput, obj.div.id);
        if (elemlabel.length > 0)
            controlID=   fieldset(elemlabel, obj.div.id);
        if (elemtextarea.length > 0)
            controlID = fieldset(elemtextarea, obj.div.id);
        if (elemheading.length > 0)
            controlID= fieldset(elemheading, obj.div.id);
        if (elemselect.length > 0)
            controlID = fieldset(elemselect, obj.div.id);

        var popupHTML = layout[0];
        var params = "AddDetail('" + controlID + "')";
        popupHTML = popupHTML.replace("AddDetail()", params);

        obj.div.innerHTML = obj.div.innerHTML.replace("##_ID##", controlID);

        

        obj.div.innerHTML = popupHTML + obj.div.innerHTML;

    }
    // otherwise display error inside DIV element
    else {
        obj.div.innerHTML = 'Error: [' + xhr.status + '] ' + xhr.statusText;
    }
};

function deleteColumn(elem) {
    
    var divelement = $(elem).parent().remove();
}


function setTranslation() {


    var input = $("#defaultValue").val();
    var output = input.split(" ").join('.');
    $("#translation").val(output);
  
    
}


function AddDetail(id) {

    debugger;

   
    //alert(jQuery("#ddlControlID"));
    $("#ddlControlID").children().remove().end().append('<option selected value="">Select</option>');

    $('#tblEditor').find('td input').each(function () {

        $("#ddlControlID").append($("<option id='opt'></option>").val($(this).attr('id')).html($(this).attr('id')));

      
        
    });
    

    if (document.getElementById(id).getAttribute("type") == "label" || document.getElementById(id).getAttribute("type") == "heading") {
        document.getElementById("points").disabled = true;
        document.getElementById(CURRENTPAGE_CONTEXT+"ddlOperation").disabled = true;
        document.getElementById("ddlControlID").disabled = true;
    }

    else
    {
        document.getElementById("points").disabled = false;
        document.getElementById(CURRENTPAGE_CONTEXT+"ddlOperation").disabled = false;
        document.getElementById("ddlControlID").disabled = false;
    }
    if (document.getElementById(id).getAttribute("type") == "radio") {
        document.getElementById("ControlName").disabled = false;
    }
    else
        document.getElementById("ControlName").disabled = true;

    //this is required object which contain all information regarding object
    var fieldObject = document.getElementById(id);

    // getting data from popup and setting it to required field
    debugger;
    //if (fieldObject.getAttribute("resultantid") != "")
        document.getElementById("PreviousControlID").value = fieldObject.getAttribute("resultantid");

    //document.getElementById("ddlControlID").value = fieldObject.getAttribute("resultantid");

    document.getElementById("ControlName").value = fieldObject.getAttribute("name");;
    document.getElementById("ControlID").value = id;
    document.getElementById("cssClass").value = fieldObject.getAttribute("cssClass");
    document.getElementById("translation").value = fieldObject.getAttribute("translation");
    document.getElementById("points").value = fieldObject.getAttribute("points");
    document.getElementById("defaultValue").value = fieldObject.getAttribute("defaultValue");
    if (fieldObject.getAttribute("irequired") == "true")
        document.getElementById("isRequired").checked = true;
    else
        document.getElementById("isRequired").checked = false;
    debugger;
    document.getElementById("txtformula").value = fieldObject.getAttribute("formula");
    
    $('#con-close-modal').modal('show');
}
function SetDetail() {
    debugger;
      var  id = document.getElementById("ControlID").value;

      $("#" + id).parent().addClass('redips-drag-field-highlight').removeClass('redips-drag');

    document.getElementById(id).setAttribute("id", document.getElementById("ControlID").value);
    document.getElementById(id).setAttribute("name", document.getElementById("ControlName").value);
    document.getElementById(id).setAttribute("Class", document.getElementById("cssClass").value);
    document.getElementById(id).setAttribute("translation", document.getElementById("translation").value);
    if ($("#isReadonly").is(':checked')) {
        document.getElementById(id).setAttribute("disabled", "disabled");
    }
    else
    {
        document.getElementById(id).removeAttribute("disabled", "");
    }
    if (document.getElementById(id).getAttribute("type") != "label")
    {
       

        document.getElementById(id).setAttribute("points", document.getElementById("points").value);
        document.getElementById(id).setAttribute("Operation", $("#" +CURRENTPAGE_CONTEXT+"ddlOperation option:selected").text());
        document.getElementById(id).setAttribute("resultantid", $("#ddlControlID option:selected").text());
        document.getElementById(id).setAttribute("irequired", document.getElementById("isRequired").checked);
    }
    

    document.getElementById(id).setAttribute("formula", document.getElementById("txtformula").value);
    document.getElementById(id).setAttribute("defaultValue", document.getElementById("defaultValue").value);
    document.getElementById(id).setAttribute("LookupName", $("#" +CURRENTPAGE_CONTEXT+"ddlLookupName option:selected").text());
    document.getElementById(id).setAttribute("imask", $("#" +CURRENTPAGE_CONTEXT+"ddlMask option:selected").text());
  
    
    if (document.getElementById(id).getAttribute("type") == "label" || document.getElementById(id).getAttribute("type") == "heading" )
        document.getElementById(id).innerHTML = document.getElementById("defaultValue").value;

    
    $('#con-close-modal').modal('hide');
}

function setOperationField(id)
{
    //debugger;
    //var formula = id;
    //$('#tblOperationDetail').find('tr').each(function () {
    //    $(this).find('td').each(function () {

    //        if ($(this).html() == "MULTIPLY")
    //            formula +="* ";
    //        else if ($(this).html() == "PLUS")
    //            formula += "+ ";
    //        else if ($(this).html() == "MINUS")
    //            formula += "- ";
    //        else if ($(this).html() == "DIVIDE")
    //            formula += "/ ";
    //        else if ($(this).html() == "PERCENTAGE")
    //            formula += "% ";

    //        else
    //    formula += $(this).html();

    //        document.getElementById("txtformula").value = formula;

    //});
    //});
}

function AddOperationDetail() {
    debugger;

    var operation = $("#" +CURRENTPAGE_CONTEXT+"ddlOperation option:selected").text();
    var ControlID = $("#ddlControlID option:selected").text();

    var formula = document.getElementById("txtformula").value;

    if (formula == "")
        formula = document.getElementById("ControlID").value;

    
    if (operation.toUpperCase() == "MULTIPLY")
        formula += "* ";
    else if (operation.toUpperCase() == "PLUS")
        formula += "+ ";
    else if (operation.toUpperCase() == "MINUS")
        formula += "- ";
    else if (operation.toUpperCase() == "DIVIDE")
        formula += "/ ";
    else if (operation.toUpperCase() == "PERCENTAGE")
        formula += "% ";
    //else if (operation.toUpperCase() == "AVERAGE")
    //    formula += "% ";
    formula += ControlID;


      

    document.getElementById("txtformula").value = formula;

    //var table = document.getElementById("tblOperationDetail");
    //var row = table.insertRow(1);
    //var cell1 = row.insertCell(0);
    //var cell2 = row.insertCell(1);
    //cell1.innerHTML = $("#CommonMasterBody_DynamicFormMasterBody_ddlOperation option:selected").text();
    //cell2.innerHTML = $("#CommonMasterBody_DynamicFormMasterBody_ddlControlID option:selected").text();
}

function fieldClick(event) {

    //document.getElementById("RequiredFieldID").value = event.id
    //$('#con-close-modal').modal('show');
    // id.removeChild();
    //redips.divDelete(id);
    //detailWindow();
}


function fieldset(event,divid) {
    debugger;
    var generatedcontrolID = "";
    var test = CURRENTPAGE_CONTEXT+"ControlCount";
 
    CONTROL_COUINT  = document.getElementById(CURRENTPAGE_CONTEXT + "ControlCount").value;
    FORM_NAME = document.getElementById(CURRENTPAGE_CONTEXT + "FormName").value;
    SECTIONID = document.getElementById(CURRENTPAGE_CONTEXT + "sectionID").value;
    if (event[0].getAttribute("type") == "label" || event[0].getAttribute("type") == "select" || event[0].getAttribute("type") == "textarea" || event[0].getAttribute("type") == "heading")
    {
        event[0].id = "dynamic_" + event[0].getAttribute("type") + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
        event[0].name = "dynamic_" + event[0].getAttribute("type") + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
        generatedcontrolID = "dynamic_" + event[0].getAttribute("type") + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
    }
    else
    {
        event[0].id = "dynamic_" + event[0].type + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
        event[0].name = "dynamic_" + event[0].getAttribute("type") + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
        generatedcontrolID = "dynamic_" + event[0].type + FORM_NAME + SECTIONID + "_" + CONTROL_COUINT;
    }
    CONTROL_COUINT++;
    document.getElementById(CURRENTPAGE_CONTEXT + "ControlCount").value = CONTROL_COUINT;

    return generatedcontrolID;
   
}



// delete DIV element from table editor
redips.divDelete = function (el) {
    debugger;
    var div = REDIPS.drag.findParent('DIV', el),	// set reference to the DIV element
        rcell = el.parentNode.cells[1],				// set reference to the right cell of DIV element header
        name = rcell.innerText || rcell.textContent;// set name in a cross-browser manner
    // set name to lower case
    name = name.toLowerCase();
    // confirm deletion
    if (confirm('Delete component (' + name + ')?')) {
        // delete DIV element from table editor
        div.parentNode.removeChild(div);
    }
};


// method shows/hides details of DIV elements sent as input parameter 
redips.details = function (el, type) {
    debugger;
    var divDrag = REDIPS.drag.findParent('DIV', el),	// find parent DIV element
        tbl = divDrag.childNodes[0],	// first child node is table
        div = divDrag.childNodes[1],	// second child node is hidden DIV (with containing component details)
    // test = tbl.rows,
        td = tbl.rows[0].cells[0];		// set reference of the first cell in table header
    // show component details
    if (type === undefined || type === 'show') {
        td.innerHTML = '';
        div.style.display = 'block';
        div.style.zIndex = 999;
        // element with position: absolute is taken out of the normal flow of the page and positioned at the desired coordinates relative to its containing block
        // http://www.quirksmode.org/css/position.html
        div.style.position = 'absolute';
        // http://foohack.com/2007/10/top-5-css-mistakes/ (how z-index works)
        // setting z-index and opacity were messing things up (so opacity should be turned off) 
        divDrag.style.opacity = 1;
    }
    // hide component details
    else {
        td.innerHTML = '+';
        div.style.display = 'none';
        div.style.zIndex = -1;
        div.style.position = '';
        // return opacity value (if opacity is removed from style.css then this line should be removed as well)
        divDrag.style.opacity = 0.9;
    }
};


// save form
redips.save = function () {
    // declare local variables
    var tblEditor = document.getElementById(redips.tableEditor),
        divs = tblEditor.getElementsByTagName('DIV'),
        frm,			// form reference inside component (it should be only one form)
        JSONobj = [],	// prepare JSON object
        json,			// json converted to the string
        component,		// component object
        div,			// current DIV element
        pos,			// component position
        i;				// loop variable
    // loop goes through each DIV element collected in table editor
    for (i = 0; i < divs.length; i++) {
        // set current DIV element
        div = divs[i];
        // filter only components
        if (div.className.indexOf('redips-drag') > -1) {
            // initialize component object
            component = {};
            // component id (only first three characters because cloned element will have addition in id)
            component.id = div.id.substring(0, 3);
            // component position
            pos = REDIPS.drag.getPosition(div);	// get component position in editor table and remove first item from array (table index is not needed)
            pos.shift();						// remove first item from array (table index is not needed)
            component.position = pos;			// add position to the component
            // set form reference (there shoud be only one form inside DIV component)
            frm = div.getElementsByTagName('FORM')[0];
            // call method to scan component form and return all form elements with their values
            component.form = redips.form2obj(frm);
            // push values for DIV element as Array to the Array
            JSONobj.push(component);
        }
    }
    // prepare query string in JSON format (only if array isn't empty)
    if (JSONobj.length > 0) {
        json = JSON.stringify(JSONobj);
    }
    // make ajax call and set redips.handler2 as callback function
    REDIPS.drag.ajaxCall(redips.ajaxSave, redips.handler2, { method: 'POST', data: 'json=' + json });
};


// AJAX handler - called after save button is clicked
// error handling is wrapped inside callback function
redips.handler2 = function (xhr) {
    // set reference to message element
    var message = document.getElementById('message');
    // if status is OK
    if (xhr.status === 200) {
        message.innerHTML = xhr.responseText;
    }
    // if request status isn't OK
    else {
        message.innerHTML = 'Error: [' + xhr.status + '] ' + xhr.statusText;
    }
};


// method scans form and returns object as result
redips.form2obj = function (frm) {
    var obj = [],	// result array initialization
        type,		// form element type
        name,		// form element name
        value,		// form element value
        idx,		// selected index
        i, j;		// loop variables
    // loop through each element on form
    for (i = 0; i < frm.elements.length; i++) {
        // define element type and name
        type = frm.elements[i].type;
        name = frm.elements[i].name;
        // switch on element type
        switch (type) {
            case 'text':
            case 'textarea':
            case 'password':
            case 'hidden':
                value = frm.elements[i].value;
                break;
            case 'radio':
            case 'checkbox':
                value = frm.elements[i].checked;
                break;
            case 'select-one':
                idx = frm.elements[i].selectedIndex;
                value = frm.elements[i].options[idx].value;
                break;
            /*
            case 'select-multiple':
                for (j = 0; j < frm.elements[i].options.length; j++) {
                    frm.elements[i].options[j].selected = false;
                }
                break;
            */
        }
        // push element form to the object
        obj.push({ 'type': type, 'name': name, 'value': value });
    }
    return obj;
};


// function merge cells horizontally 
redips.merge = function () {
    REDIPS.table.merge('h');
};


// function splits cells horizontally
redips.split = function () {
    REDIPS.table.split('h');
};


// insert row (below current row)
redips.rowInsert = function (el) {
    debugger;
    var row = REDIPS.drag.findParent('TR', el),	// find source row (skip inner row)
        top_row,									// cells reference in top row of the table editor
        nr,											// new table row
        lc;											// last cell in newly inserted row
    // set reference to the top row cells
    top_row = row.parentNode.rows[0].cells;
    // insert table row
    nr = REDIPS.table.row(redips.tableEditor, 'insert', row.rowIndex + 1);
    // define last cell in newly inserted table row
    lc = nr.cells[nr.cells.length - 1];
    // copy last cell content from the top row to the last cell of the newly inserted row
    lc.innerHTML = top_row[top_row.length - 1].innerHTML;
    lc.setAttribute("last", "true");
    // ignore last cell (attached onmousedown event listener will be removed)
    REDIPS.table.cell_ignore(lc);
};

redips.colInsert = function (el) {

    var row = REDIPS.drag.findParent('TR', el),	// find source row (skip inner row)
        top_row,									// cells reference in top row of the table editor
        nr,											// new table row
        lc;											// last cell in newly inserted row
    // set reference to the top row cells
    row.insertCell(row.cells -1);
};


// remove table row from the table editor
redips.rowDelete = function (el) {
    // find source row (skip inner row)
    var row = REDIPS.drag.findParent('TR', el);
    // confirm deletion
    if (confirm('Delete row?')) {
        // delete row from table editor
        REDIPS.table.row(redips.tableEditor, 'delete', row.rowIndex);
    }
};


redips.cellDelete = function (el) {
    // find source row (skip inner row)
    var row = REDIPS.drag.findParent('TR', el);
    // confirm deletion
    if (confirm('Delete Cell?')) {
        // delete row from table editor
        row.deleteCell(0);
        //REDIPS.table.row(redips.tableEditor, 'delete', row.rowIndex);
    }
};

// add onload event listener
if (window.addEventListener) {
    window.addEventListener('load', redips.init, false);
}
else if (window.attachEvent) {
    window.attachEvent('onload', redips.init);
}