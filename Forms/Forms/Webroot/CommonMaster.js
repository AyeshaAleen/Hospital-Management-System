function validate() {
debugger;
    var validator = new IValidation("forms", true)
    validator.initValidation();
    return iFormIsValid(validator);

    GenerateTags();
}

function GenerateTags() {
    debugger;
    var Tags = "";
    if (validate()) {

        var control = document.getElementById("CommonMasterBody_FormMasterBody_tableDynamic");
        var table = control;
        // document.getElementById("CommonMasterBody_FormMasterBody_Tages").value = "";
        var rows = table.getElementsByTagName("tr");

        for (var i = 0; i < rows.length; i++) {

            var TagID = "", TagText = "";

            let inputs = rows[i].getElementsByTagName('input');
            let spans = rows[i].getElementsByTagName('span');
            let selects = rows[i].getElementsByTagName('select');

            for (let input of inputs) {
            //TagID = input.id.split('_').length > 0 ? input.id.split('_')[input.id.split('_').length - 1] : input.id;
                TagID = input.id.split('_')[2];
                if (input.type == "radio")
                    TagText = input.checked ? "1" : "0";
                if (input.type == "checkbox")
                    TagText = input.checked ? "1" : "0";
                if (input.type == "text")
                    TagText = input.value;
                Tags += "<" + TagID + ">" + TagText + "</" + TagID + ">";
            }
            for (let span of spans) {
                TagID = span.id.split('_')[2];
                TagText = span.innerHTML;
                Tags += "<" + TagID + ">" + TagText + "</" + TagID + ">";
            }
            for (let select of selects) {
                TagID = select.id.split('_')[2];
                let Options = select.getElementsByTagName('option');
                for(let Option of Options)
                {
                    TagText = "";
                    TagText += "<option>" + Option.value + "</option>";
                }
                Tags += "<" + TagID + ">" + TagText + "</" + TagID + ">";
            }
        }
        // document.getElementById("CommonMasterBody_FormMasterBody_Tages").value = Tags;
        return Tags;
    }
    else {
        return Tags;
    }
}

