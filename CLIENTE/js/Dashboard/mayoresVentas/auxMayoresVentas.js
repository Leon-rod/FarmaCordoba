export async function mapViewOS(register) {
    const row = document.createElement("tr");

    const añoCell = document.createElement("td");
    añoCell.textContent = register.year;

    const mesCell = document.createElement("td");
    mesCell.textContent = register.month;

    const clientCell = document.createElement("td");
    clientCell.textContent = register.client;

    const quantityPurchasesCell = document.createElement("td");
    quantityPurchasesCell.textContent = register.quantityPurchases;

    const maxAmountCell = document.createElement("td");
    maxAmountCell.textContent = `$` + register.maxAmount;

    row.appendChild(añoCell)
    row.appendChild(mesCell)
    row.appendChild(clientCell)
    row.appendChild(quantityPurchasesCell)
    row.appendChild(maxAmountCell)


    document.getElementById("tableBody").appendChild(row);
}

export async function loadYears(select) {
    const year = new Date().getFullYear();

    for(let i = 2019; i<= year; i++){
        const option = document.createElement("option");
        option.value =  i; 
        option.textContent = i; 
        select.appendChild(option);
    }

}