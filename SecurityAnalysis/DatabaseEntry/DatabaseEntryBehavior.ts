window.onload = function (): void {

    inputFieldChanged();    //call this onload, in case input fields are already populated on a refresh

    let inputElements: inputElementsCollection = getAllInputElements();
    for (let inputElementId in inputElements) {
        let inputElement: HTMLInputElement = inputElements[inputElementId];
        inputElement.oninput = function () { inputFieldChanged() };
    }

    let btnClear: HTMLButtonElement = document.getElementById("btnClear") as HTMLButtonElement;
    btnClear.onclick = function () { clearAllInputs(btnClear) };

    let btnSend: HTMLButtonElement = document.getElementById("btnSend") as HTMLButtonElement;
    btnSend.onclick = function () { validateAndSend() };

    let txtDate: HTMLTextAreaElement = document.getElementById("txtDate") as HTMLTextAreaElement;
    txtDate.focus();
}

function inputFieldChanged(): void {
    let inputElements: inputElementsCollection = getAllInputElements();
    let inputsEntered: boolean = false;

    for (let inputElementId in inputElements) {
        let inputElement: HTMLInputElement = inputElements[inputElementId];

        if (inputElement.value.length > 0) {
            inputsEntered = true;
            break;
        }
    }

    let btnClear = document.getElementById("btnClear") as HTMLButtonElement;

    if (inputsEntered) {
        btnClear.disabled = false;
    }
    else {
        btnClear.disabled = true;
    }
}

function getAllInputElements(): inputElementsCollection {
    let txtDate: HTMLInputElement = document.getElementById("txtDate") as HTMLInputElement;
    let txtTicker: HTMLInputElement = document.getElementById("txtTicker") as HTMLInputElement;
    let txtNumberOfShares: HTMLInputElement = document.getElementById("txtNumberOfShares") as HTMLInputElement;
    let txtTotalCost: HTMLInputElement = document.getElementById("txtTotalCost") as HTMLInputElement;

    return {
        "txtDate": txtDate, "txtTicker": txtTicker, "txtNumberOfShares": txtNumberOfShares, "txtTotalCost": txtTotalCost
    };
}

function clearAllInputs(btnClear: HTMLButtonElement): void {
    let inputElements: inputElementsCollection = getAllInputElements();

    for (let inputElementId in inputElements) {
        let inputElement: HTMLInputElement = inputElements[inputElementId];
        inputElement.innerText = "";
    }

    btnClear.disabled = true;
}

function validateAndSend(): void {
    if (validateForm) {

    }
}

function validateForm(): boolean {
    let inputElements: inputElementsCollection = getAllInputElements();

    let txtDate = inputElements["txtDate"];
    if (!validateDate(txtDate.value)) {
        txtDate.focus();
        txtDate.validationMessage = "test val";
        return false;
    }

    return true;
    //txtDate.val
}


function validateDate(dateInput: string): boolean {
    let internalDate: Date = new Date(dateInput);

    if (isNaN(internalDate.valueOf())) {
        return false;
    }

    return true;
}

interface inputElementsCollection {
    [id: string]: HTMLInputElement;
}