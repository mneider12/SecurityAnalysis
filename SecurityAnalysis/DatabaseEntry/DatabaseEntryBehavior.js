window.onload = function () {
    inputFieldChanged(); //call this onload, in case input fields are already populated on a refresh
    var inputElements = getAllInputElements();
    for (var inputElementId in inputElements) {
        var inputElement = inputElements[inputElementId];
        inputElement.oninput = function () { inputFieldChanged(); };
    }
    var btnClear = document.getElementById("btnClear");
    btnClear.onclick = function () { clearAllInputs(btnClear); };
    var btnSend = document.getElementById("btnSend");
    btnSend.onclick = function () { validateAndSend(); };
    var txtDate = document.getElementById("txtDate");
    txtDate.focus();
};
function inputFieldChanged() {
    var inputElements = getAllInputElements();
    var inputsEntered = false;
    for (var inputElementId in inputElements) {
        var inputElement = inputElements[inputElementId];
        if (inputElement.value.length > 0) {
            inputsEntered = true;
            break;
        }
    }
    var btnClear = document.getElementById("btnClear");
    if (inputsEntered) {
        btnClear.disabled = false;
    }
    else {
        btnClear.disabled = true;
    }
}
function getAllInputElements() {
    var txtDate = document.getElementById("txtDate");
    var txtTicker = document.getElementById("txtTicker");
    var txtNumberOfShares = document.getElementById("txtNumberOfShares");
    var txtTotalCost = document.getElementById("txtTotalCost");
    return {
        "txtDate": txtDate, "txtTicker": txtTicker, "txtNumberOfShares": txtNumberOfShares, "txtTotalCost": txtTotalCost
    };
}
function clearAllInputs(btnClear) {
    var inputElements = getAllInputElements();
    for (var inputElementId in inputElements) {
        var inputElement = inputElements[inputElementId];
        inputElement.innerText = "";
    }
    btnClear.disabled = true;
}
function validateAndSend() {
    if (validateForm) {
    }
}
function validateForm() {
    var inputElements = getAllInputElements();
    var txtDate = inputElements["txtDate"];
    if (!validateDate(txtDate.value)) {
        txtDate.focus();
        txtDate.validationMessage = "test val";
        return false;
    }
    return true;
    //txtDate.val
}
function validateDate(dateInput) {
    var internalDate = new Date(dateInput);
    if (isNaN(internalDate.valueOf())) {
        return false;
    }
    return true;
}
//# sourceMappingURL=DatabaseEntryBehavior.js.map