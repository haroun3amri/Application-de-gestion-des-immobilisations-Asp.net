
function onchangeannee() {
        $("#NUMBL").data("kendoComboBox").dataSource.read(),
        $("#NUMLIGBL").data("kendoComboBox").dataSource.read();
    }
    

    function onchangeNumbl() {
        $("#NUMLIGBL").data("kendoComboBox").dataSource.read();

    }
    


    function AdditionalData1() {
        return {
            ANNEEBL: $("#ANNEEBL").data("kendoComboBox").value()
        }
    }
    //****************************************************************
    function AdditionalData2() {
        return {
            ANNEEBL: $("#ANNEEBL").data("kendoComboBox").value(),
            NUMBL: $("#NUMBL").data("kendoComboBox").value()

              }
    }
    //***********************************************************