var dynamicTable;
var tdCount = 0;
var trCount = 0;
var currentRow;
var currentColumn;

createTable("table2");
function createTable(tableID)
{
    
    this.dynamicTable = document.getElementById(tableID);

    if (dynamicTable.getAttribute("tdCount"))
        tdCount = dynamicTable.getAttribute("tdCount");

        createTR();
        createTD();
    
  
    return false;
}
///////////////*****************TABLE TRS***************/////////////////
function createTR()
{
    if (dynamicTable.getAttribute("trCount"))
        trCount = dynamicTable.getAttribute("trCount");

    currentRow = dynamicTable.insertRow();
    currentRow.setAttribute("id", "tr" + trCount);
    trCount++;
    dynamicTable.setAttribute("trCount", trCount);

    createTD();

    return false;
}

function deleteRow(rowID) {
    for (var count = 0; count < dynamicTable.rows.length; count++) {
        if (dynamicTable[count].getAttribute("id") == rowID) {
            dynamicTable.deleteRow(count);
        }

    }

    return false;
}



///////////////*****************TABLE TDS***************/////////////////
function createTD()
{
    if (dynamicTable.getAttribute("tdCount"))
        tdCount = dynamicTable.getAttribute("tdCount");

    currentColumn = currentRow.insertCell();
    currentColumn.setAttribute("id", "td" + tdCount);
    currentColumn.addEventListener('click', tdClick);
    tdCount++;
    dynamicTable.setAttribute("tdCount", tdCount);

    return false;
}
function RowCreateTD(columnID)
{
    for (var count = 0; count < dynamicTable.rows.length; count++) {
        for (var innerCount = 0; innerCount < dynamicTable.rows[count].cells.length; innerCount++) {
            if (dynamicTable.rows[count].cells[innerCount].getAttribute("id") == columnID) {

                backupRow = currentRow;
                currentRow = dynamicTable.rows[count];

                createTD();
                currentRow = backupRow;

            }
        }


    }

    return false;
}


function deleteCloumn(columnID) {
    for (var count = 0; count < dynamicTable.rows.length; count++)
    {
        for (var innerCount = 0; innerCount < dynamicTable.rows[count].cells.length; innerCount++)
        {
            if (dynamicTable.rows[count].cells[innerCount].getAttribute("id") == columnID) {
                dynamicTable.rows[count].deleteCell(count);
            }
        }
       

    }

    return false;
}

function getTableHTML()
{
    alert(dynamicTable.outerHTML);

    //document.getElementById("hidddenhtml").value = dynamicTable.outerHTML;
    //alert(document.getElementById("hidddenhtml").value);
    return false;
}

function tdClick(event)
{
  
    RowCreateTD(this.id);
}
//****************************8//

function processTableContent(redips)
{
    var rows = dynamicTable.rows;

    for (var count = 0; count < rows.length; count++)
    {
        for (var cellCount = 0; cellCount < rows[count].length; cellCount++)
        {
            var currentCell = rows[count].cells[cellCount];

            var content = redips.getContent(currentCell.getAttribute("id"));
        }
    }
};